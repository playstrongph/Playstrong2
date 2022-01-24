using Logic;
using ScriptableObjectScripts.StatusEffectAssets;

namespace ScriptableObjectScripts.StatusEffectInstanceTypeAssets
{
    public interface IStatusEffectInstanceTypeAsset
    {
        /// <summary>
        /// Add a new status effect 
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="statusEffectAsset"></param>
        /// <param name="counters"></param>
        void AddStatusEffect(IHero hero, IStatusEffectAsset statusEffectAsset, int counters);
    }
}