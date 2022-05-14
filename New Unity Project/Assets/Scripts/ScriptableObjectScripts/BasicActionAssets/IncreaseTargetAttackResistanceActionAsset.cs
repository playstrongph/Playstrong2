using System.Collections;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.GameAnimationAssets;
using ScriptableObjectScripts.StandardActionAssets;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "IncreaseTargetAttackResistanceAction", menuName = "Assets/BasicActions/I/IncreaseTargetAttackResistanceAction")]
    public class IncreaseTargetAttackResistanceActionAsset : BasicActionAsset
    {   
       
        /// <summary>
        /// Increase attack resistance
        /// </summary>
        [SerializeField] private int attackResistance = 0;

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
        /// Increase the attribute value
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            targetHero.HeroLogic.ResistanceAttributes.TargetAttackResistance += attackResistance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        /// <summary>
        /// Return the attribute value back to its last value
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator UndoExecuteAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
           
            targetHero.HeroLogic.ResistanceAttributes.TargetAttackResistance -= attackResistance;
            
            logicTree.EndSequence();
            yield return null;
        }

    }
}
