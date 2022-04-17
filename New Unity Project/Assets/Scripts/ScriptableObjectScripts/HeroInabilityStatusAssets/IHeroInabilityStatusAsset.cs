using System.Collections;
using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.BasicActionAssets;
using ScriptableObjectScripts.StandardActionAssets;

namespace ScriptableObjectScripts.HeroInabilityStatusAssets
{
    public interface IHeroInabilityStatusAsset
    {
        /// <summary>
        /// Turn controller action based on inability
        /// </summary>
        /// <param name="turnController"></param>
        /// <param name="currentActiveHero"></param>
        /// <returns></returns>
        IEnumerator TurnControllerAction(ITurnController turnController,IHero currentActiveHero);

        /// <summary>
        /// Start skill action if the casterHero has no inabilities
        /// </summary>
        /// <param name="skillAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
         void SkillStartAction(ISkillActionAsset skillAction, IHero casterHero, IHero targetHero);

        /// <summary>
        /// Standard action start action
        /// </summary>
        /// <param name="standardAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void ExecuteStandardAction(IStandardActionAsset standardAction, IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// Add to casters hero list
        /// </summary>
        /// <param name="heroes"></param>
        /// <param name="hero"></param>
        void AddToCastersHeroList(List<IHero> heroes, IHero hero);



        #region OLD LOGIC

        /*/// <summary>
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
        void CallPostBasicActionEvents(IBasicActionAsset basicAction, IHero casterHero, IHero targetHero);*/

        #endregion


    }
}