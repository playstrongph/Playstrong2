using System.Collections;
using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.ActionTargetAssets;
using ScriptableObjectScripts.BasicConditionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.StandardActionAssets
{
    public interface IStandardActionAsset
    {

        #region VARIABLES AND PROPERTIES
        
        /// <summary>
        /// Hero subscribers to the basic events
        /// </summary>
        IActionTargetAsset Subscribers { get; set; }
        
        /// <summary>
        /// Hero targets used in the basic condition logic
        /// </summary>
        IActionTargetAsset BasicConditionTargets { get; set; }
        
        
        /// <summary>
        /// List of basic conditions in 'OR' logic configuration
        /// Returns orBasicConditions as list of basic condition assets
        /// </summary>
        List<IBasicConditionAsset> OrBasicConditions { get; }
        
        /// <summary>
        /// Used in creating unique basic conditions
        /// Returns orBasicConditions as list of scriptable objects
        /// </summary>
        List<ScriptableObject> OrBasicConditionsScriptableObjects { get; }
        
        /// <summary>
        /// List of basic conditions in 'And' logic configuration
        /// Returns andBasicConditions as list of basic condition assets
        /// </summary>
        List<IBasicConditionAsset> AndBasicConditions { get; }

        /// <summary>
        /// Used in creating unique basic conditions
        /// Returns andBasicConditions as list of scriptable objects
        /// </summary>
        List<ScriptableObject> AndBasicConditionsScriptableObjects { get; }
        
        /// <summary>
        /// Heroes used ion basic action logic
        /// </summary>
        IActionTargetAsset BasicActionTargets { get; set; }
        

        #endregion


        #region EXECUTION
        
        /// <summary>
        /// Subscribe standard action to each hero (subscriber) event
        /// </summary>
        /// <param name="hero"></param>
        void SubscribeStandardAction(IHero hero);
        
        /// <summary>
        /// Unsubscribe standard action to each hero (subscriber) event
        /// </summary>
        /// <param name="hero"></param>
        void UnsubscribeStandardAction(IHero hero);
        
        /// <summary>
        /// Subscribe standard action to the skill event
        /// </summary>
        /// <param name="skill"></param>
        void SubscribeStandardAction(ISkill skill);

        
        /// <summary>
        /// Unsubscribe standard action to the skill event
        /// </summary>
        /// <param name="skill"></param>
        void UnsubscribeStandardAction(ISkill skill);
        
        /// <summary>
        /// Base method for actions execution
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        void StartAction(IHero casterHero,IHero targetHero);

        /// <summary>
        /// Undo the start action.  Primarily used by status effects
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        void UndoStartAction(IHero casterHero,IHero targetHero);
        
        /// <summary>
        /// Start action used by single IHero events (e.g. eventHeroTakesFatalDamage).
        /// Note that the caster hero and target hero in this case are the same 
        /// </summary>
        /// <param name="hero"></param>
        void StartAction(IHero hero);
        
        
        /// <summary>
        /// Start action used by single IHero events (e.g. eventHeroTakesFatalDamage).
        /// Note that the caster hero and target hero in this case are the same 
        /// </summary>
        /// <param name="hero"></param>
        void UndoStartAction(IHero hero);


        #endregion


    }
}