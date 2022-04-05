using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.ActionTargetAssets
{
    [CreateAssetMenu(fileName = "TargetAllAllies", menuName = "Assets/ActionTargets/TargetAllAllies")]
    public class TargetAllAlliesAsset : ActionTargetAsset
    {
        /// <summary>
        /// Returns the hero's targeted hero
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override List<IHero> GetActionTargets(IHero casterHero,IHero targetHero)
        {
            //Should be from the perspective of the caster hero
            var allLivingAllies = casterHero.Player.AliveHeroes.Heroes;
            var allDeadAllies = casterHero.Player.DeadHeroes.Heroes;
            var allExtinctAllies = casterHero.Player.ExtinctHeroes.Heroes;
            
            var allAllies = new List<IHero>();
            allAllies.AddRange(allLivingAllies);
            allAllies.AddRange(allDeadAllies);
            allAllies.AddRange(allExtinctAllies);

            var actionTargets = ShuffleList(new List<IHero>(allAllies));
            
            return actionTargets;
        }
        
        public override List<IHero> GetEventSubscribers(IHero casterHero)
        {
            //Should be from the perspective of the caster hero
            var allLivingAllies = casterHero.Player.AliveHeroes.Heroes;
            var allDeadAllies = casterHero.Player.DeadHeroes.Heroes;
            var allExtinctAllies = casterHero.Player.ExtinctHeroes.Heroes;
            
            var allAllies = new List<IHero>();
            allAllies.AddRange(allLivingAllies);
            allAllies.AddRange(allDeadAllies);
            allAllies.AddRange(allExtinctAllies);

            var actionTargets = ShuffleList(new List<IHero>(allAllies));
            
            return actionTargets;
            
        }
        
        
    }
}
