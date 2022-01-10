using System.Collections;
using Logic;
using ScriptableObjectScripts.BasicActionAssets;

namespace ScriptableObjectScripts.HeroInabilityStatusAssets
{
    public interface IHeroInabilityStatusAsset
    {
        /// <summary>
        /// Turn controller action based on inability
        /// </summary>
        /// <param name="turnController"></param>
        /// <returns></returns>
        IEnumerator TurnControllerAction(ITurnController turnController);
        
        /// <summary>
        /// Attack basic action asset "AttackHero" action based on inability
        /// </summary>
        /// <param name="attackHero"></param>
        /// <param name="hero"></param>
        void AttackAction(IAttackHero attackHero, IHero hero);
    }
}