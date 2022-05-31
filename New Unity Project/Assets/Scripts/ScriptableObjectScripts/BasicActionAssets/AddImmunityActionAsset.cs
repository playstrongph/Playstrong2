using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.GameAnimationAssets;
using ScriptableObjectScripts.StandardActionAssets;
using ScriptableObjectScripts.StatusEffectAssets;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    /// <summary>
    /// Adds and Removes status effect assets in the hero's immunity attributes
    /// </summary>
    [CreateAssetMenu(fileName = "AddImmunityAction", menuName = "Assets/BasicActions/A/AddImmunityAction")]
    public class AddImmunityActionAsset : BasicActionAsset
    {

        [SerializeField][RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffectAsset))]
        private List<ScriptableObject> immunities = new List<ScriptableObject>();

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

            var heroImmunitiesScriptableObjects = targetHero.HeroLogic.ImmunityAttributes.ImmunitiesScriptableObjects;

            foreach (var immunity in immunities)
            {
                heroImmunitiesScriptableObjects.Add(immunity);
            }
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoExecuteAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            
            var heroImmunitiesScriptableObjects = targetHero.HeroLogic.ImmunityAttributes.ImmunitiesScriptableObjects;
            
            foreach (var immunity in immunities)
            {
                heroImmunitiesScriptableObjects.Remove(immunity);
            }

            logicTree.EndSequence();
            yield return null;
        }

    }
}
