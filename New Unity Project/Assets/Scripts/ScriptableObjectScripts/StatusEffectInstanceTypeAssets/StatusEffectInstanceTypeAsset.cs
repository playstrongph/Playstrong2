using System.Collections;
using Logic;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectInstanceTypeAssets
{
    public abstract class StatusEffectInstanceTypeAsset : ScriptableObject, IStatusEffectInstanceTypeAsset
    {

        protected IStatusEffect NewStatusEffect = null;
        
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
            
            //Create the status effect
            visualTree.AddCurrent(CreateStatusEffectVisual(targetHero,casterHero,statusEffectAsset,counters));
            
            //Create the status effect preview
            visualTree.AddCurrent(CreateStatusEffectPreview(targetHero, statusEffectAsset));
           

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

            //Set status effect casting status
            if(targetHero==casterHero)
                NewStatusEffect.UpdateStatusEffectCastingStatus.SetFreshCastStatus();
            else
                NewStatusEffect.UpdateStatusEffectCastingStatus.SetOldCastStatus();
            
            //Remove status effect if counters are less than or equal to zero
            if(NewStatusEffect.CountersValue <=0)
                NewStatusEffect.RemoveStatusEffect.StartAction(targetHero);
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

            //Set status effect casting status
            if(targetHero==casterHero)
                NewStatusEffect.UpdateStatusEffectCastingStatus.SetFreshCastStatus();
            else
                NewStatusEffect.UpdateStatusEffectCastingStatus.SetOldCastStatus();
            
           
            //Remove status effect if counters are less than or equal to zero
            if(NewStatusEffect.CountersValue <=0)
                NewStatusEffect.RemoveStatusEffect.StartAction(targetHero);
            
            
            
            visualTree.EndSequence();
            yield return null;

        }
        
        
        /// <summary>
        /// Creates the status effect preview game object
        /// </summary>
        /// <param name="targetHero"></param>
        /// <param name="statusEffectAsset"></param>
        /// <returns></returns>
        private IEnumerator CreateStatusEffectPreview(IHero targetHero, IStatusEffectAsset statusEffectAsset)
        {
            var visualTree = targetHero.CoroutineTrees.MainVisualTree;
            
            var previewPrefab = targetHero.HeroStatusEffects.PreviewStatusEffectPrefab.ThisGameObject;
            var previewParent = targetHero.HeroPreview.PreviewStatusEffects.transform;

            var previewObject = Instantiate(previewPrefab, previewParent);

            //Set status effect preview reference
            NewStatusEffect.PreviewStatusEffect = previewObject.GetComponent<IPreviewStatusEffect>();

            //Load preview status effect values
            NewStatusEffect.PreviewStatusEffect.UpdatePreviewStatusEffect(statusEffectAsset);

            visualTree.EndSequence();
            yield return null;
        }



    }

}
