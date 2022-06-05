using System;
using System.Collections;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.GameAnimationAssets;
using ScriptableObjectScripts.StandardActionAssets;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "IncreaseFightingSpiritAction", menuName = "Assets/BasicActions/I/IncreaseFightingSpiritAction")]
    public class IncreaseFightingSpiritActionAsset : BasicActionAsset
    {   
        /// <summary>
        /// Increase value by a fixed amount
        /// </summary>
        [SerializeField] private int flatValue = 0;
        
        /// <summary>
        /// Set multiplier to 1 to enable, 0 is disabled
        /// </summary>
        [Header("Multipliers")]
        [SerializeField] private int buffCountMultiplier = 0;

        /// <summary>
        /// The specific logic-visual sequence for basic action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        protected override IEnumerator MainBasicActionPhase(IHero casterHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            //base class method that calls execute action after checking life status and inability status
            logicTree.AddCurrent(MainAction(targetHero));

            logicTree.EndSequence();
            yield return null;
        }


        /// <summary>
        /// Increase target hero attribute
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            var buffsMultiplier = BuffCountMultiplier(targetHero);

            var totalValue = flatValue * (1 + buffsMultiplier);

            var fightingSpirit = targetHero.HeroLogic.HeroAttributes.FightingSpirit + totalValue;
            
            targetHero.HeroLogic.SetFightingSpirit.StartAction(fightingSpirit);

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Total number of buffs multiplier
        /// </summary>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        private int BuffCountMultiplier(IHero targetHero)
        {
            var value = 0;

            var buffCount = targetHero.HeroStatusEffects.BuffEffects.StatusEffects.Count;
            
            //Minus 1 is due to factoring out flat value in the total value calculation
            value = buffCountMultiplier * buffCount - 1;

            value = Mathf.Clamp(value, 0, 1);
            
            return value;
        }



    }
}
