using Logic;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectInstanceTypeAssets
{
    public abstract class StatusEffectInstanceTypeAsset : ScriptableObject, IStatusEffectInstanceTypeAsset
    {
        /// <summary>
        /// Add a new status effect 
        /// </summary>
        /// <param name="targetHero"></param>
        /// <param name="casterHero"></param>
        /// <param name="statusEffectAsset"></param>
        /// <param name="counters"></param>
        public virtual void AddStatusEffect(IHero targetHero, IHero casterHero, IStatusEffectAsset statusEffectAsset, int counters)
        {
            
        }
        
        /// <summary>
        /// Create a new status effect
        /// </summary>
        /// <param name="targetHero"></param>
        /// <param name="casterHero"></param>
        /// <param name="statusEffectAsset"></param>
        /// <param name="counters"></param>
        /// <returns></returns>
        protected IStatusEffect CreateStatusEffect(IHero targetHero, IHero casterHero, IStatusEffectAsset statusEffectAsset, int counters)
        {
            //TODO: put logic here

            var statusEffectPrefab = targetHero.HeroStatusEffects.StatusEffectPrefab;
            
            //Instantiate status effect game object
            var statusEffectObject = Instantiate(statusEffectPrefab.ThisGameObject,
                targetHero.HeroStatusEffects.StatusEffectsCanvas.transform);

            //This is the new status effect
            var statusEffect = statusEffectObject.GetComponent<IStatusEffect>();
            
            //TODO: Load status effect values from status effect asset
            



            return null;
        }
        
        /// <summary>
        /// Update the counters of an existing status effect 
        /// </summary>
        /// <param name="targetHero"></param>
        /// <param name="casterHero"></param>
        /// <param name="existingStatusEffect"></param>
        /// <param name="statusEffectAsset"></param>
        /// <param name="counters"></param>
        /// <returns></returns>
        protected IStatusEffect UpdateStatusEffect(IHero targetHero, IHero casterHero, IStatusEffect existingStatusEffect, IStatusEffectAsset statusEffectAsset, int counters)
        {
            //TODO: put logic here
            return null;
        }
        
        /// <summary>
        /// Checks if the new status effect to be added is already existing and calls either create or update status effect respectively 
        /// </summary>
        /// <param name="targetHero"></param>
        /// <param name="casterHero"></param>
        /// <param name="newStatusEffect"></param>
        /// <returns></returns>
        protected IStatusEffect CheckForExistingStatusEffect(IHero targetHero, IHero casterHero, IStatusEffect newStatusEffect)
        {
            //TODO: put logic here
            return null;
        }
        
        
        
        
    }
}
