using System.IO;
using System.Linq;
using dnlib.DotNet;       
using SplashCreator.Core.Techniques;

namespace SplashCreator.Core.Helpers
{
    public class SplashCreator
    {
        public byte[] CreateSplash(string executablePath, SplashTechnique splashTechnique, object obj)
        {
            using (var module = ModuleDefMD.Load(executablePath))
            {
                var moduleType = module.Types.FirstOrDefault(type => type.IsGlobalModuleType);
                if (moduleType == null)
                    throw new InvalidDataException("Program does not have a global module.");
 
                splashTechnique.Inject(moduleType, module, obj);                        

                using (var stream = new MemoryStream())
                {
                    module.Write(stream);
                    return stream.ToArray();
                }
            }
        }                                                                                                  
    }
}