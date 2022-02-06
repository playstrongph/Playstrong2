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
        public override List<IHero> GetActionTargets(IHero casterHero,IHero targetHero)
        {
            var actionTargets = new List<IHero>{targetHero};

            //var targetHero = hero.HeroLogic.LastHeroTargets.TargetedHero;
            
            //actionTargets.Add(targetHero);
            
            return actionTargets;
        }
        
        public override List<IHero> GetEventSubscribers(IHero hero)
        {
            var actionTargets = new List<IHero> {};
            
            Debug.Log("Target Hero can not be an event subscriber");
            
            return actionTargets;
            
        }
        
    }
}
