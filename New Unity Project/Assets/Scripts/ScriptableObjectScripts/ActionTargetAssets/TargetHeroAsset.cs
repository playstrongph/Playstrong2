using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.ActionTargetAssets
{
    [CreateAssetMenu(fileName = "TargetHero", menuName = "Assets/ActionTargets/TargetHero")]
    public class TargetHeroAsset : ActionTargetAsset
    {
        /// <summary>
        /// Returns the hero's targeted hero
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public override List<IHero> ActionTargets(IHero hero)
        {
            var actionTargets = new List<IHero>();

            var targetHero = hero.HeroLogic.LastHeroTargets.TargetedHero;
            
            actionTargets.Add(targetHero);
            
            return actionTargets;
        }
        
        
    }
}
