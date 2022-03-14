using System.Collections;
using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.BasicActionAssets;
using ScriptableObjectScripts.StandardActionAssets;
using ScriptableObjectScripts.StatusEffectCountersUpdateTypeAssets;
using ScriptableObjectScripts.StatusEffectCounterTypeAssets;
using ScriptableObjectScripts.StatusEffectInstanceTypeAssets;
using ScriptableObjectScripts.StatusEffectTypeAssets;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectAssets
{
    [CreateAssetMenu(fileName = "StatusEffectAsset", menuName = "Assets/StatusEffectAsset")]
    public class StatusEffectAsset : ScriptableObject, IStatusEffectAsset
    {
        [SerializeField] private string statusEffectName = "";
        
        /// <summary>
        /// Status effect name - SLOW, HASTE, etc.
        /// </summary>
        public string StatusEffectName
        {
            get => statusEffectName;
            private set => value = "";
        }
        
        [TextArea(1,2)]
        [SerializeField] private string description = "";
        /// <summary>
        /// What the status effect does - increase attack by 50%
        /// </summary>
        public string Description
        {
            get => description;
            private set => value = "";
        }

        [SerializeField] private Sprite icon;
        
        /// <summary>
        /// The status effect image icon
        /// </summary>
        public Sprite Icon
        {
            get => icon;
            private set => icon = value;
        }

        [SerializeField]
        [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffectTypeAsset))]
        private Object statusEffectType;
        /// <summary>
        /// Status Effect Type Attribute - Buff, Debuff, Unique
        /// </summary>
        public IStatusEffectTypeAsset StatusEffectType
        {
            get => statusEffectType as IStatusEffectTypeAsset;
            private set => statusEffectType = value as Object;
        }
        
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffectCounterTypeAsset))]
        private Object statusEffectCounterType;
        /// <summary>
        /// What are the counter type updates - immutable, no change, normal
        /// </summary>
        public IStatusEffectCounterTypeAsset StatusEffectCounterType
        {
            get => statusEffectCounterType as IStatusEffectCounterTypeAsset;
            private set => statusEffectCounterType = value as Object;
        }

        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffectCounterUpdateTypeAsset))]
        private Object statusEffectCounterUpdateType;
        /// <summary>
        /// When shall the counters be updated - Start turn or End turn
        /// </summary>
        public IStatusEffectCounterUpdateTypeAsset StatusEffectCounterUpdateType
        {
            get => statusEffectCounterUpdateType as IStatusEffectCounterUpdateTypeAsset;
            private set => statusEffectCounterUpdateType = value as Object;
        }

        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffectInstanceTypeAsset))]
        private Object statusEffectInstanceType;
        /// <summary>
        /// How many instances of the status effect are allowed - single, multiple
        /// </summary>
        public IStatusEffectInstanceTypeAsset StatusEffectInstanceType
        {
            get => statusEffectInstanceType as IStatusEffectInstanceTypeAsset;
            private set => statusEffectInstanceType = value as Object;
        }

        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffectActionAsset))]
        private List<ScriptableObject> statusEffectActions = new List<ScriptableObject>();
        
        /// <summary>
        /// Returns a list of IStatusEffectActionAsset
        /// </summary>
        public List<IStatusEffectActionAsset> StatusEffectActions
        {
            get
            {
                var newStatusEffectActions = new List<IStatusEffectActionAsset>();
                
                foreach (var scriptableObject in statusEffectActions)
                {
                    var statusEffectAction = scriptableObject as IStatusEffectActionAsset;
                    newStatusEffectActions.Add(statusEffectAction);
                }

                return newStatusEffectActions;
            }
        }
        public List<ScriptableObject> StatusEffectActionObjects => statusEffectActions;
        
        
        
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IBasicActionAsset))]
        private List<ScriptableObject> basicActions = new List<ScriptableObject>();
        /// <summary>
        /// Status Effect Basic Actions
        /// </summary>
        public List<IBasicActionAsset> BasicActions
        {
            get
            {
                var newBasicActions = new List<IBasicActionAsset>();
                
                foreach (var scriptableObject in basicActions)
                {
                    var basicAction = scriptableObject as IBasicActionAsset;
                    newBasicActions.Add(basicAction);
                }
                
                return newBasicActions;
            }
        }
        
        public List<ScriptableObject> BasicActionObjects => basicActions;

       
        /// <summary>
        /// Subscribe status effect action
        /// </summary>
        /// <param name="hero"></param>
        public void SubscribeAction(IHero hero)
        {
            foreach (var statusEffectAction in StatusEffectActions)
            {
                statusEffectAction.SubscribeStandardAction(hero);
            }
        }
        
        /// <summary>
        /// Unsubscribe status effect action
        /// </summary>
        /// <param name="hero"></param>
        public void UnsubscribeAction(IHero hero)
        {
            foreach (var statusEffectAction in StatusEffectActions)
            {
                statusEffectAction.UnsubscribeStandardAction(hero);
            }
        }

        /// <summary>
        /// Apply status effect 
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void ApplyAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            foreach (var basicAction in BasicActions)
            {
                //TEST
                logicTree.AddCurrent(basicAction.StartAction(casterHero, targetHero));
            }
        }


        /// <summary>
         /// Unapply the status effect
         /// </summary>
         /// <param name="casterHero"></param>
         /// <param name="targetHero"></param>
         public void UndoApplyAction(IHero casterHero, IHero targetHero)
         {
             var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
             foreach (var basicAction in BasicActions)
             {
                 //action.ExecuteAction(casterHero,targetHero);
                 logicTree.AddCurrent(basicAction.UndoExecuteAction(casterHero, targetHero));
             }
         }

        //TODO: remove status effect on death
    }
}
