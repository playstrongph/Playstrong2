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

            //logicTree.AddCurrent(turnController.AfterHeroEndTurn.StartAction());
            
            //TEST - Delay allows to cleanup the Heroes Turn Queue for dead heroes
            logicTree.AddSibling(turnController.AfterHeroEndTurn.StartAction());

            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Hero performs no action
        /// </summary>
        /// <param name="attackHero"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void AttackAction(IAttackHero attackHero, IHero casterHero,IHero targetHero)
        {
            //var logicTree = hero.CoroutineTrees.MainLogicTree;
            //logicTree.EndSequence();
            //yield return null;
        }
    }
}
