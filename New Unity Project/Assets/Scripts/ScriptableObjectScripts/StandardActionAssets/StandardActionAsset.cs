using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.ActionTargetAssets;
using ScriptableObjectScripts.BasicConditionAssets;
using ScriptableObjectScripts.BasicEventAssets;
using UnityEngine;

namespace ScriptableObjectScripts.StandardActionAssets
{
    /// <summary>
    /// Base class for SkillActionAsset and StatusEffectActionAsset
    /// </summary>
    public abstract class StandardActionAsset : ScriptableObject, IStandardActionAsset
    {
        /// <summary>
        /// Set in the inspector but 
        /// is only used locally in the class
        /// </summary>
        [SerializeField] private ScriptableObject basicEvent;
        private IBasicEventAsset BasicEvent
        {
            get => basicEvent as IBasicEventAsset;
            set => basicEvent = value as ScriptableObject;
        }
        
        /// <summary>
        /// Hero subscribers to the basic events
        /// </summary>
        [SerializeField] private ScriptableObject subscribers;
        public IActionTargetAsset Subscribers
        {
            get => subscribers as IActionTargetAsset;
            private set => subscribers = value as ScriptableObject;
        }
        
        /// <summary>
        /// Hero targets used in the basic condition logic
        /// </summary>
        [SerializeField] private ScriptableObject basicConditionTargets;
        public IActionTargetAsset BasicConditionTargets
        {
            get => basicConditionTargets as IActionTargetAsset;
            private set => basicConditionTargets = value as ScriptableObject;
        }
        
        
        /// <summary>
        /// List of basic conditions in 'OR' logic configuration
        /// Returns orBasicConditions as list of basic condition assets
        /// </summary>
        [SerializeField] private List<ScriptableObject> orBasicConditions = new List<ScriptableObject>();
        public List<IBasicConditionAsset> OrBasicConditions
        {
            get
            {
                var basicConditions = new List<IBasicConditionAsset>();
                foreach (var basicConditionObject in orBasicConditions)
                {
                    var basicCondition = basicConditionObject as IBasicConditionAsset;
                    basicConditions.Add(basicCondition);
                }
                return basicConditions;
            }
        }
        
        /// <summary>
        /// Used in creating unique basic conditions
        /// Returns orBasicConditions as list of scriptable objects
        /// </summary>
        public List<ScriptableObject> OrBasicConditionsScriptableObjects => orBasicConditions;


        /// <summary>
        /// List of basic conditions in 'And' logic configuration
        /// Returns andBasicConditions as list of basic condition assets
        /// </summary>
        [SerializeField] private List<ScriptableObject> andBasicConditions = new List<ScriptableObject>();
        public List<IBasicConditionAsset> AndBasicConditions
        {
            get
            {
                var basicConditions = new List<IBasicConditionAsset>();
                foreach (var basicConditionObject in andBasicConditions)
                {
                    var basicCondition = basicConditionObject as IBasicConditionAsset;
                    basicConditions.Add(basicCondition);
                }
                return basicConditions;
            }
        }
        
        /// <summary>
        /// Used in creating unique basic conditions
        /// Returns andBasicConditions as list of scriptable objects
        /// </summary>
        public List<ScriptableObject> AndBasicConditionsScriptableObjects => orBasicConditions;
        
        
        
        
        
        
        
        
        






        /// <summary>
        /// Base method for actions execution
        /// </summary>
        /// <param name="hero"></param>
        public virtual void StartAction(IHero hero)
        {
            
        }
    }
}
