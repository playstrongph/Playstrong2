using System.Collections;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.GameAnimationAssets;
using ScriptableObjectScripts.StandardActionAssets;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "IncreaseCounterAttackResistanceAction", menuName = "Assets/BasicActions/I/IncreaseCounterAttackResistanceAction")]
    public class IncreaseCounterAttackResistanceActionAsset : BasicActionAsset
    {   
       
        /// <summary>
        /// Increase value by a percentage amount
        /// </summary>
        [SerializeField] private int counterAttackResistance = 200;

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
            logicTree.AddCurrent(MainAction(targetHero));
            
            logicTree.EndSequence();
            yield return null;
        }


        /// <summary>
        /// Increase counter resistance logic execution
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            targetHero.HeroLogic.ResistanceAttributes.CounterAttackResistance += counterAttackResistance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        /// <summary>
        /// Undo increase counter resistance logic execution
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator UndoExecuteAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
           
            targetHero.HeroLogic.ResistanceAttributes.CounterAttackResistance -= counterAttackResistance;
            
            logicTree.EndSequence();
            yield return null;
        }

    }
}
