using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.ActionTargetAssets
{
    
    /// <summary>
    /// Base class for action targets
    /// </summary>
    public abstract class ActionTargetAsset : ScriptableObject, IActionTargetAsset
    {
        /// <summary>
        /// Returns list of action or basic condition targets
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public virtual List<IHero> ActionTargets(IHero hero)
        {
            var actionTargets = new List<IHero>();
            
            Debug.Log("Base Class Action Targets");
            
            return actionTargets;
        }
        
       
        
        


    }
}
