using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace SplashCreator.Core.Techniques
{
    public class ImageSplashTechnique : SplashTechnique
    {
        public ImageSplashTechnique()
        {
            Name = "ImageSplash";
        }

        public override void Splash()
        {                            
            var imageBytes = Convert.FromBase64String("ReplaceMe1");
            var imageConverter = new ImageConverter();
                                                  
            using (var image = imageConverter.ConvertFrom(imageBytes) as Image)
            using (var displayForm = new Form
            {
                Width = 500,
                Height = 340,
                TopMost = true,
                BackColor = Color.Black,
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedToolWindow,
                BackgroundImage = image,
                BackgroundImageLayout = ImageLayout.None,
                Text = @"ReplaceMe2"
            })
            {              
                displayForm.ShowDialog();
            }                             
        }

        private string GetImageAsBase64String(Image image)
        {                             
            if (image == null)
                throw new NullReferenceException(nameof(image));

            var converter = new ImageConverter();
            var imageBytes = converter.ConvertTo(image, typeof(byte[])) as byte[];
            if (imageBytes == null)
                throw new NullReferenceException(nameof(imageBytes));

            return Convert.ToBase64String(imageBytes, Base64FormattingOptions.InsertLineBreaks);
        }

        public override void AfterInjectionCallback(MethodDef injectedMethodDef, object obj)
        {
            var objArray = obj as object[];        
            if (objArray == null)
                throw new NullReferenceException(nameof(objArray));

            foreach (var instruction in injectedMethodDef.Body.Instructions.
                Where(instruction => instruction.OpCode == OpCodes.Ldstr))
            {
                switch (instruction.Operand.ToString())
                {
                    case "ReplaceMe1":           
                        instruction.Operand = GetImageAsBase64String(objArray[1] as Image);
                        break;
                    case "ReplaceMe2":
                        instruction.Operand = objArray[0] as string;
                        break;
                }
            }
        }  
    }
}  
