using System.Collections;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.ActionTargetAssets;
using ScriptableObjectScripts.CalculatedValuesAssets;
using ScriptableObjectScripts.GameAnimationAssets;
using ScriptableObjectScripts.StandardActionAssets;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "SetHeroTargetsAction", menuName = "Assets/BasicActions/S/SetHeroTargetsAction")]
    public class SetHeroTargetsActionAsset : BasicActionAsset
    {

        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ICalculatedValueAsset))]private ScriptableObject calculatedValueAsset;
        private ICalculatedValueAsset CalculatedValueAsset
        {
            get => calculatedValueAsset as ICalculatedValueAsset;
            set => calculatedValueAsset = value as ScriptableObject;
        }


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

            CalculatedValueAsset.GetCalculatedHeroList(targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoExecuteAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            //var visualTree = targetHero.CoroutineTrees.MainVisualTree;

            //No Action

            logicTree.EndSequence();
            yield return null;
        }

    }
}
