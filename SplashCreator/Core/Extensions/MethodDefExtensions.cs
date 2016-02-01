using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace SplashCreator.Core.Extensions
{
    public static class MethodDefExtensions
    {           
        public static void AddInstructions(this MethodDef methodDef, IEnumerable<Instruction> instructions)
        {
            foreach (var instruction in instructions)
                methodDef.Body.Instructions.Add(instruction);
        }
    }
}         