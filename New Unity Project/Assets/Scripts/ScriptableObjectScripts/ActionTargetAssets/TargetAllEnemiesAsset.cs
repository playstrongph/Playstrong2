using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.ActionTargetAssets
{
    [CreateAssetMenu(fileName = "TargetAllEnemies", menuName = "Assets/ActionTargets/TargetAllEnemies")]
    public class TargetAllEnemiesAsset : ActionTargetAsset
    {
        /// <summary>
        /// Returns the hero's targeted hero
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override List<IHero> GetActionTargets(IHero casterHero,IHero targetHero)
        {
            //var targetHero = hero.HeroLogic.LastHeroTargets.TargetedHero;
            
            var allEnemies = targetHero.Player.AliveHeroes.Heroes;

            var actionTargets = ShuffleList(new List<IHero>(allEnemies));
            
            return actionTargets;
        }
        
        public override List<IHero> GetEventSubscribers(IHero hero)
        {
            var allEnemies = hero.Player.OtherPlayer.AliveHeroes.Heroes;

            var actionTargets = ShuffleList(new List<IHero>(allEnemies));
            
            return actionTargets;
            
        }
        
        
    }
}
