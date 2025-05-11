using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCV_JapaNinja.Animations;
using TCV_JapaNinja.Models.DatabaseCustoms;

namespace TCV_JapaNinja.UserControls.Studys.CommonSections.Learnings
{
    public partial class WordDisplayGrammar: UserControl
    {
        public WordDisplayGrammar()
        {
            InitializeComponent();

            InitUI();

            InitAnimationTimer();
        }

        private void WordDisplayGrammar_Load(object sender, EventArgs e)
        {

        }

        #region UI Grammar

        private Label lblStructure;
        private Label lblSample;
        private Label lblExplain;
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

            // Cấu trúc
            lblStructure = new Label()
            {
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true,
                Left = 10,
                Top = 10,
                Cursor = Cursors.Hand, // Thay đổi con trỏ khi di chuột qua
            };

            // Ý Nghĩa
            lblSample = new Label()
            {
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.DarkGreen,
                AutoSize = true,
                Left = 400,
                Top = 15,
                Cursor = Cursors.Hand, // Thay đổi con trỏ khi di chuột qua
            };

            lblStructure.Click += ToggleExpand;
            lblSample.Click += ToggleExpand;

            this.Controls.Add(lblStructure);
            this.Controls.Add(lblSample);

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

            // Cách sử dụng
            lblExplain = new Label() { Font = new Font("Segoe UI", 10), AutoSize = true, Top = 10, Left = 10 };
            // Ví dụ
            lblExample = new Label() { Font = new Font("Segoe UI", 10), AutoSize = true, Top = 40, Left = 10 };
            // Ghi chú
            lblNote = new Label() { Font = new Font("Segoe UI", 10), AutoSize = true, Top = 70, Left = 10 };
            
            // Hình ảnh
            imagePanel = new FlowLayoutPanel()
            {
                Top = 100,
                Left = 10,
                Width = detailPanel.Width - 20,
                Height = 80,
                AutoScroll = true,
                BackColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle
            };

            detailPanel.Controls.Add(lblExplain);
            detailPanel.Controls.Add(lblExample);
            detailPanel.Controls.Add(lblNote);
            detailPanel.Controls.Add(imagePanel);

            this.Controls.Add(detailPanel);

            InitHeartIcon();
        }

        // Trái tim ghi nhớ
        private PictureBox heartIcon;
        private bool isMemorized = false; // Trạng thái đã ghi nhớ chưa
        private MultiHeartAnimator heartAnimator;
        /// <summary>
        /// Khởi tạo trái tim
        /// </summary>
        private void InitHeartIcon()
        {
            heartIcon = new PictureBox()
            {
                Size = new Size(30, 30),
                Location = new Point(this.Width - 40, 10),
                SizeMode = PictureBoxSizeMode.Zoom,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                //Image = ...
            };

            //heartAnimator = new MultiHeartAnimator(this, Properties.Resources.heart_filled);

            heartIcon.Click += HeartIcon_Click;
            this.Controls.Add(heartIcon);
        }

        private void HeartIcon_Click(object sender, EventArgs e)
        {
            isMemorized = !isMemorized;

            if (isMemorized)
            {
                // Đổi thành tim đỏ, tim đã ghi nhớ
                //heartIcon.Image = ...
                PlayHeartAnimation();
            }
            else
            {
                // Đổi thành tim trắng, tim chưa ghi nhớ
                //heartIcon.Image = ...
            }
        }
        /// <summary>
        /// Hàm chạy animation
        /// </summary>
        private void PlayHeartAnimation()
        {
            Point heartStartPoint = heartIcon.PointToScreen(Point.Empty);
            heartStartPoint = this.PointToClient(heartStartPoint);

            heartAnimator.Start(heartStartPoint, heartCount: 6); // 6 trái tim bay lên
        }

        #endregion



        #region Display Data



        private int expnadedHeight = 220; // Chiều cao mở rộng
        private int collapsedHeight = 50; // Chiều cao thu gọn


        private CustomGrammar _data;

        public CustomGrammar Data
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

        private int grammarId = -1;
        /// <summary>
        /// Load dữ liệu vào control
        /// </summary>
        private void updateDissplay()
        {
            // Lưu id của grammar để dễ xử lý data khi cần
            // Nếu cần thì có thể lưu vào database
            // hoặc lưu vào một biến tĩnh nào đó
            // Hoặc lấy id để xác định từ đã thuộc
            grammarId = _data.Id;

            // Cấu trúc
            lblStructure.Text = _data.Structure ?? "";
            lblSample.Text = _data.Sample ?? "";

            int currentTop = 10; // Bắt đầu từ vị trí trên cùng

            // Update từng label (có nội dung mới hiển thị)
            UpdateLabelAndLayout(lblExplain, _data.Explain, "Cách sử dụng", ref currentTop);
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

            //expnadedHeight = this.Height; // Cập nhật chiều cao mở rộng
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
                if (ctrl is Label label && label.Visible && label != lblStructure && label != lblSample )
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
            this.expnadedHeight = detailPanel.Bottom + 20; // Cập nhật chiều cao mới
        }

        #endregion

        #region Animation Expand/Collaspe detaiPanels

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

            // Tính chiều cao mới của detailPanel (bao gồm label + ảnh)
            int realContentHeight = detailPanel.Top + detailPanel.Height + 10;

            // Cập nhật chiều cao mở rộng dựa trên nội dung thực tế
            expnadedHeight = realContentHeight;

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
                    //this.Height = expnadedHeight;
                    animationTimer.Stop();
                    isExpanded = true;
                }
            }
        }

        #endregion

    }
}
