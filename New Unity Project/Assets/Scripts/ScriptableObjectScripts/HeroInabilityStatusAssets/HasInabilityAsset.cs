using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.HeroInabilityStatusAssets
{
    
    [CreateAssetMenu(fileName = "HasInability", menuName = "Assets/HeroInabilityStatus/HasInability")]
    public class HasInabilityAsset : HeroInabilityStatusAsset
    {
        /// <summary>
        /// Hero misses his turn and proceed to after hero end turn
        /// </summary>
        /// <param name="turnController"></param>
        /// <returns></returns>
        public override IEnumerator StatusAction(ITurnController turnController)
        {
            var logicTree = turnController.CoroutineTrees.MainLogicTree;

            logicTree.AddCurrent(turnController.AfterHeroEndTurn.StartAction());

            logicTree.EndSequence();
            yield return null;
        }
    }
}
