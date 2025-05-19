using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TCV_JapaNinja.Class.ConnectedData;
using TCV_JapaNinja.Models.DatabaseCustoms;
using System.Security.RightsManagement;
using System.Runtime.InteropServices;

namespace TCV_JapaNinja.Forms.Study.CommonSection
{
    public partial class FormFlashCard : Form
    {

        /*
         * Thêm phần setting cho flashcard
         */

        /// <summary>
        /// Lớp đại diện cho một thẻ flashcard
        /// </summary>
        private class FlashCard
        {
            public int grammarId { get; set; } // ID của ngữ pháp (nếu có)
            public int vocabularyId { get; set; } // ID của từ vựng (nếu có)
            public int kanjiId { get; set; } // ID của kanji (nếu có)
            public int technicalId { get; set; } // ID của từ chuyên ngành (nếu có)
            public string Question { get; set; }
            public string Answer { get; set; }
            public string Hint { get; set; } // Gợi ý
            public bool Remembered { get; set; }

        }

        private List<FlashCard> flashCards = new List<FlashCard>();
        private int currentCardIndex = 0;
        private bool showingQuestion = true;

        private bool isAdjustControlPositons = false; // Biến kiểm tra xem có đang điều chỉnh vị trí control hay không

        public FormFlashCard()
        {
            InitializeComponent();

            SetupUI();
            //SetupFlashCards();
            SetUpUISettingPanel();

            ShowFlashCard();
            InitTimerAnimation();
        }
        private void FormFlashCard_Load(object sender, EventArgs e)
        {


        }
        private void SetupFlashCards()
        {
            flashCards.Add(new FlashCard { Question = "What is the capital of France?", Answer = "Paris", Hint = "It's also known as the city of lights." });
            flashCards.Add(new FlashCard { Question = "What is 2 + 2?", Answer = "4", Hint = "It's the first even number." });
            flashCards.Add(new FlashCard { Question = "What is the largest planet in our solar system?", Answer = "Jupiter", Hint = "It's named after the king of the Roman gods." });
            // Add more flashcards as needed
        }

        #region UI Controls

        private Label lblContent; // Nội dung flashcard
        private Label lblHint; // Gợi ý
        //private Button btnPrev; // Nút trước
        //private Button btnNext; // Nút sau
        //private Button btnRemember; // Nút ghi nhớ
        //private Button btnHint; // Nút gợi ý

