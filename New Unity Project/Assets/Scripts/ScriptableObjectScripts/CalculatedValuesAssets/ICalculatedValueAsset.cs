using System.Collections.Generic;
using Logic;

namespace ScriptableObjectScripts.CalculatedValuesAssets
{
    public interface ICalculatedValueAsset
    {
        
        float CalculatedValue { get; set; }
        void GetCalculatedValue(IHero heroBasis);
        
        List<IHero> CalculatedHeroes { get; set; }

        List<IHero> GetCalculatedHeroList(IHero heroBasis);
    }
}