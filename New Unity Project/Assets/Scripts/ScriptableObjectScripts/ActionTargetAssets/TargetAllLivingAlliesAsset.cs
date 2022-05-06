using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.ActionTargetAssets
{
    [CreateAssetMenu(fileName = "TargetAllLivingAllies", menuName = "Assets/ActionTargets/TargetAllLivingAllies")]
    public class TargetAllLivingAlliesAsset : ActionHeroesAsset
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
            var allAllies = casterHero.Player.AliveHeroes.Heroes;
            
            Debug.Log("Target All Living Allies Get Action Heroes");
            
            var actionTargets = ShuffleList(new List<IHero>(allAllies));
            
            return actionTargets;
        }
        
        public override List<IHero> GetEventSubscribers(IHero casterHero)
        {
            //Should be from the perspective of the caster hero
            var allAllies = casterHero.Player.AliveHeroes.Heroes;

            var actionTargets = ShuffleList(new List<IHero>(allAllies));
            
            return actionTargets;
            
        }
        
        
    }
}
