using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.HeroInabilityStatusAssets
{
    public abstract class HeroInabilityStatusAsset : ScriptableObject, IHeroInabilityStatusAsset
    {
        public virtual IEnumerator StatusAction(ITurnController turnController)
        {
            //With Inability - turnController.StartHeroNextTurn
            //No Inability - turnController.StartHeroTurn
            var logicTree = turnController.CoroutineTrees.MainLogicTree;
            
            
            
            logicTree.EndSequence();
            yield return null;
        }
    }
}
