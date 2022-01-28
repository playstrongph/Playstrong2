using System.Collections;
using Logic;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectInstanceTypeAssets
{
    public abstract class StatusEffectInstanceTypeAsset : ScriptableObject, IStatusEffectInstanceTypeAsset
    {

        protected IStatusEffect NewStatusEffect;
        
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
        protected IEnumerator CreateStatusEffect(IHero targetHero, IHero casterHero, IStatusEffectAsset statusEffectAsset, int counters)
        {

            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            var visualTree = targetHero.CoroutineTrees.MainVisualTree;
            
            visualTree.AddCurrent(CreateStatusEffectVisual(targetHero,casterHero,statusEffectAsset,counters));

            logicTree.EndSequence();
            yield return null;

        }
        
        /// <summary>
        /// Update the counters of an existing status effect
        /// Set SetCountersToValue already contains the visual trees
        /// </summary>
        /// <param name="targetHero"></param>
        /// <param name="casterHero"></param>
        /// <param name="existingStatusEffect"></param>
        /// <param name="statusEffectAsset"></param>
        /// <param name="counters"></param>
        /// <returns></returns>
        protected void UpdateStatusEffect(IHero targetHero, IHero casterHero, IStatusEffect existingStatusEffect, IStatusEffectAsset statusEffectAsset, int counters)
        {
            var newCounters = Mathf.Max(existingStatusEffect.CountersValue, counters);
            
            //Update the existing status effect counters
            existingStatusEffect.UpdateStatusEffectCounters.SetCountersToValue(newCounters);
            
            //Update the status effect caster hero
            existingStatusEffect.StatusEffectCasterHero = casterHero;

            //TODO:: Temporary no decrease if status effect target is also the caster hero this turn
        }
        
        /// <summary>
        /// Checks if the new status effect to be added is already existing and calls either create or update status effect respectively 
        /// </summary>
        /// <param name="targetHero"></param>
        /// <param name="statusEffectAsset"></param>
        /// <returns></returns>
        protected IStatusEffect CheckForExistingStatusEffect(IHero targetHero, IStatusEffectAsset statusEffectAsset)
        {
            //Check all buffs
            foreach (var buff in targetHero.HeroStatusEffects.BuffEffects.StatusEffects)
            {
                if (statusEffectAsset.StatusEffectName == buff.StatusEffectName)
                    return buff;
            }
            
            //Check all debuffs
            foreach (var debuff in targetHero.HeroStatusEffects.DebuffEffects.StatusEffects)
            {
                if (statusEffectAsset.StatusEffectName == debuff.StatusEffectName)
                    return debuff;
            }
            
            //Check all unique status effects
            foreach (var uniqueStatusEffect in targetHero.HeroStatusEffects.UniqueStatusEffects.StatusEffects)
            {
                if (statusEffectAsset.StatusEffectName == uniqueStatusEffect.StatusEffectName)
                    return uniqueStatusEffect;
            }

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
        
        /// <summary>
        /// Visual tree queueing for create status effect
        /// </summary>
        /// <param name="targetHero"></param>
        /// <param name="casterHero"></param>
        /// <param name="statusEffectAsset"></param>
        /// <param name="counters"></param>
        /// <returns></returns>
        private IEnumerator CreateStatusEffectVisual(IHero targetHero, IHero casterHero, IStatusEffectAsset statusEffectAsset, int counters)
        {
            var visualTree = targetHero.CoroutineTrees.MainVisualTree;
            var statusEffectPrefab = targetHero.HeroStatusEffects.StatusEffectPrefab;
            
            //Instantiate status effect game object
            var statusEffectObject = Instantiate(statusEffectPrefab.ThisGameObject,
                targetHero.HeroStatusEffects.StatusEffectsCanvas.transform);

            //This is the new status effect
            NewStatusEffect = statusEffectObject.GetComponent<IStatusEffect>();
            
            //Load status effect values from status effect asset
            NewStatusEffect.LoadStatusEffectAsset.StartAction(targetHero, casterHero, statusEffectAsset, counters);
            
            //Add to status effects list
            NewStatusEffect.StatusEffectType.AddToStatusEffectsList(targetHero.HeroStatusEffects, NewStatusEffect);
            
            //Apply status effect
            NewStatusEffect.StatusEffectAsset.ApplyAction(targetHero);
            
            //Create status effect preview
            CreateStatusEffectPreview(targetHero,statusEffectAsset,NewStatusEffect);

            //TODO:: Temporary no decrease if status effect target is also the caster hero this turn
            
            visualTree.EndSequence();
            yield return null;

        }


    }
}
