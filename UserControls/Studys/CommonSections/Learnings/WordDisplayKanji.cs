using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCV_JapaNinja.Models.DatabaseCustoms;
using System.Drawing.Printing;

namespace TCV_JapaNinja.UserControls.Studys.CommonSections.Learnings
{
    public partial class WordDisplayKanji : UserControl
    {
        public WordDisplayKanji()
        {
            InitializeComponent();
            // Khởi tạo giao diện người dùng
            InitUI();
            // Khởi tạo các thuộc tính cho animation
            InitAnimationTimer();
        }


        private void LearningWordDisplay_Load(object sender, EventArgs e)
        {

        }

        #region UI Kanji

        private Label lblKanji;
        private Label lblHanTu;
        private Label lblAmOn;
        private Label lblAmKun;
        private Label lblEnglish;
        private Label lblTiengViet;
        private Label lblExample;
        private Label lblNote;
        private FlowLayoutPanel imagePanel;
        private Panel detailPanel;

        /// <summary>
        /// Khởi tạo giao diện ban đầu
        /// </summary>
        private void InitUI()
        {
            this.Height = collapsedHeight;
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.DoubleBuffered = true; // Giúp vẽ mượt hơn
            this.Padding = new Padding(10, 10, 10, 10); // Thêm khoảng cách giữa các điều khiển và viền của UserControl
            //this.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            lblKanji = new Label()
            {
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true,
                Left = 10,
                Top = 10,
                Cursor = Cursors.Hand, // Thay đổi con trỏ khi di chuột qua
            };

            lblHanTu = new Label()
            {
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                AutoSize = true,
                Left = 200,
                Top = 15,
                Cursor = Cursors.Hand, // Thay đổi con trỏ khi di chuột qua
            };

            lblTiengViet = new Label()
            {
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.DarkGreen,
                AutoSize = true,
                Left = 400,
                Top = 15,
                Cursor = Cursors.Hand, // Thay đổi con trỏ khi di chuột qua
            };

            lblKanji.Click += ToggleExpand;
            lblHanTu.Click += ToggleExpand;
            lblTiengViet.Click += ToggleExpand;

            this.Controls.Add(lblKanji);
            this.Controls.Add(lblHanTu);
            this.Controls.Add(lblTiengViet);

            detailPanel = new Panel()
            {
                Top = 50,
                Left = 10,
                Width = this.Width - 20,
                Height = expnadedHeight - 50,
                BackColor = Color.FromArgb(245, 250, 255), // Màu xanh nhạt hơn
                Visible = false,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10)

            };

            lblAmOn = new Label() { Font = new Font("Segoe UI", 10), AutoSize = true, Top = 10, Left = 10 };
            lblAmKun = new Label() { Font = new Font("Segoe UI", 10), AutoSize = true, Top = 40, Left = 10 };
            lblEnglish = new Label() { Font = new Font("Segoe UI", 10), AutoSize = true, Top = 70, Left = 10 };
            lblExample = new Label() { Font = new Font("Segoe UI", 10), AutoSize = true, Top = 100, Left = 10 };
            lblNote = new Label() { Font = new Font("Segoe UI", 10), AutoSize = true, Top = 130, Left = 10 };
            imagePanel = new FlowLayoutPanel()
            {
                Top = 160,
                Left = 10,
                Width = detailPanel.Width - 20,
                Height = 80,
                AutoScroll = true,
                BackColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle
            };

            detailPanel.Controls.Add(lblAmOn);
            detailPanel.Controls.Add(lblAmKun);
            detailPanel.Controls.Add(lblEnglish);
            detailPanel.Controls.Add(lblExample);
            detailPanel.Controls.Add(lblNote);
            detailPanel.Controls.Add(imagePanel);

            this.Controls.Add(detailPanel);

        }


        #endregion



        #region Display Data



        private int expnadedHeight = 220; // Chiều cao mở rộng
        private int collapsedHeight = 50; // Chiều cao thu gọn


        private CustomKanji _data;

