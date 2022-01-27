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
            
            //Load status effect values from status effect asset
            statusEffect.LoadStatusEffectAsset.StartAction(targetHero, casterHero, statusEffectAsset, counters);
            
            //Add to status effects list
            statusEffect.StatusEffectType.AddToStatusEffectsList(targetHero.HeroStatusEffects, statusEffect);
            
            //Apply status effect
            statusEffect.StatusEffectAsset.ApplyAction(targetHero);
            
            //Create status effect preview
            CreateStatusEffectPreview(targetHero,statusEffectAsset,statusEffect);

            //TODO:: Temporary no decrease if status effect target is also the caster hero this turn

            return statusEffect;
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
        
        /// <summary>
        /// Creates and loads the status effect preview
        /// </summary>
        private void CreateStatusEffectPreview(IHero targetHero, IStatusEffectAsset statusEffectAsset, IStatusEffect statusEffect)
        {
            var previewPrefab = targetHero.HeroStatusEffects.PreviewStatusEffectPrefab.ThisGameObject;
            var previewParent = targetHero.HeroPreview.PreviewStatusEffects.transform;

            var previewObject = Instantiate(previewPrefab, previewParent);
            var previewStatusEffect = previewObject.GetComponent<IPreviewStatusEffect>();
            
            //Load preview status effect values
            previewStatusEffect.LoadPreviewStatusEffectAsset.StartAction(statusEffectAsset);

            //Set status effect reference to status effect preview
            statusEffect.PreviewStatusEffect = previewStatusEffect;

        }


    }
}
