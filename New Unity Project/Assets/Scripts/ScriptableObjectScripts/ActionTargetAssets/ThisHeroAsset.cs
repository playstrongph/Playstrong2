using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.ActionTargetAssets
{
    [CreateAssetMenu(fileName = "ThisHero", menuName = "Assets/ActionTargets/ThisHero")]
    public class ThisHeroAsset : ActionTargetAsset
    {
        /// <summary>
        /// Returns the action's hero
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public override List<IHero> ActionTargets(IHero hero)
        {
            var actionTargets = new List<IHero> {hero};
            
            return actionTargets;
        }
        
        
    }
}
