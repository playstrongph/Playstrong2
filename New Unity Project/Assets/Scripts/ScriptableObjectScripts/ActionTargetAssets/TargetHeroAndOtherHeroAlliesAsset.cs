using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.CalculatedValuesAssets;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.ActionTargetAssets
{
    [CreateAssetMenu(fileName = "TargetHeroAndOtherHeroAllies", menuName = "Assets/ActionTargets/TargetHeroAndOtherHeroAllies")]
    public class TargetHeroAndOtherHeroAlliesAsset : ActionHeroesAsset
    {

        [SerializeField] private int otherAllyCount = 0;

        private List<IHero> finalTargets = new List<IHero>();
        
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ICalculatedValueAsset))]private ScriptableObject calculatedHeroTargetsAsset;
        private ICalculatedValueAsset CalculatedHeroTargetsAsset
        {
            get => calculatedHeroTargetsAsset as ICalculatedValueAsset;
            set => calculatedHeroTargetsAsset = value as ScriptableObject;
        }
        
        /// <summary>
        /// Returns the hero's targeted hero
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="standardActionAsset"></param>
        /// <returns></returns>
        public override List<IHero> GetActionHeroes(IHero casterHero,IHero targetHero, IStandardActionAsset standardActionAsset)
        {
            return CalculatedHeroTargetsAsset.CalculatedHeroes;
        }
        
        public override List<IHero> GetEventSubscribers(IHero hero)
        {
            return CalculatedHeroTargetsAsset.CalculatedHeroes;
        }

        public override List<IHero> SetActionHeroes(IHero casterHero,IHero targetHero)
        {
            var allAllies = targetHero.Player.AliveHeroes.Heroes;

            var allOtherAllies = ShuffleList(new List<IHero> (allAllies));

            allOtherAllies.Remove(targetHero);

            var targetsCount = Mathf.Min(allOtherAllies.Count, otherAllyCount);
            
            finalTargets = new List<IHero>{targetHero};

            for (int i = 0; i < targetsCount; i++)
            {
                finalTargets.Add(allOtherAllies[i]);
            }

            return finalTargets;
        }
        
        
        
    }
}
