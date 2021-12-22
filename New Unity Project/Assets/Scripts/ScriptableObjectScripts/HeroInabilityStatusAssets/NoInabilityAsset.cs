using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.HeroInabilityStatusAssets
{
    [CreateAssetMenu(fileName = "NoInability", menuName = "Assets/HeroInabilityStatus/NoInability")]
    public class NoInabilityAsset : HeroInabilityStatusAsset
    {
        public override IEnumerator StatusAction(ITurnController turnController)
        {
        
            var logicTree = turnController.CoroutineTrees.MainLogicTree;
            
            turnController.BeforeHeroStartTurn.HeroStartTurn();
            
            logicTree.EndSequence();
            yield return null;
        }
    }
}
