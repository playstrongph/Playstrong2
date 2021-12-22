using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.HeroInabilityStatusAssets
{
    [CreateAssetMenu(fileName = "HasInability", menuName = "Assets/HeroInabilityStatus/HasInability")]
    public class HasInabilityAsset : HeroInabilityStatusAsset
    {
        public override IEnumerator StatusAction(ITurnController turnController)
        {
            var logicTree = turnController.CoroutineTrees.MainLogicTree;

            logicTree.EndSequence();
            yield return null;
        }
    }
}
