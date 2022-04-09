using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.StandardActionAssets;
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
        /// <param name="standardActionAsset"></param>
        /// <returns></returns>
        public override List<IHero> GetActionTargets(IHero casterHero,IHero targetHero, IStandardActionAsset standardActionAsset)
        {
            //Should be from the perspective of the caster hero
            var allLivingEnemies = casterHero.Player.OtherPlayer.AliveHeroes.Heroes;
            var allDeadEnemies = casterHero.Player.OtherPlayer.DeadHeroes.Heroes;
            var allExtinctEnemies = casterHero.Player.OtherPlayer.ExtinctHeroes.Heroes;
            
            var allEnemies = new List<IHero>();
            allEnemies.AddRange(allLivingEnemies);
            allEnemies.AddRange(allDeadEnemies);
            allEnemies.AddRange(allExtinctEnemies);

            var actionTargets = ShuffleList(new List<IHero>(allEnemies));
            
            return actionTargets;
        }
        
        public override List<IHero> GetEventSubscribers(IHero casterHero)
        {
            //Should be from the perspective of the caster hero
            var allLivingEnemies = casterHero.Player.OtherPlayer.AliveHeroes.Heroes;
            var allDeadEnemies = casterHero.Player.OtherPlayer.DeadHeroes.Heroes;
            var allExtinctEnemies = casterHero.Player.OtherPlayer.ExtinctHeroes.Heroes;
            
            var allEnemies = new List<IHero>();
            allEnemies.AddRange(allLivingEnemies);
            allEnemies.AddRange(allDeadEnemies);
            allEnemies.AddRange(allExtinctEnemies);

            var actionTargets = ShuffleList(new List<IHero>(allEnemies));
            
            return actionTargets;
            
        }
        
        
    }
}
