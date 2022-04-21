using System.Collections;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.GameAnimationAssets;
using ScriptableObjectScripts.StandardActionAssets;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "IncreaseStatusEffectCountersAction", menuName = "Assets/BasicActions/I/IncreaseStatusEffectCountersAction")]
    public class IncreaseStatusEffectCountersActionAsset : BasicActionAsset
    {

        [SerializeField] private int buffCounters = 0;
        [SerializeField] private int debuffCounters = 0;
        [SerializeField] private int uniqueCounters = 0;
        

        /// <summary>
        /// The specific logic-visual sequence for basic action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        protected override IEnumerator MainBasicActionPhase(IHero casterHero, IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            //base class method that calls execute action after checking life status and inability status
            logicTree.AddCurrent(MainAction(casterHero));

            logicTree.EndSequence();
            yield return null;
        }


        /// <summary>
        /// Increase attack logic execution
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            var buffs = targetHero.HeroStatusEffects.BuffEffects.StatusEffects;
            var debuffs = targetHero.HeroStatusEffects.DebuffEffects.StatusEffects;
            var uniqueStatusEffects = targetHero.HeroStatusEffects.UniqueStatusEffects.StatusEffects;

            foreach (var buff in buffs)
            {
                buff.UpdateStatusEffectCounters.IncreaseCounters(buffCounters);
            }

            foreach (var debuff in debuffs)
            {
                debuff.UpdateStatusEffectCounters.IncreaseCounters(debuffCounters);
            }
            
            foreach (var uniqueStatusEffect in uniqueStatusEffects)
            {
                uniqueStatusEffect.UpdateStatusEffectCounters.IncreaseCounters(uniqueCounters);
            }
           
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoExecuteAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            
            //Do Nothing

            logicTree.EndSequence();
            yield return null;
        }

    }
}
