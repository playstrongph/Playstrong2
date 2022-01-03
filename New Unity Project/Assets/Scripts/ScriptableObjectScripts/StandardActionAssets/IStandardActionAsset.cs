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
        IActionTargetAsset Subscribers { get; }
        
        /// <summary>
        /// Hero targets used in the basic condition logic
        /// </summary>
        IActionTargetAsset BasicConditionTargets { get; }
        
        
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
        IActionTargetAsset BasicActionTargets { get; }
        

        #endregion
        
        
        /// <summary>
        /// Base method for actions execution
        /// </summary>
        /// <param name="hero"></param>
        void StartAction(IHero hero);
    }
}