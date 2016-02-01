using System.Linq;           
using System.Windows.Forms;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace SplashCreator.Core.Techniques
{
    public class MessageBoxSplashTechnique : SplashTechnique
    {
        public MessageBoxSplashTechnique()
        {
            Name = "MessageBoxSplash";                          
        }

        public override void AfterInjectionCallback(MethodDef injectedMethodDef, object obj)
        {
            var replaceMeStringInstruction = injectedMethodDef.Body.Instructions.FirstOrDefault(instruction =>
                instruction.OpCode == OpCodes.Ldstr && instruction.Operand.ToString() == "ReplaceMe");

            if (replaceMeStringInstruction != null)
                replaceMeStringInstruction.Operand = obj;
        }

        public override void Splash()
        {
            MessageBox.Show(@"ReplaceMe"); 
        } 
    }
}    