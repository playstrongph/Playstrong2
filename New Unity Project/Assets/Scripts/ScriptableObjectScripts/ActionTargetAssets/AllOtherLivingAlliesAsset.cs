using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.ActionTargetAssets
{
    [CreateAssetMenu(fileName = "AllOtherLivingAllies", menuName = "Assets/ActionTargets/AllOtherLivingAllies")]
    public class AllOtherLivingAlliesAsset : ActionTargetAsset
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
            var allAllies = casterHero.Player.AliveHeroes.Heroes;

            var allOtherAllies = new List<IHero>(allAllies);
            
            allOtherAllies.Remove(casterHero);

            var actionTargets = ShuffleList(new List<IHero>(allOtherAllies));
            
            return actionTargets;
        }
        
        public override List<IHero> GetEventSubscribers(IHero casterHero)
        {
            //Should be from the perspective of the caster hero
            var allAllies = casterHero.Player.AliveHeroes.Heroes;

            var allOtherAllies = new List<IHero>(allAllies);
            
            allOtherAllies.Remove(casterHero);

            var actionTargets = ShuffleList(new List<IHero>(allOtherAllies));

            foreach (var actionTarget in actionTargets)
            {
                Debug.Log("Subscriber: " +actionTarget.HeroName);
            }
            
            return actionTargets;
            
        }



    }
}
