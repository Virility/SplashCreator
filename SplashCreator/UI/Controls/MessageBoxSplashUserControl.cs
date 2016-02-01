namespace SplashCreator.UI.Controls
{
    public partial class MessageBoxSplashUserControl : SplashUserControl
    {
        public MessageBoxSplashUserControl()
        {
            InitializeComponent();
        }

        public override object GetSplashData()
        {
            return tbMessage.Text;
        }
    }
}    