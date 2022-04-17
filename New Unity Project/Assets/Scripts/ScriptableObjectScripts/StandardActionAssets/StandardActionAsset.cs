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

        public List<ScriptableObject> BasicActionObjects => basicActions;
        public List<IBasicActionAsset> BasicActions
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

        #endregion


        #region EXECUTION
        
        /// <summary>
        /// Subscribe standard action to each hero (subscriber) event
        /// Basic events should ALWAYS use targetHero in the subscription
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        public void SubscribeStandardAction(IHero casterHero)
        {
            foreach (var subscriber in Subscribers.GetEventSubscribers(casterHero))
            {
                BasicEvent.SubscribeStandardAction(casterHero,subscriber,this);
            }
        }
        
        /// <summary>
        /// Unsubscribe standard action to each hero (subscriber) event
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        public void UnsubscribeStandardAction(IHero casterHero)
        {
            foreach (var subscriber in Subscribers.GetEventSubscribers(casterHero))
            {
                BasicEvent.UnsubscribeStandardAction(casterHero,subscriber,this);
            }
        }
        
        /// <summary>
        /// Subscribe standard action to the skill event
        /// Drag skill subscriber should always be ThisHero
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        public void SubscribeStandardAction(ISkill skill)
        {
            BasicEvent.SubscribeStandardAction(skill,this);
        }
        
        /// <summary>
        /// Unsubscribe standard action to the skill event
        /// Drag skill subscriber should always be ThisHero
        /// </summary>
        /// <param name="skill"></param>
        public void UnsubscribeStandardAction(ISkill skill)
        {
            BasicEvent.UnsubscribeStandardAction(skill,this);
        }
        
        
        /// <summary>
        /// Start action used by single IHero events (e.g. eventHeroTakesFatalDamage).
        /// Note that the caster hero and target hero in this case are the same 
        /// </summary>
        /// <param name="casterHero"></param>
        public virtual void StartAction(IHero casterHero)
        {
            //Check if both the caster and target heroes are alive
            //Also checks if the caster hero has no inability
            //Leads to calling ExecuteStartAction
            casterHero.HeroLogic.HeroLifeStatus.TargetStandardAction(this,casterHero,casterHero);
        }
        
        /// <summary>
        /// Start action used by single IHero events (e.g. eventHeroTakesFatalDamage).
        /// Note that the caster hero and target hero in this case are the same 
        /// </summary>
        /// <param name="hero"></param>
        public virtual void UndoStartAction(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            //Note: caster hero and target hero is the same for single IHero events
            logicTree.AddCurrent(UndoStartActionCoroutine(hero,hero));
        }
        
        

        /// <summary>
        /// Base method for actions execution
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        public virtual void StartAction(IHero casterHero, IHero targetHero)
        {

            //Check if both the caster and target heroes are alive
            //Also checks if the caster hero has no inability
            //Leads to calling ExecuteStartAction
            casterHero.HeroLogic.HeroLifeStatus.TargetStandardAction(this,casterHero,targetHero);

        }

        /// <summary>
        /// Start basic actions
        ///  </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        /// <returns></returns>
        public IEnumerator ExecuteStartAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            //Iterate per basic action
            foreach (var basicAction in BasicActions)
            {
                logicTree.AddCurrent(basicAction.StartAction(casterHero, targetHero, this));
            }
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Undoes the start action.  Primarily used by status effects
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        public virtual void UndoStartAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            logicTree.AddCurrent(UndoStartActionCoroutine(casterHero,targetHero));
        }
        
        /// <summary>
        /// Undoes the start action.  Primarily used by status effects 
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        private IEnumerator UndoStartActionCoroutine(IHero casterHero, IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            //Iterate per basic action
            foreach (var basicAction in BasicActions)
            {
                logicTree.AddCurrent(basicAction.UndoExecuteAction(casterHero,targetHero));
            }
            
            logicTree.EndSequence();
            yield return null;
        }


        #endregion

        #region OLD LOGIC
        
       

        #endregion
        
       
    }
}
