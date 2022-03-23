using System.Collections;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.GameAnimationAssets;
using ScriptableObjectScripts.StandardActionAssets;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "IncreaseDebuffResistance", menuName = "Assets/BasicActions/I/IncreaseDebuffResistance")]
    public class IncreaseDebuffResistanceActionAsset : BasicActionAsset
    {   
        /// <summary>
        /// Increase value by a fixed amount
        /// </summary>
        [SerializeField] private int flatValue = 150;

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

            targetHero.HeroLogic.ResistanceAttributes.DebuffResistance += flatValue;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoExecuteAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            
            targetHero.HeroLogic.ResistanceAttributes.DebuffResistance -= flatValue;

            logicTree.EndSequence();
            yield return null;
        }

    }
}
