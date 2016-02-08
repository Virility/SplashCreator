using System.IO;
using System.Linq;
using System.Reflection;
using dnlib.DotNet;
using SplashCreator.Core.Helpers;

namespace SplashCreator.Core.Techniques
{
    public abstract class SplashTechnique
    {
        public string Name { get; set; }

        public ModuleDef ModuleDef { get; set; }

        protected SplashTechnique()
        {
            ModuleDef = ModuleDefMD.Load(Assembly.GetExecutingAssembly().Location);
        }

        public void Inject(TypeDef typeDef, ModuleDef targetModuleDef, object obj)
        {
            var splashTechniqueName = $"{typeof(SplashTechnique).Namespace}.{Name}Technique";

            var moduleType = ModuleDef.Types.FirstOrDefault(type => type.FullName == splashTechniqueName);
            if (moduleType == null)
                throw new InvalidDataException("Splash method is not available.");

            var injectionMethodDef = moduleType.FindMethod("Splash");
            var injectedMethodDef = InjectHelper.Inject(injectionMethodDef, targetModuleDef);

            var constructorMethodDef = typeDef.FindOrCreateStaticConstructor();
            constructorMethodDef.Body = injectedMethodDef.Body;

            AfterInjectionCallback(constructorMethodDef, obj);
        }

        public abstract void AfterInjectionCallback(MethodDef injectedMethodDef, object obj);

        public abstract void Splash();
    }
}