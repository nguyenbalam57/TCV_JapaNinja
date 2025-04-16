using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCV_JapaNinja.Animations
{
    public class MultiHeartAnimator
    {
        private List<Heart> hearts = new List<Heart>();
        private Timer heartTimer;
        private Control parentControl;
        private Image heartImage;
        private Random random = new Random();

        public MultiHeartAnimator(Control parent, Image heartImg)
        {
            parentControl = parent;
            heartImage = heartImg;

            heartTimer = new Timer { Interval = 15 };
            heartTimer.Tick += HeartTimer_Tick;
        }

        public void Start(Point startLocation, int heartCount = 5)
        {
            for (int i = 0; i < heartCount; i++)
            {
                Heart heart = new Heart
                {
                    PictureBox = new PictureBox
                    {
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Size = new Size(24, 24),
                        Image = heartImage,
                        BackColor = Color.Transparent,
                        Location = startLocation
                    },
                    Opacity = 1.0f,
                    VelocityX = random.Next(-2, 3),
                    VelocityY = random.Next(-6, -3),
                    Rotation = random.Next(-5, 5)
                };
                hearts.Add(heart);
                parentControl.Controls.Add(heart.PictureBox);
                heart.PictureBox.BringToFront();
            }

            heartTimer.Start();
        }

        private void HeartTimer_Tick(object sender, EventArgs e)
        {
            for (int i = hearts.Count - 1; i >= 0; i--)
            {
                var heart = hearts[i];

                heart.PictureBox.Left += heart.VelocityX;
                heart.PictureBox.Top += heart.VelocityY;
                heart.VelocityY += 1; // Gravity effect
                heart.PictureBox.Width += 1;
                heart.PictureBox.Height += 1;

                heart.Opacity -= 0.02f;
                heart.PictureBox.Image = SetImageOpacity(heartImage, heart.Opacity);

                if (heart.Opacity <= 0)
                {
                    parentControl.Controls.Remove(heart.PictureBox);
                    hearts.RemoveAt(i);
                }
            }

            if (hearts.Count == 0)
                heartTimer.Stop();
        }

        private Image SetImageOpacity(Image image, float opacity)
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity;
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                g.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height),
                    0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }

        private class Heart
        {
            public PictureBox PictureBox;
            public float Opacity;
            public int VelocityX;
            public int VelocityY;
            public int Rotation;
        }
    }
}
