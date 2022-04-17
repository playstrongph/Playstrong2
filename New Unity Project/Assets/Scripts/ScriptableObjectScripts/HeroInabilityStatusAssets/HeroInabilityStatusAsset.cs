using System.Collections;
using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.BasicActionAssets;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.HeroInabilityStatusAssets
{
    public abstract class HeroInabilityStatusAsset : ScriptableObject, IHeroInabilityStatusAsset
    {
        /// <summary>
        /// Turn controller action based on inability
        /// </summary>
        /// <param name="turnController"></param>
        /// <param name="currentActiveHero"></param>
        /// <returns></returns>
        public virtual IEnumerator TurnControllerAction(ITurnController turnController,IHero currentActiveHero)
        {
            //With Inability - turnController.StartHeroNextTurn
            //No Inability - turnController.StartHeroTurn
            var logicTree = turnController.CoroutineTrees.MainLogicTree;

            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Start skill action if the casterHero has no inabilities
        /// </summary>
        /// <param name="skillAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public virtual void SkillStartAction(ISkillActionAsset skillAction, IHero casterHero, IHero targetHero)
        {
        }
        
        /// <summary>
        /// Standard action start action
        /// </summary>
        /// <param name="standardAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public virtual void ExecuteStandardAction(IStandardActionAsset standardAction, IHero casterHero,IHero targetHero)
        { }
        
        /// <summary>
        /// Add to casters hero list
        /// </summary>
        /// <param name="heroes"></param>
        /// <param name="hero"></param>
        public virtual void AddToCastersHeroList(List<IHero> heroes, IHero hero)
        {
            
        }

        #region OLD LOGIC

        /*/// <summary>
        /// Executes basic action if caster has no Inabilities
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public virtual void ExecuteBasicAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        { }

        
        /// <summary>
        /// Calls pre basic action events if caster has no Inabilities
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public virtual void CallPreBasicActionEvents(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        { }
        
        /// <summary>
        /// // Calls post basic action events if caster has no Inabilities
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public virtual void CallPostBasicActionEvents(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        { }*/
        
      

        #endregion
    }
}
