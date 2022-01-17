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
        /// <param name="hero"></param>
        /// <returns></returns>
        public override List<IHero> ActionTargets(IHero hero)
        {
            var targetHero = hero.HeroLogic.LastHeroTargets.TargetedHero;
            
            var allEnemies = targetHero.Player.AliveHeroes.Heroes;

            var actionTargets = ShuffleList(new List<IHero>(allEnemies));
            
            return actionTargets;
        }
        
        
    }
}
