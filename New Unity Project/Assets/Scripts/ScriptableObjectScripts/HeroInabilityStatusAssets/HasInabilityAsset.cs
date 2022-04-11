using System.Collections;
using Logic;
using ScriptableObjectScripts.BasicActionAssets;
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
        /// <param name="currentActiveHero"></param>
        /// <returns></returns>
        public override IEnumerator TurnControllerAction(ITurnController turnController,IHero currentActiveHero)
        {
            var logicTree = turnController.CoroutineTrees.MainLogicTree;

            //Delay allows to cleanup the Heroes Turn Queue for dead heroes
            logicTree.AddSibling(turnController.AfterHeroEndTurn.StartAction());

            logicTree.EndSequence();
            yield return null;
        }

       

        
        
        
        
    }
}
