using System.Collections;
using Logic;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectInstanceTypeAssets
{
    public abstract class StatusEffectInstanceTypeAsset : ScriptableObject, IStatusEffectInstanceTypeAsset
    {
        private IStatusEffect _newStatusEffect = null;
        
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
        protected void CreateStatusEffect(IHero targetHero, IHero casterHero, IStatusEffectAsset statusEffectAsset, int counters)
        {
            CreateStatusEffectVisual(targetHero, casterHero, statusEffectAsset, counters);
            CreateStatusEffectPreview(targetHero, statusEffectAsset);
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
                _newStatusEffect.UpdateStatusEffectCastingStatus.SetFreshCastStatus();
            else
                _newStatusEffect.UpdateStatusEffectCastingStatus.SetOldCastStatus();
            
            //Remove status effect if counters are less than or equal to zero
            if(_newStatusEffect.CountersValue <=0)
                _newStatusEffect.RemoveStatusEffect.StartAction(targetHero);
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
        private void CreateStatusEffectVisual(IHero targetHero, IHero casterHero, IStatusEffectAsset statusEffectAsset, int counters)
        {
            var statusEffectPrefab = targetHero.HeroStatusEffects.StatusEffectPrefab;

            //Instantiate status effect game object
            var statusEffectObject = Instantiate(statusEffectPrefab.ThisGameObject,
                targetHero.HeroStatusEffects.StatusEffectsCanvas.transform);

            //This is the new status effect
            _newStatusEffect = statusEffectObject.GetComponent<IStatusEffect>();
            
            //Load status effect values from status effect asset
            _newStatusEffect.LoadStatusEffectAsset.StartAction(targetHero, casterHero, statusEffectAsset, counters);

            //Add to status effects list
            _newStatusEffect.StatusEffectType.AddToStatusEffectsList(targetHero.HeroStatusEffects, _newStatusEffect);
            
            //Subscribe Status Effect Asset
            _newStatusEffect.StatusEffectAsset.SubscribeAction(targetHero);
            
            //Apply Status effect asset basic actions
            //TODO: TargetHero, TargetHero fix
            _newStatusEffect.StatusEffectAsset.ApplyAction(targetHero,targetHero);

            //Set status effect casting status
            if(targetHero==casterHero)
                _newStatusEffect.UpdateStatusEffectCastingStatus.SetFreshCastStatus();
            else
                _newStatusEffect.UpdateStatusEffectCastingStatus.SetOldCastStatus();
            
           
            //Remove status effect if counters are less than or equal to zero
            if(_newStatusEffect.CountersValue <=0)
                _newStatusEffect.RemoveStatusEffect.StartAction(targetHero);

        }


        /// <summary>
        /// Creates the status effect preview game object
        /// </summary>
        /// <param name="targetHero"></param>
        /// <param name="statusEffectAsset"></param>
        /// <returns></returns>
        private void CreateStatusEffectPreview(IHero targetHero, IStatusEffectAsset statusEffectAsset)
        {
            var previewPrefab = targetHero.HeroStatusEffects.PreviewStatusEffectPrefab.ThisGameObject;
            var previewParent = targetHero.HeroPreview.PreviewStatusEffects.transform;

            var previewObject = Instantiate(previewPrefab, previewParent);

            //Set status effect preview reference
            _newStatusEffect.PreviewStatusEffect = previewObject.GetComponent<IPreviewStatusEffect>();

            //Load preview status effect values
            _newStatusEffect.PreviewStatusEffect.UpdatePreviewStatusEffect(statusEffectAsset);
        }



    }

}
