using System.Collections;
using Logic;
using ScriptableObjectScripts.BasicActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.HeroInabilityStatusAssets
{
    [CreateAssetMenu(fileName = "NoInability", menuName = "Assets/HeroInabilityStatus/NoInability")]
    public class NoInabilityAsset : HeroInabilityStatusAsset
    {
        /// <summary>
        /// Hero proceeds to start the turn
        /// </summary>
        /// <param name="turnController"></param>
        /// <returns></returns>
        public override IEnumerator TurnControllerAction(ITurnController turnController)
        {
            var logicTree = turnController.CoroutineTrees.MainLogicTree;
            
            turnController.BeforeHeroStartTurn.HeroStartTurn();
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Hero proceeds to attack
        /// </summary>
        /// <param name="attackHero"></param>
        /// <param name="hero"></param>
        public override void AttackAction(IAttackHero attackHero, IHero hero)
        {
            //var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            //logicTree.AddCurrent(attackHero.AttackHero(hero));

            attackHero.AttackHero(hero);

            //logicTree.EndSequence();
            //yield return null;
        }
    }
}
