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
