using System.Windows.Forms;

namespace SplashCreator.UI.Controls
{
    // Designer doesn't work for abstract inherited controls.
    public class SplashUserControl : UserControl
    {
        public virtual object GetSplashData()
        {
            return null;
        }
    }
}