using System.IO;
using System.Linq;
using System.Reflection;
using dnlib.DotNet;
using SplashCreator.Core.Extensions;
using SplashCreator.Core.Helpers;

namespace SplashCreator.Core.Techniques
{
    public abstract class SplashTechnique
    {
        public string Name { get; set; }

        public ModuleDefMD ModuleDefMD { get; set; }

        protected SplashTechnique()
        {
            ModuleDefMD = ModuleDefMD.Load(Assembly.GetExecutingAssembly().Location);
        }

        public void Inject(TypeDef typeDef, ModuleDef targetModuleDef, object obj)
        {
            var splashTechniqueName = $"{typeof(SplashTechnique).Namespace}.{Name}Technique";

            var moduleType = ModuleDefMD.Types.FirstOrDefault(type => type.FullName == splashTechniqueName);
            if (moduleType == null)
                throw new InvalidDataException("Splash method is not available.");

            var constructorMethodDef = typeDef.FindOrCreateStaticConstructor();

            var injectionMethodDef = moduleType.FindMethod("Splash");
            var injectedMethodDef = InjectHelper.Inject(injectionMethodDef, targetModuleDef);
            constructorMethodDef.Body = injectedMethodDef.Body;

            AfterInjectionCallback(injectedMethodDef, obj);
        }

        public abstract void AfterInjectionCallback(MethodDef injectedMethodDef, object obj);

        public abstract void Splash();
    }
}
