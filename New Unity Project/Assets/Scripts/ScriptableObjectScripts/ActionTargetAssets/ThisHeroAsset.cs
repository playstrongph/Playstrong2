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
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override List<IHero> ActionTargets(IHero casterHero,IHero targetHero)
        {
            var actionTargets = new List<IHero> {casterHero};
            
            return actionTargets;
        }
        
        
    }
}
