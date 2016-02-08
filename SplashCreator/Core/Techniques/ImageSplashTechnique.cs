using System;                    
using System.Drawing;
using System.Linq;                     
using System.Windows.Forms;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using SplashCreator.Core.Helpers;

namespace SplashCreator.Core.Techniques
{
    public class ImageSplashTechnique : SplashTechnique
    {
        private InitializedDataCreator _dataCreator;

        public ImageSplashTechnique()
        {
            Name = "ImageSplash";                      
        }

        public override void Splash()
        {
            byte[] imageBytes = null;

            using (var imageStream = new System.IO.MemoryStream())
            {
                imageStream.Write(imageBytes, 0, imageBytes.Length);

                using (var image = Image.FromStream(imageStream))
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
                    Text = @"ReplaceMe1"
                })
                {
                    displayForm.ShowDialog();
                }
            }
        }

        private byte[] GetImageAsByteArray(Image image)
        {                             
            if (image == null)
                throw new NullReferenceException(nameof(image));

            var converter = new ImageConverter();
            return converter.ConvertTo(image, typeof(byte[])) as byte[];
        }

        private bool ReplaceFormText(Instruction currentInstruction, string replacementText)
        {
            if (currentInstruction.Operand == null)
                return false;

            if (currentInstruction.Operand.ToString() != "ReplaceMe1")
                return false;

            currentInstruction.Operand = replacementText;
            return true;
        }

        public Instruction[] GetNewByteArrayInstructions(MethodDef methodDef, byte[] data)
        {
            var elementType = methodDef.Module.CorLibTypes.Byte.TypeDefOrRef;

            return new []
            {                            
                OpCodes.Ldc_I4.ToInstruction(data.Length / elementType.ToTypeSig().ElementType.GetPrimitiveSize()),
                OpCodes.Newarr.ToInstruction(elementType),
                OpCodes.Dup.ToInstruction(),
                OpCodes.Ldtoken.ToInstruction(_dataCreator.Create(data)),
                OpCodes.Call.ToInstruction(_dataCreator.CreateInitializeArrayMethod())
            };
        }

        private bool ReplaceImageByteArray(MethodDef injectedMethodDef, 
            Instruction currentInstruction, int instructionIndex, Image replacementImage)
        {
            if (currentInstruction.OpCode != OpCodes.Ldnull)
                return false;
                               
            var operand = injectedMethodDef.Body.Instructions[instructionIndex + 2].Operand;
            if (operand == null)
                return false;
                                                                       
            if (!operand.ToString().Contains("MemoryStream"))
                return false;

            injectedMethodDef.Body.Instructions.RemoveAt(1);

            var imageBytes = GetImageAsByteArray(replacementImage);
            var newInstructions = GetNewByteArrayInstructions(injectedMethodDef, imageBytes);

            for (var injectionIndex = instructionIndex; injectionIndex < instructionIndex + newInstructions.Length; injectionIndex++)                  
                injectedMethodDef.Body.Instructions.Insert(injectionIndex, newInstructions[injectionIndex - instructionIndex]);                                                                                                
                                                         
            return true;                     
        }

        public override void AfterInjectionCallback(MethodDef injectedMethodDef, object obj)
        {       
            _dataCreator = new InitializedDataCreator(injectedMethodDef.Module);

            var objArray = obj as object[];
            if (objArray == null)
                throw new NullReferenceException(nameof(objArray));

            var text = objArray[0] as string;
            var image = objArray[1] as Image;

            var replacedText = false;
            var replacedImage = false;

            var instructions = injectedMethodDef.Body.Instructions.ToArray();
            for (var instructionIndex = 0; instructionIndex < instructions.Length; instructionIndex++)
            {
                var instruction = instructions[instructionIndex];
                if (!replacedText)
                    replacedText = ReplaceFormText(instruction, text);
          
                if (!replacedImage)
                    replacedImage = ReplaceImageByteArray(injectedMethodDef, instruction, instructionIndex, image);
                                                             
                if (replacedText && replacedImage)
                    break;
            }
        }  
    }
}             