using System.Collections;
using Logic;
using ScriptableObjectScripts.StatusEffectAssets;

namespace ScriptableObjectScripts.StatusEffectInstanceTypeAssets
{
    public interface IStatusEffectInstanceTypeAsset
    {
        /// <summary>
        /// Add a new status effect 
        /// </summary>
        /// <param name="targetHero"></param>
        /// /// <param name="casterHero"></param>
        /// <param name="statusEffectAsset"></param>
        /// <param name="counters"></param>
        void AddStatusEffect(IHero targetHero, IHero casterHero, IStatusEffectAsset statusEffectAsset, int counters);

    }
}