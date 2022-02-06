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
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override List<IHero> ActionTargets(IHero casterHero,IHero targetHero)
        {
            var actionTargets = new List<IHero>{targetHero};

            //var targetHero = hero.HeroLogic.LastHeroTargets.TargetedHero;
            
            //actionTargets.Add(targetHero);
            
            return actionTargets;
        }
        
        
    }
}
