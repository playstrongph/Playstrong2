using System;
using ScriptableObjectScripts.ActionTargetAssets;
using ScriptableObjectScripts.BasicConditionAssets;
using ScriptableObjectScripts.StandardActionAssets;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace Logic
{
    public class LoadStatusEffectAsset : MonoBehaviour, ILoadStatusEffectAsset
    {

        private IStatusEffect _statusEffect;

        private void Awake()
        {
            _statusEffect = GetComponent<IStatusEffect>();
        }
        
        /// <summary>
        /// Load status effect asset values to status effect and create unique instances
        /// </summary>
        /// <param name="targetHero"></param>
        /// <param name="casterHero"></param>
        /// <param name="statusEffectAsset"></param>
        /// <param name="counters"></param>
        public void StartAction(IHero targetHero, IHero casterHero, IStatusEffectAsset statusEffectAsset, int counters)
        {
            _statusEffect.StatusEffectName = statusEffectAsset.StatusEffectName;
            _statusEffect.StatusEffectDescription = statusEffectAsset.Description;
            
            //For cleanup - counters value should be set by Add status effect action
            //_statusEffect.CountersValue = statusEffectAsset.CountersValue;
            
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
            
            //Creat unique status effect assets
            CreateUniqueStatusEffectAsset(statusEffectAsset);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusEffectAsset"></param>
        private void CreateUniqueStatusEffectAsset(IStatusEffectAsset statusEffectAsset)
        {
            //Replace with a unique instance
            _statusEffect.StatusEffectAsset = Instantiate(statusEffectAsset as ScriptableObject) as IStatusEffectAsset;

            CreateUniqueStandardActions();

            CreateUniqueBasicConditions();
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
        
        /// <summary>
        /// Create unique basic conditions
        /// </summary>
        private void CreateUniqueBasicConditions()
        {
            
            foreach (var statusEffectActionObject in  _statusEffect.StatusEffectAsset.StatusEffectActionObjects)
            {   
                //cast status effect action object as a standard action asset
                var standardAction = statusEffectActionObject as IStandardActionAsset;

                var i = 0;
                // ReSharper disable once PossibleNullReferenceException
                foreach (var basicCondition in standardAction.OrBasicConditions)
                {
                    //replace OR basic condition with a unique instance
                    var basicConditionObject = Instantiate(basicCondition as ScriptableObject);
                    standardAction.OrBasicConditionsScriptableObjects[i] = basicConditionObject;
                    
                    i++;
                }
                
                var j = 0;
                // ReSharper disable once PossibleNullReferenceException
                foreach (var basicCondition in standardAction.OrBasicConditions)
                {
                    //replace AND basic condition with a unique instance
                    var basicConditionObject = Instantiate(basicCondition as ScriptableObject);
                    standardAction.AndBasicConditionsScriptableObjects[j] = basicConditionObject;
                    
                    j++;
                }



            }
        }




    }
}
