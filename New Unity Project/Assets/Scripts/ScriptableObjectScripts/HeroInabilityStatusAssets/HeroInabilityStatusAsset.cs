using System.Collections;
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
        /// Executes basic action if caster has no Inabilities
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public virtual void ExecuteBasicAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        { }

        //TODO: Include Other Basic Actions that can't be done when hero has an 'Inability'
        
        
        //TEST
        public virtual void ExecuteStandardAction(IStandardActionAsset standardAction, IHero casterHero,IHero targetHero)
        { }
        
        
        //TEST - END
        
        
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
        { }
        
        /// <summary>
        /// Start skill action if the casterHero has no inabilities
        /// </summary>
        /// <param name="skillAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public virtual void SkillStartAction(ISkillActionAsset skillAction, IHero casterHero, IHero targetHero)
        {
        }
    }
}
