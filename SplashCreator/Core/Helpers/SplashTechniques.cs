using System.Collections.Generic;  
using SplashCreator.Core.Models;
using SplashCreator.Core.Techniques;
using SplashCreator.UI.Controls;

namespace SplashCreator.Core.Helpers
{
    public static class SplashTechniques
    {
        public static readonly Dictionary<string, SplashTechniqueControlDatum> TechniqueData;
             
        static SplashTechniques()
        {
            var techniques = new List<SplashTechniqueControlDatum>
            {
                new SplashTechniqueControlDatum(new MessageBoxSplashTechnique(), new MessageBoxSplashUserControl()),
                new SplashTechniqueControlDatum(new ImageSplashTechnique(), new ImageSplashUserControl()),
            };                  

            TechniqueData = new Dictionary<string, SplashTechniqueControlDatum>();
            foreach (var technique in techniques)
                TechniqueData.Add(technique.Name, technique);
        }

        public static SplashTechnique GetSplashTechnique(string name)
        {
            return GetSplashTechniqueDatum(name).Technique;
        }   

        public static SplashTechniqueControlDatum GetSplashTechniqueDatum(string name)
        {
            return TechniqueData[name];
        }
    }
} 