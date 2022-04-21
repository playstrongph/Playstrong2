using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.ActionTargetAssets
{
    [CreateAssetMenu(fileName = "SomeOtherLivingAllies", menuName = "Assets/ActionTargets/SomeOtherLivingAllies")]
    public class SomeOtherLivingAlliesAsset : ActionHeroesAsset
    {

        [SerializeField] private int allyCount = 0;
        
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

            var allOtherAllies = new List<IHero>(allAllies);
            
            allOtherAllies.Remove(casterHero);

            var actionTargets = ShuffleList(new List<IHero>(allOtherAllies));
            
            //Get the lesser count between the other living allies and indicated ally count
            var targetsCount = Mathf.Min(actionTargets.Count, allyCount);
            
            var finalActionTargets = new List<IHero>();
        
            for (int i = 0; i < targetsCount; i++)
            {
                finalActionTargets.Add(actionTargets[i]);
            }
            
            return finalActionTargets;
        }
        
        public override List<IHero> GetEventSubscribers(IHero casterHero)
        {
            //Should be from the perspective of the caster hero
            var allAllies = casterHero.Player.AliveHeroes.Heroes;

            var allOtherAllies = new List<IHero>(allAllies);
            
            allOtherAllies.Remove(casterHero);

            var actionTargets = ShuffleList(new List<IHero>(allOtherAllies));
            
            //Get the lesser count between the other living allies and indicated ally count
            var targetsCount = Mathf.Min(actionTargets.Count, allyCount);
            
            var finalActionTargets = new List<IHero>();

            for (int i = 0; i < targetsCount; i++)
            {
                finalActionTargets.Add(actionTargets[i]);
            }
            
            return finalActionTargets;
            
        }



    }
}
