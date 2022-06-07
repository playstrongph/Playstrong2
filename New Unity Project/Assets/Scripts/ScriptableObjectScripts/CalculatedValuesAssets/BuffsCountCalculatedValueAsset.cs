using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.CalculatedValuesAssets
{
    [CreateAssetMenu(fileName = "BuffsCountCalculatedValue", menuName = "Assets/CalculatedValues/BuffsCountCalculatedValue")]
    public class BuffsCountCalculatedValueAsset : CalculatedValueAsset
    {
        public override void GetCalculatedValue(IHero heroBasis)
        {
            CalculatedValue = heroBasis.HeroStatusEffects.BuffEffects.StatusEffects.Count;
        }
    }
}
