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
        /// <returns></returns>
        public override IEnumerator TurnControllerAction(ITurnController turnController)
        {
            var logicTree = turnController.CoroutineTrees.MainLogicTree;

            logicTree.AddCurrent(turnController.AfterHeroEndTurn.StartAction());

            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Hero performs no action
        /// </summary>
        /// <param name="attackHero"></param>
        /// <param name="hero"></param>
        public override void AttackAction(IAttackHero attackHero, IHero hero)
        {
            //var logicTree = hero.CoroutineTrees.MainLogicTree;
            //logicTree.EndSequence();
            //yield return null;
        }
    }
}
