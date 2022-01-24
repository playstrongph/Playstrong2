using Logic;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectInstanceTypeAssets
{
    public abstract class StatusEffectInstanceTypeAsset : ScriptableObject
    {
        /// <summary>
        /// Add a new status effect 
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="statusEffectAsset"></param>
        /// <param name="counters"></param>
        public virtual void AddStatusEffect(IHero hero, IStatusEffectAsset statusEffectAsset, int counters)
        {
            
        }
        
        /// <summary>
        /// Create a new status effect
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="statusEffectAsset"></param>
        /// <param name="counters"></param>
        /// <returns></returns>
        protected IStatusEffect CreateStatusEffect(IHero hero, IStatusEffectAsset statusEffectAsset, int counters)
        {
            //TODO: put logic here
            return null;
        }
        
        /// <summary>
        /// Update the counters of an existing status effect 
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="existingStatusEffect"></param>
        /// <param name="statusEffectAsset"></param>
        /// <param name="counters"></param>
        /// <returns></returns>
        protected IStatusEffect UpdateStatusEffect(IHero hero, IStatusEffect existingStatusEffect, IStatusEffectAsset statusEffectAsset, int counters)
        {
            //TODO: put logic here
            return null;
        }
        
        
    }
}
