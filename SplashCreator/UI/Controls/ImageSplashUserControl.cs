using System.Windows.Forms;

namespace SplashCreator.UI.Controls
{
    public partial class ImageSplashUserControl : SplashUserControl
    {
        public ImageSplashUserControl()
        {
            InitializeComponent();
        }

        public override object GetSplashData()
        {
            return new object[] {tbFormText.Text, pbImage.Image};
        }

        private void pbImage_DoubleClick(object sender, System.EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    pbImage.ImageLocation = dialog.FileName;
            }
        }
    }
}   