        private void SetupUI()
        {
            //this.Text = "Flash Card";
            this.TopLevel = false; // Quan trọng : đề form không thể hiển thị như cửa sổ độc lập
            this.FormBorderStyle = FormBorderStyle.None; // Không có viền
            this.Dock = DockStyle.Fill; // Để form chiếm toàn bộ không gian
            this.BackColor = Color.FromArgb(240, 242, 245);

            cardPanel.BackColor = Color.White;
            cardPanel.BorderStyle = BorderStyle.FixedSingle;

            cardPanel.Paint += (s, e) =>
            {
                // Vẽ viền cho panel
                ControlPaint.DrawBorder(e.Graphics, cardPanel.ClientRectangle,
                    Color.FromArgb(100, 0, 0, 0), 8, ButtonBorderStyle.Solid,
                    Color.FromArgb(100, 0, 0, 0), 8, ButtonBorderStyle.Solid,
                    Color.FromArgb(100, 0, 0, 0), 8, ButtonBorderStyle.Solid,
                    Color.FromArgb(100, 0, 0, 0), 8, ButtonBorderStyle.Solid);
            };

            // Hint Panel 
            hintPanel.Visible = false; // Ẩn panel gợi ý ban đầu
            hintPanel.BackColor = Color.FromArgb(240, 240, 240); // Màu nền xám nhạt
            hintPanel.BorderStyle = BorderStyle.FixedSingle;
            hintPanel.Height = 60; // Chiều cao cố định cho panel gợi ý

            // Label Nội dung flashcard
            lblContent = new Label()
            {
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Margin = new Padding(30),
                AutoEllipsis = true,
                Cursor = Cursors.Hand,
                ForeColor = Color.FromArgb(30, 30, 30),
                AutoSize = false,
            };
            lblContent.Click += (s, e) => { StartFlipAnimation(); };
            cardPanel.Controls.Add(lblContent);

            // Label Gợi ý
            lblHint = new Label()
            {
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Dock = DockStyle.Fill,
                Text = ""
            };

            hintPanel.Controls.Add(lblHint);

            // Button Trước
            btnPrev.Click += BtnPrev_Click;
            btnPrev.MouseEnter += btnIcon_MouseEnter;
            btnPrev.MouseLeave += btnIcon_MouseLeave;

            // Button Ghi nhớ
            btnRemember.Click += BtnRemember_Click;
            btnRemember.MouseEnter += btnIcon_MouseEnter;
            btnRemember.MouseLeave += btnIcon_MouseLeave;

            // Button Gợi ý
            btnHint.Click += BtnHint_Click;
            btnHint.MouseEnter += btnIcon_MouseEnter;
            btnHint.MouseLeave += btnIcon_MouseLeave;

            // Button Sau
            btnNext.Click += BtnNext_Click;
            btnNext.MouseEnter += btnIcon_MouseEnter;
            btnNext.MouseLeave += btnIcon_MouseLeave;

            isAdjustControlPositons = true; // Cho phép điều chỉnh vị trí control
            AdjustControlPositons();
        }
        /// <summary>
        /// Khi di chuột vào icon, thay đổi màu sắc của icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIcon_MouseEnter(object sender, EventArgs e)
        {
            IconButton btn = sender as IconButton;
            if (btn != null)
            {
                btn.BackColor = Color.White;
                btn.IconColor = Color.FromArgb(0, 192, 192);
            }
        }
        /// <summary>
        /// Khi di chuột ra khỏi icon, khôi phục màu sắc của icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIcon_MouseLeave(object sender, EventArgs e)
        {
            IconButton btn = sender as IconButton;
            if (btn != null)
            {
                btn.BackColor = Color.White;
                btn.IconColor = Color.Black;
            }
        }
        /// <summary>
        /// Khi nhấn nút trước, chuyển đến thẻ flashcard trước đó
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (currentCardIndex > 0)
            {
                currentCardIndex--;
                showingQuestion = true;
                ShowFlashCard();
            }
        }
        /// <summary>
        /// Khi nhấn nút ghi nhớ, thay đổi trạng thái ghi nhớ của thẻ flashcard hiện tại
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRemember_Click(object sender, EventArgs e)
        {
            var card = flashCards[currentCardIndex];
            card.Remembered = !card.Remembered;
            btnRemember.ForeColor = card.Remembered ? Color.Red : Color.Gray;
        }
        /// <summary>
        /// Khi nhấn nút gợi ý, hiển thị hoặc ẩn gợi ý cho thẻ flashcard hiện tại
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHint_Click(object sender, EventArgs e)
        {
            var card = flashCards[currentCardIndex];
            lblHint.Text = card.Hint;
            hintPanel.Visible = !hintPanel.Visible;
        }
        /// <summary>
        /// Khi nhấn nút sau, chuyển đến thẻ flashcard tiếp theo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (currentCardIndex < flashCards.Count - 1)
            {
                currentCardIndex++;
                showingQuestion = true;
                ShowFlashCard();
            }
        }
        /// <summary>
        /// Cập nhật nội dung của thẻ flashcard hiện tại
        /// </summary>
        private void ShowFlashCard()
        {
            if (flashCards == null || flashCards.Count == 0) return; // Nếu không có thẻ nào thì không làm gì cả

            UpdateLabelText();

            // Ẩn gợi ý khi đổi thẻ
            lblHint.Text = "";

            // Cập nhật nút ghi nhớ
            btnRemember.ForeColor = flashCards[currentCardIndex].Remembered ? Color.Red : Color.Gray;

            btnPrev.Enabled = currentCardIndex > 0;
            btnNext.Enabled = currentCardIndex < flashCards.Count - 1;
        }
        /// <summary>
        /// Điều chỉnh vị trí và font chữ các control dựa vào kích thước form và nội dung
        /// </summary>
        private void AdjustControlPositons()
        {
            // Nếu không được phép điều chỉnh hoặc control chưa sẵn sàng thì thoát.
            if (!isAdjustControlPositons || lblContent == null || flashCards.Count == 0) return; // Nếu không cần điều chỉnh thì thoát

            int margin = 20;
            int panelWidth = this.ClientSize.Width - 2 * margin; // Chiều rộng phần nội dung
            int panelHeight = this.ClientSize.Height / 2; // Chiều cao phần nội dung

            // Điều chỉnh vùng hiển thị nội dung
            AdjustLblContent(margin, panelWidth, panelHeight);

            // Lấy nội dung hiện tại để đo kích thước cho nhãn hiển thị nội dung chính
            string textToMeasure = showingQuestion ? flashCards[currentCardIndex].Question : flashCards[currentCardIndex].Answer;

            // Tìm kích thước font chữ phù hợp nhất trong giới hạn từ 12 đến 48
            int bestFontSize = GetBestFitFontSize(lblContent, textToMeasure, "Segoe UI", 12, 48);

            // Cập nhật font chữ mới theo kích thước phù hợp
            Font newFont = new Font("Segoe UI", bestFontSize, FontStyle.Bold);

            if(!lblContent.Font.Equals(newFont))
            {
                lblContent.Font = newFont;
            }

            // Cập nhật kích thước của hint panel (dưới cùng form)
            AdjustHintPanel(margin, panelWidth); // Điều chỉnh kích thước panel gợi ý
        }

        private void AdjustLblContent(int margin, int width, int height)
        {
            lblContent.Location = new Point(margin, margin);
            lblContent.Size = new Size(width, height);
        }

        private void AdjustHintPanel(int margin, int width)
        {
            int hintFontSize = Math.Max(8, ClientSize.Width / 50);
            lblHint.Font = new Font("Segoe UI", hintFontSize, FontStyle.Italic);

            // Ước tính chiều cao cần thiết dựa trên text
            using (Graphics g = CreateGraphics())
            {
                SizeF textSize = g.MeasureString(lblHint.Text, lblHint.Font, width);
                int desiredHeight = (int)textSize.Height + 20; // Thêm khoảng cách cho padding
                hintPanel.Height = Math.Max(40, desiredHeight);
            }    
        }

        /// <summary>
        /// Tìm kích thước font lớn nhất sao cho nội dung vẫn vừa trong control
        /// </summary>
        /// <param name="control">Control hiển thị nội dung (ví dụ: Label)</param>
        /// <param name="text">Nội dung cần hiển thị</param>
        /// <param name="fontName">Tên font</param>
        /// <param name="minSize">Kích thước font nhỏ nhất</param>
        /// <param name="maxSize">Kích thước font lớn nhất</param>
        /// <returns>Kích thước font phù hợp</returns>
        private int GetBestFitFontSize(Control control, string text, string fontName, int minSize, int maxSize)
        {
            using (Graphics g = control.CreateGraphics())
            {
                // Duyệt từ font lớn nhất đến nhỏ nhất
                for (int fontSize = maxSize; fontSize >= minSize; fontSize--)
                {
                    using (Font testFont = new Font(fontName, fontSize, FontStyle.Bold))
                    {
                        // Đo kích thước văn bản sẽ chiếm
                        SizeF textSize = g.MeasureString(text, testFont);

                        // Nếu vừa cả chiều rộng và chiều cao, trả về font này
                        if (textSize.Width <= control.Width && textSize.Height <= control.Height)
                        {
                            return fontSize;
                        }
                    }
                }
            }

            // Nếu không font nào phù hợp thì dùng font nhỏ nhất
            return minSize;
        }

        /// <summary>
        /// Khi form thay đổi kích thước, tự động điều chỉnh kích thước control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormFlashCard_Resize(object sender, EventArgs e)
        {
            AdjustControlPositons();
        }

        #endregion


        #region Animation

        private Timer flipTimer;
        private float flipProgress = 0f; // Theo tỷ lệ 0-1 cho Animation
        private const float flipSpeed = 0.12f; // Tốc độ lật, điều chỉnh nhanh hơn hoặc chậm hơn

        private bool isFlipping = false;

        private void InitTimerAnimation()
        {
            flipTimer = new Timer();
            flipTimer.Interval = 25; // Thay đổi tốc độ lật, 25ms; ~40 FPS
            flipTimer.Tick += FlipTimer_Tick;
        }

        private void FlipTimer_Tick(object sender, EventArgs e)
        {
            flipProgress += flipSpeed;
            if (flipProgress >= 1f)
            {
                flipProgress = 1f;
                isFlipping = false;
                flipTimer.Stop();

                lblContent.Width = this.ClientSize.Width - 40;
                lblContent.Font = new Font(lblContent.Font.FontFamily, Math.Max(16, ClientSize.Width / 15), FontStyle.Bold);
                return;
            }

            // Tính scale X: từ 1 xuống 0 (đến giữa animation), sau đó 0 lên 1 (kết thúc)
            float scaleX;
            if (flipProgress < 0.5f)
            {
                scaleX = 1f - 2f * flipProgress;
            }
            else
            {
                if (isFlipping)
                {
                    // Đổi nội dung ở giữa animation
                    showingQuestion = !showingQuestion;
                    UpdateLabelText();
                    isFlipping = false;
                }
                scaleX = -1f + 2f * flipProgress; // từ 0 tới 1
            }
            // Áp dụng hiệu ứng co dãn ngang
            int newWidth = (int)((this.ClientSize.Width - 40) * Math.Abs(scaleX));
            if (newWidth < 10) newWidth = 10; // không quá nhỏ
            lblContent.Width = newWidth;
            // Canh giữa label lại khi co nhỏ
            lblContent.Left = 20 + ((this.ClientSize.Width - 40) - lblContent.Width) / 2;

            Invalidate(); // Yêu cầu vẽ lại
        }

        private void StartFlipAnimation()
        {
            if (isFlipping) return; // Nếu đang lật thì không làm gì cả
            isFlipping = true;
            flipProgress = 0f;
            flipTimer.Start();
        }

        private void UpdateLabelText()
        {
            if (flashCards == null || flashCards.Count == 0) return; // Nếu không có thẻ nào thì không làm gì cả
            if (showingQuestion)
            {
                lblContent.Text = flashCards[currentCardIndex].Question;
            }
            else
            {
                lblContent.Text = flashCards[currentCardIndex].Answer;
            }
        }


        #endregion

        #region Data Flash Card

        /// <summary>
        /// Lấy dữ liệu từ database về và hiển thị lên form
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datas"></param>
        /// <param name="leaningCatego"></param>
        public void GetDataFlashCard<T>(List<T> datas, int leaningCatego) where T : class
        {
            enLearningCategory enLearning = (enLearningCategory)leaningCatego;
            // Lấy dữ liệu từ database về và hiển thị lên form
            // Tạo danh sách flashcard từ dữ liệu
            flashCards.Clear();

            switch (enLearning)
            {
                case enLearningCategory.Kanji:
                    GetDataToKanji(datas as List<CustomKanji>);
                    break;
                case enLearningCategory.Vocabulary:
                    GetDataToVocabulary(datas as List<CustomVocabulary>);
                    break;
                case enLearningCategory.Grammar:
                    GetDataToGrammar(datas as List<CustomGrammar>);
                    break;
                case enLearningCategory.Technical:
                    GetDataToTechnical(datas as List<CustomTechnical>);
                    break;
                default:
                    break;
            }

            ShowFlashCard();
        }

        /// <summary>
        /// Lấy dữ liệu từ database về và hiển thị lên form
        /// </summary>
        /// <param name="datas"></param>
        private void GetDataToKanji(List<CustomKanji> datas)
        {
            foreach (var item in datas)
            {
                flashCards.Add(new FlashCard
                {
                    kanjiId = item.Id,
                    Question = item.Kanji,
                    Answer = item.TiengViet,
                    Hint = item.Example,
                    Remembered = item.HistoryKanji.IsRemembered
                });
            }
        }

        private void GetDataToVocabulary(List<CustomVocabulary> datas)
        {
            foreach (var item in datas)
            {
                flashCards.Add(new FlashCard
                {
                    vocabularyId = item.Id,
                    Question = item.Vocabulary,
                    Answer = item.TiengViet,
                    Hint = item.Example,
                    Remembered = item.HistoryVocabulary.IsRemembered
                });
            }
        }

        private void GetDataToGrammar(List<CustomGrammar> datas)
        {
            foreach (var item in datas)
            {
                flashCards.Add(new FlashCard
                {
                    grammarId = item.Id,
                    Question = item.Structure,
                    Answer = item.Sample,
                    Hint = item.Example,
                    Remembered = item.HistoryGrammar.IsRemembered
                });
            }
        }

        private void GetDataToTechnical(List<CustomTechnical> datas)
        {
            foreach (var item in datas)
            {
                flashCards.Add(new FlashCard
                {
                    technicalId = item.Id,
                    Question = item.Vocabulary,
                    Answer = item.TiengViet,
                    Hint = item.Example,
                    Remembered = item.HistoryTechnical.IsRemembered
                });
            }
        }

        #endregion

        #region Setting Panel

        private bool isSettingPanelVisible = false; // Biến kiểm tra trạng thái hiển thị của panel setting

        private void SetUpUISettingPanel()
        {
            // Tạm thời ẩn chế độ cài đặt
            settingPanel.Visible = false; // Ẩn panel setting ban đầu


            // Thiết lập giao diện cho panel setting
            settingPanel.BorderStyle = BorderStyle.FixedSingle;
            settingPanel.Dock = DockStyle.Top; // Đặt panel ở trên cùng
            ptbSetting.IconChar = IconChar.CaretDown;
            ptbSetting.Height = 15;
            ptbSetting.Cursor = Cursors.Hand;
        }

        private void ptbSetting_Click(object sender, EventArgs e)
        {
            isSettingPanelVisible = !isSettingPanelVisible; // Đảo ngược trạng thái hiển thị của panel setting

            if (isSettingPanelVisible)
            {
                // Nếu panel setting đang được mở, tăng chiều cao của nó
                cardPanel.Visible = false;
                navigationPanel.Visible = false;
                settingPanel.Dock = DockStyle.Fill;
                //ptbSetting.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                ptbSetting.IconChar = IconChar.CaretUp;
            }
            else
            {
                // Nếu panel setting đang được đóng, giảm chiều cao của nó
                cardPanel.Visible = true;
                navigationPanel.Visible = true;
                settingPanel.Dock = DockStyle.Top;
                //ptbSetting.Image.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                ptbSetting.IconChar = IconChar.CaretDown;
            }
        }

        /// <summary>
        /// Khi di chuột vào icon setting, thay đổi màu sắc của icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ptbSetting_MouseEnter(object sender, EventArgs e)
        {
            IconPictureBox iconPictureBox = sender as IconPictureBox;
            if(iconPictureBox != null)
            {
                iconPictureBox.IconColor = Color.Red;
                iconPictureBox.ForeColor = Color.Red;
            }
        }

        private void ptbSetting_MouseLeave(object sender, EventArgs e)
        {
            IconPictureBox iconPictureBox = sender as IconPictureBox;
            if (iconPictureBox != null)
            {
                iconPictureBox.IconColor = Color.Black;
                iconPictureBox.ForeColor = Color.Black;
            }
        }

        #endregion


    }
}
