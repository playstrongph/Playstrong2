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

        public virtual int AddStatusEffectNetChance(IHero casterHero, IHero targetHero, int defaultChance)
        {
            return 0;
        }


    }
}
