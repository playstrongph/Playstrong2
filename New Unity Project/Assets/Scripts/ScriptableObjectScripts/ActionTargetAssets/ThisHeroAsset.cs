using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.ActionTargetAssets
{
    [CreateAssetMenu(fileName = "ThisHero", menuName = "Assets/ActionTargets/ThisHero")]
    public class ThisHeroAsset : ActionHeroesAsset
    {
        /// <summary>
        /// Returns the action's hero
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="standardActionAsset"></param>
        /// <returns></returns>
        public override List<IHero> GetActionHeroes(IHero casterHero,IHero targetHero, IStandardActionAsset standardActionAsset)
        {
            var actionTargets = new List<IHero> {casterHero};
            
            return actionTargets;
        }
        
        public override List<IHero> GetEventSubscribers(IHero hero)
        {
            var actionTargets = new List<IHero> {hero};
            
            return actionTargets;
            
        }
        
        
    }
}
