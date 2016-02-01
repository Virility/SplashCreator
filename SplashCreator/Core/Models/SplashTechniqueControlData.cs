using System.Drawing;
using System.Windows.Forms;
using SplashCreator.Core.Techniques;
using SplashCreator.UI.Controls;

namespace SplashCreator.Core.Models
{
    public class SplashTechniqueControlDatum
    {
        public string Name { get; set; }

        public SplashTechnique Technique { get; set; }

        public SplashUserControl Control { get; set; }

        public SplashTechniqueControlDatum(SplashTechnique technique, SplashUserControl control)
        {
            Name = technique.Name;
            Technique = technique;
            Control = control;
            Control.Visible = false;
        }

        public void InvalidatePanelLocation(Form form, string techniqueName)
        {
            Control.Location = new Point(12, 68);
            Control.Size = new Size(form.Width - 40, form.Height - 119);
            Control.Anchor = 
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right |
                AnchorStyles.Bottom; 
            Control.Visible = (Name == techniqueName);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}