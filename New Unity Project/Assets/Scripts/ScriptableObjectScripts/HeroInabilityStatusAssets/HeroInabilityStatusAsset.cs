using System.Collections;
using Logic;
using ScriptableObjectScripts.BasicActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.HeroInabilityStatusAssets
{
    public abstract class HeroInabilityStatusAsset : ScriptableObject, IHeroInabilityStatusAsset
    {
        /// <summary>
        /// Turn controller action based on inability
        /// </summary>
        /// <param name="turnController"></param>
        /// <returns></returns>
        public virtual IEnumerator TurnControllerAction(ITurnController turnController)
        {
            //With Inability - turnController.StartHeroNextTurn
            //No Inability - turnController.StartHeroTurn
            var logicTree = turnController.CoroutineTrees.MainLogicTree;

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Attack basic action asset "AttackHero" action based on inability
        /// </summary>
        /// <param name="attackHero"></param>
        /// <param name="hero"></param>
        public virtual void AttackAction(IAttackHero attackHero, IHero hero)
        {
            //var logicTree = hero.CoroutineTrees.MainLogicTree;
            //logicTree.EndSequence();
            //yield return null;
        }
        
        //TODO: Include Other Basic Actions that can't be done when hero has an 'Inability'
    }
}
