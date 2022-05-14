using System.Collections;
using Logic;
using ScriptableObjectScripts.GameAnimationAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "SetLifeAttackAction", menuName = "Assets/BasicActions/S/SetLifeAttackAction")]
    public class SetLifeActionAsset : BasicActionAsset
    {
        /// <summary>
        /// Set life to a fixed amount
        /// </summary>
        [SerializeField] private int flatValue = 1;
        
        
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
        /// Set health logic
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            //Set the new attack value in hero attributes
            targetHero.HeroLogic.SetHealth.StartAction(flatValue);
            
            //Note: No undo execute action
            
            logicTree.EndSequence();
            yield return null;
        }

    }
}
