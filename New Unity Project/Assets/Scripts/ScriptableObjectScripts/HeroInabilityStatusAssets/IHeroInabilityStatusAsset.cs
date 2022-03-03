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
        /// Executes basic action if caster hero has no inabilities
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void ExecuteBasicAction(IBasicActionAsset basicAction, IHero casterHero, IHero targetHero);

        /// <summary>
        /// Calls pre basic action events if caster has no Inabilities
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void CallPreBasicActionEvents(IBasicActionAsset basicAction, IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// // Calls post basic action events if caster has no Inabilities
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void CallPostBasicActionEvents(IBasicActionAsset basicAction, IHero casterHero, IHero targetHero);

    }
}