        public CustomKanji Data
        {
            get { return _data; }
            set
            {
                _data = value;
                if (_data != null)
                {
                    // Hiển thị từ vựng
                    updateDissplay();
                }
            }
        }
        /// <summary>
        /// Load dữ liệu vào control
        /// </summary>
        private void updateDissplay()
        {
            lblKanji.Text = _data.Kanji ?? "";
            lblHanTu.Text = _data.HanTu ?? "";
            lblTiengViet.Text = _data.TiengViet ?? "";

            int currentTop = 10; // Bắt đầu từ vị trí trên cùng

            // Update từng label (có nội dung mới hiển thị)
            UpdateLabelAndLayout(lblAmOn, _data.AmOn, "Âm On", ref currentTop);
            UpdateLabelAndLayout(lblAmKun, _data.AmKun, "Âm Kun", ref currentTop);
            UpdateLabelAndLayout(lblEnglish, _data.English, "Tiếng Anh", ref currentTop);
            UpdateLabelAndLayout(lblExample, _data.Example, "Ví dụ", ref currentTop);
            UpdateLabelAndLayout(lblNote, _data.Note, "Ghi chú", ref currentTop);

            // xử lý hình ảnh
            imagePanel.Controls.Clear();
            imagePanel.Visible = _data.Images != null && _data.Images.Count > 0; // Ẩn panel ảnh nếu không có ảnh

            if (imagePanel.Visible)
            {
                // Hiển thị hình ảnh

                imagePanel.Top = currentTop + 10; // Cập nhật vị trí cho panel hình ảnh

                FlowLayoutPanel imageFlow = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = true,
                    AutoSize = true,
                    AutoScroll = false,
                    Dock = DockStyle.None,
                    Location = new Point(0, 0),
                    Width = imagePanel.Width

                };

                int pictureWidth = 100;
                int pictureHeight = 100;
                int spacing = 10; // Khoảng cách giữa các ảnh
                int imagesPerRow = Math.Max(1, (imageFlow.Width - spacing) / (pictureHeight + spacing));
                int totalRows = (_data.Images.Count + imagesPerRow - 1) / imagesPerRow; // Tính số hàng cần thiết

                foreach (var image in _data.Images)
                {
                    PictureBox pictureBox = new PictureBox
                    {
                        Image = Image.FromStream(new System.IO.MemoryStream(image.ImageData)),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Width = pictureWidth,
                        Height = pictureHeight,
                        Margin = new Padding(5),
                        BorderStyle = BorderStyle.FixedSingle,

                    };
                    imageFlow.Controls.Add(pictureBox);
                }

                // Add vào imagePanel
                imagePanel.Controls.Add(imageFlow);

                // Tính chiều cao
                imagePanel.Height = totalRows * (pictureHeight + spacing) + spacing; // Hoặc tự tính dựa vào số ảnh
                currentTop = imagePanel.Bottom + 10; // Cập nhật vị trí cho panel hình ảnh
            }


        }

        /// <summary>
        /// Tính toán lại vị trí chiêu cao của các lable sau khi set dữ liệu,
        /// vì nội dung có thể nhiều dòng, và phải tự động đẩy các label dưới xuống
        /// </summary>
        /// <param name="label">label cần set</param>
        /// <param name="value">giá trị value</param>
        /// <param name="prefix">Tiêu đề là gì (ví dụ: Âm Ôn, Âm Kưn, Ví dụ,...)</param>
        /// <param name="curentTop">Lấy giá trị top</param>
        private void UpdateLabelAndLayout(Label label, string value, string prefix, ref int currentTop)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                label.Visible = false;
                return;
            }

            label.Visible = true;
            label.Text = $"{prefix}: {value}";
            label.Top = currentTop;
            label.Left = 10;
            label.Width = this.ClientSize.Width - 20; // Cập nhật chiều rộng của label
            label.MaximumSize = new Size(this.ClientSize.Width - 20, 0); // Giới hạn chiều rộng tối đa
            label.AutoSize = true; // Tự động điều chỉnh chiều cao

            // Tính chiều cao ban đầu
            Size fullSize = TextRenderer.MeasureText(label.Text, label.Font, label.MaximumSize, TextFormatFlags.WordBreak);

            int maxHeight = label.Font.Height * 2 + 5; // Giới hạn chiều cao tối đa (2 dòng)

            if (fullSize.Height > maxHeight)
            {

                // Nếu dài hơn 2 dòng -> thêm nút "Xem thêm"
                Label expandButton = new Label
                {
                    Text = "Xem thêm",
                    ForeColor = Color.Blue,
                    Font = new Font(label.Font, FontStyle.Underline),
                    Cursor = Cursors.Hand,
                    AutoSize = true,
                    Top = label.Top + maxHeight + 2,
                    Left = label.Left,
                };

                expandButton.Click += (s, e) =>
                {
                    bool isExpanded = label.Tag as bool? == true;
                    if (isExpanded)
                    {
                        // Thu gọn
                        label.Height = maxHeight;
                        expandButton.Text = "Xem thêm";
                        label.Tag = false;
                    }
                    else
                    {
                        // Mở rộng
                        label.Height = fullSize.Height;
                        expandButton.Text = "Thu gọn";
                        label.Tag = true;
                    }
                    LayoutAfterExpand(); // Cập nhật lại toàn bộ layout
                };

                label.Height = maxHeight; // set ban đầu = 2 dòng
                label.Tag = false; // lưu trạng thái (đang thu gọn)

                this.Controls.Add(expandButton);

                currentTop = expandButton.Bottom + 15;
            }
            else
            {
                currentTop = label.Bottom + 5;
            }

        }

        private void LayoutAfterExpand()
        {
            int currentTop = 10; // Bắt đầu từ vị trí trên cùng

            // Layout lại từng lable theo thứ tự
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label label && label.Visible && label != lblKanji && label != lblHanTu && label != lblTiengViet)
                {
                    label.Top = currentTop;
                    currentTop = label.Bottom + 5; // Cập nhật vị trí cho label tiếp theo
                }
            }

            // Update vị trí hình ảnh
            if (imagePanel.Visible)
            {
                imagePanel.Top = currentTop + 10;
                currentTop = imagePanel.Bottom + 10; // Cập nhật vị trí cho panel hình ảnh
            }

            this.Height = currentTop;
            collapsedHeight = this.Height; // Cập nhật chiều cao mới
        }

        #endregion

        #region Animation Expand/Collaspe

        private bool isExpanded = false;
        private Timer animationTimer = new Timer();
        private int animationSpeed = 10; // Tốc độ animation

        /// <summary>
        /// Khoi tạo các thuộc tính cho animation
        /// </summary>
        private void InitAnimationTimer()
        {
            animationTimer.Interval = 10; // Thay đổi tốc độ nếu cần
            animationTimer.Tick += Animation_Tick;
        }

        /// <summary>
        /// Sự kiện Expand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleExpand(object sender, EventArgs e)
        {
            detailPanel.Visible = true; // Đảm bảo hiển thị panel
            //expanding = !isExpanded; // Đảo trạng thái
            animationTimer.Start();
        }
        /// <summary>
        /// Sự kiện thu gọn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Animation_Tick(object sender, EventArgs e)
        {
            //int speed = 10; // Tốc độ tăng/giảm nhanh hơn

            if (isExpanded)
            {
                this.Height -= animationSpeed;
                if (this.Height <= collapsedHeight)
                {
                    this.Height = collapsedHeight;
                    isExpanded = false;
                    animationTimer.Stop();
                    detailPanel.Visible = false; // Ẩn panel khi thu gọn
                }
            }
            else
            {
                this.Height += animationSpeed;
                if (this.Height >= expnadedHeight)
                {
                    this.Height = expnadedHeight;
                    animationTimer.Stop();
                    isExpanded = true;
                }
            }
        }

        #endregion
    }
}
