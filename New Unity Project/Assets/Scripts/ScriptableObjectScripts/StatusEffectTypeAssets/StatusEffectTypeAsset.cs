using Logic;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectTypeAssets
{
    public abstract class StatusEffectTypeAsset : ScriptableObject, IStatusEffectTypeAsset
    {
        /// <summary>
        /// Add to the specific status effect list - i.e. buff, debuff, unique status effects
        /// </summary>
        /// <param name="heroStatusEffects"></param>
        /// <param name="heroStatusEffect"></param>
        public virtual void AddToStatusEffectsList(IHeroStatusEffects heroStatusEffects, IStatusEffect heroStatusEffect)
        {
            
        }
        
        /// <summary>
        /// Remove from the specific status effect list - i.e. buff, debuff, unique status effects
        /// </summary>
        /// <param name="heroStatusEffects"></param>
        /// <param name="heroStatusEffect"></param>
        public virtual void RemoveFromStatusEffectsList(IHeroStatusEffects heroStatusEffects, IStatusEffect heroStatusEffect)
        {
            
        }
        
        /// <summary>
        /// Used by AddStatusEffect asset to add status effects based on type
        /// </summary>
        public virtual void AddTypeOfStatusEffect(IStatusEffectAsset statusEffectAsset, IHero casterHero,IHero targetHero, int defaultChance, int counters)
        {
            
        }


    }
}
