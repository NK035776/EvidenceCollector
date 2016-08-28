using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Diagnostics;

namespace EvidenceCollector
{
    public partial class frmScreenShot : Form
    {
        string screenShotPath = string.Empty;
        public frmScreenShot()
        {
            InitializeComponent();
            
        }

       

        private void captureButton_Click(object sender, EventArgs e)
        {
            captureButtonClick();
        }

        public void captureButtonClick()
        {
            screenShotPath = pathTextBox.Text;
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmapImage = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmapImage))
                {
                   g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                Bitmap tempBitmapImage = new Bitmap(bitmapImage);
                tempBitmapImage.Save(@pathTextBox.Text + ".png", ImageFormat.Png);
            }
        }

        public void buildButton_Click(object sender, EventArgs e)
        {
            //Process.Start("explorer.exe", @pathTextBox.Text);
            frmPreview objView = new frmPreview();
            objView.ShowDialog();
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", @pathTextBox.Text);
        }
    }
}
