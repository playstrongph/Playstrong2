using System.Collections;
using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.ActionTargetAssets;
using ScriptableObjectScripts.BasicActionAssets;
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
        #region VARIABLES AND PROPERTIES

        /// <summary>
        /// Set in the inspector but 
        /// is only used locally in the class
        /// </summary>
        [Header("BASIC EVENT COMPONENTS")]
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IBasicEventAsset))] private ScriptableObject basicEvent;
        private IBasicEventAsset BasicEvent
        {
            get => basicEvent as IBasicEventAsset;
            set => basicEvent = value as ScriptableObject;
        }
        
        /// <summary>
        /// Hero subscribers to the basic events
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IActionTargetAsset))] private ScriptableObject subscribers;
        public IActionTargetAsset Subscribers
        {
            get => subscribers as IActionTargetAsset;
            set => subscribers = value as ScriptableObject;
        }
        
        
        /// <summary>
        /// Hero targets used in the basic condition logic
        /// </summary>
        [Header("BASIC CONDITION COMPONENTS")]
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IActionTargetAsset))]private ScriptableObject basicConditionTargets;
        public IActionTargetAsset BasicConditionTargets
        {
            get => basicConditionTargets as IActionTargetAsset;
            set => basicConditionTargets = value as ScriptableObject;
        }
        
        
        /// <summary>
        /// List of basic conditions in 'OR' logic configuration
        /// Returns orBasicConditions as list of basic condition assets
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IBasicConditionAsset))]private List<ScriptableObject> orBasicConditions = new List<ScriptableObject>();
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
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IBasicConditionAsset))]private List<ScriptableObject> andBasicConditions = new List<ScriptableObject>();
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
        public List<ScriptableObject> AndBasicConditionsScriptableObjects => andBasicConditions;
        
        
        /// <summary>
        /// Heroes used ion basic action logic
        /// </summary>
        [Header("BASIC ACTION COMPONENTS")]
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IActionTargetAsset))]private ScriptableObject basicActionTargets;
        public IActionTargetAsset BasicActionTargets
        {
            get => basicActionTargets as IActionTargetAsset;
            set => basicActionTargets = value as ScriptableObject;
        }
        
        /// <summary>
        /// List of basic actions used in the standard action
        /// Only used locally
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IBasicActionAsset))]private List<ScriptableObject> basicActions = new List<ScriptableObject>();
        private List<IBasicActionAsset> BasicActions
        {
            get
            {
                var newBasicActions = new List<IBasicActionAsset>();
                foreach (var basicActionObject in basicActions)
                {
                    var basicAction = basicActionObject as IBasicActionAsset;
                    newBasicActions.Add(basicAction);
                }

                return newBasicActions;
            }
        }
        
        
        /// <summary>
        /// AllAndBasicConditionsValue accumulator
        /// </summary>
        private int _finalAndConditionsValue;
        
        /// <summary>
        /// AllAndBasicConditionsValue accumulator
        /// </summary>
        private int _finalOrConditionsValue;
        
        #endregion


        #region EXECUTION
        
        /// <summary>
        /// Subscribe standard action to each hero (subscriber) event
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public void SubscribeStandardAction(IHero hero)
        {
            foreach (var subscriber in Subscribers.ActionTargets(hero))
            {
                BasicEvent.SubscribeStandardAction(subscriber,this);
            }
        }
        
        /// <summary>
        /// Unsubscribe standard action to each hero (subscriber) event
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public void UnsubscribeStandardAction(IHero hero)
        {
            foreach (var subscriber in Subscribers.ActionTargets(hero))
            {
                BasicEvent.UnsubscribeStandardAction(subscriber,this);
            }
        }
        
        /// <summary>
        /// Subscribe standard action to the skill event
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        public void SubscribeStandardAction(ISkill skill)
        {
            BasicEvent.SubscribeStandardAction(skill,this);
        }
        
        /// <summary>
        /// Unsubscribe standard action to the skill event
        /// </summary>
        /// <param name="skill"></param>
        public void UnsubscribeStandardAction(ISkill skill)
        {
            BasicEvent.UnsubscribeStandardAction(skill,this);
        }
        
        

        /// <summary>
        /// Base method for actions execution
        /// </summary>
        /// <param name="hero"></param>
        public virtual void StartAction(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            logicTree.AddCurrent(StartActionCoroutine(hero));
        }
        
        /// <summary>
        /// Runs basic action/s if basic condition/s are met
        /// Coroutine is required because this is a sequential logic
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        protected IEnumerator StartActionCoroutine(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            var actionTargetHeroes = BasicActionTargets.ActionTargets(hero);
            
            for (var index = 0; index < actionTargetHeroes.Count; index++)
            {
                var newTargetHero = actionTargetHeroes[index];
                
                var conditionTargetHeroes = BasicConditionTargets.ActionTargets(hero);

               
               //Check if conditionTargetHeroes and actionTargetHeroes are the same
               //If not, use index 0 (meaning there is only 1 condition target)
               var conditionIndex = conditionTargetHeroes.Count < actionTargetHeroes.Count ? 0 : index;
                
               //Product of all 'And' and 'Or' basic condition logic
               if (FinalConditionValue(conditionTargetHeroes[conditionIndex]) > 0)
                {
                    foreach (var basicAction in BasicActions)
                        logicTree.AddCurrent(basicAction.StartAction(newTargetHero));
                }
            }
            
            
            logicTree.EndSequence();
            yield return null;
        }
        
        //TEST Logic
        protected IEnumerator StartActionCoroutine2(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;

            //Iterate per basic action
            foreach (var basicAction in BasicActions)
            {
                //TODO: basicAction.StartAction1(hero,this);
            }
            
            
            logicTree.EndSequence();
            yield return null;
        }


        //Basic Condition Execution Logic

        private int FinalConditionValue(IHero hero)
        {
            var finalCondition = AllAndBasicConditionsValue(hero) * AllOrBasicConditionsValue(hero);
            return finalCondition;
        }
        
        /// <summary>
        /// Returns the result of multiplying all 'And' conditions
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        private int AllAndBasicConditionsValue(IHero hero)
        {
            if (AndBasicConditions.Count > 0)
            {
                _finalAndConditionsValue = 1;
                foreach (var basicCondition in AndBasicConditions)
                {
                    _finalAndConditionsValue *= basicCondition.ConditionValue(hero);
                    _finalAndConditionsValue = Mathf.Clamp(_finalAndConditionsValue, 0, 1);
                }
            }
            else
                _finalAndConditionsValue = 1; 
            
            return _finalAndConditionsValue;
        }
        
        /// <summary>
        /// Returns the result of multiplying all 'Or' conditions
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        private int AllOrBasicConditionsValue(IHero hero)
        {
            if (OrBasicConditions.Count > 0)
            {
                _finalOrConditionsValue = 0;
                foreach (var basicCondition in OrBasicConditions)
                {
                    _finalOrConditionsValue += basicCondition.ConditionValue(hero);
                    _finalOrConditionsValue = Mathf.Clamp(_finalOrConditionsValue, 0, 1);

                }
            }
            else _finalOrConditionsValue =  1;

            return _finalOrConditionsValue;
        }
       

        #endregion
        
       
    }
}
