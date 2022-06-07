using Logic;

namespace ScriptableObjectScripts.CalculatedValuesAssets
{
    public interface ICalculatedValueAsset
    {
        
        float CalculatedValue { get; set; }
        void GetCalculatedValue(IHero heroBasis);
    }
}