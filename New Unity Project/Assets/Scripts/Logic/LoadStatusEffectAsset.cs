using System;
using ScriptableObjectScripts.ActionTargetAssets;
using ScriptableObjectScripts.StandardActionAssets;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace Logic
{
    public class LoadStatusEffectAsset : MonoBehaviour
    {

        private IStatusEffect _statusEffect;

        private void Awake()
        {
            _statusEffect = GetComponent<IStatusEffect>();
        }

        private void StartAction(IHero targetHero, IHero casterHero, IStatusEffectAsset statusEffectAsset, int counters)
        {
            _statusEffect.StatusEffectName = statusEffectAsset.StatusEffectName;
            _statusEffect.StatusEffectDescription = statusEffectAsset.Description;
            _statusEffect.CountersValue = statusEffectAsset.CountersValue;
            _statusEffect.Icon.sprite = statusEffectAsset.Icon;
            
            _statusEffect.StatusEffectCasterHero = casterHero;
            _statusEffect.StatusEffectTargetHero = targetHero;

            //STATUS EFFECT ATTRIBUTES
            
            //Types - buff, debuff, unique status effect
            _statusEffect.StatusEffectType = statusEffectAsset.StatusEffectType;
            
            //Counters timing update - start or end turn
            _statusEffect.StatusEffectCounterUpdateType = statusEffectAsset.StatusEffectCounterUpdateType;
            
            //Instance types - singe or multiple
            _statusEffect.StatusEffectInstanceType = statusEffectAsset.StatusEffectInstanceType;
            
            //Change counters type - normal, immutable, no change
            _statusEffect.StatusEffectCounterType = statusEffectAsset.StatusEffectCounterType;
            
            //TODO: Create unique status effect values
        }

        private void CreateUniqueStatusEffectAsset(IStatusEffectAsset statusEffectAsset)
        {
            //Replace with a unique instance
            _statusEffect.StatusEffectAsset = Instantiate(statusEffectAsset as ScriptableObject) as IStatusEffectAsset;
            
            //TODO: Create unique standard actions
            CreateUniqueStandardActions();

            //TODO: Create unique basic conditions
        }
        
        /// <summary>
        /// Creates unique object instances of standard action, 
        /// </summary>
        private void CreateUniqueStandardActions()
        {
            var i = 0;

            foreach (var statusEffectAction in _statusEffect.StatusEffectAsset.StatusEffectActions)
            {
                //Create a unique instance of standard action
                var standardAction = Instantiate(statusEffectAction as ScriptableObject) as IStandardActionAsset;
                
                //replace the status effect actions with unique clones
                _statusEffect.StatusEffectAsset.StatusEffectActionObjects[i] = standardAction as ScriptableObject;

                // ReSharper disable once PossibleNullReferenceException
                //Create a unique instance of action targets
                standardAction.BasicActionTargets =
                        Instantiate(standardAction.BasicActionTargets as ScriptableObject) as IActionTargetAsset;

                // ReSharper disable once PossibleNullReferenceException
                //Initialize caster hero reference
                standardAction.BasicActionTargets.InitializeStatusEffectCasterHero(_statusEffect);
                
                //Create unique instance of subscribers
                standardAction.Subscribers = Instantiate(standardAction.Subscribers as ScriptableObject) as IActionTargetAsset;
                
                // ReSharper disable once PossibleNullReferenceException
                //Initialize caster hero reference
                standardAction.Subscribers.InitializeStatusEffectCasterHero(_statusEffect);

                i++;
            }
        }
        
        


    }
}
