using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.ActionTargetAssets
{
    [CreateAssetMenu(fileName = "TargetAllLivingEnemies", menuName = "Assets/ActionTargets/TargetAllLivingEnemies")]
    public class TargetAllLivingEnemiesAsset : ActionHeroesAsset
    {
        /// <summary>
        /// Returns the hero's targeted hero
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="standardActionAsset"></param>
        /// <returns></returns>
        public override List<IHero> GetActionHeroes(IHero casterHero,IHero targetHero, IStandardActionAsset standardActionAsset)
        {
            //Should be from the perspective of the caster hero
            var allEnemies = casterHero.Player.OtherPlayer.AliveHeroes.Heroes;

            var actionTargets = ShuffleList(new List<IHero>(allEnemies));
            
            return actionTargets;
        }
        
        public override List<IHero> GetEventSubscribers(IHero casterHero)
        {
            //Should be from the perspective of the caster hero
            var allEnemies = casterHero.Player.OtherPlayer.AliveHeroes.Heroes;

            var actionTargets = ShuffleList(new List<IHero>(allEnemies));
            
            return actionTargets;
            
        }
        
        
    }
}
