using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.StandardActionAssets;

namespace ScriptableObjectScripts.ActionTargetAssets
{
    public interface IActionTargetAsset
    {   
        /// <summary>
        /// Returns list of action or basic condition targets
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="standardActionAsset"></param>
        /// <returns></returns>
        List<IHero> GetActionTargets(IHero casterHero, IHero targetHero,IStandardActionAsset standardActionAsset);
        
        /// <summary>
        /// Returns a list of heroes subscribing to the basic event
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        List<IHero> GetEventSubscribers(IHero hero);
        
        /// <summary>
        /// Returns a list of heroes subscribing to the skill event.  Default is the skill caster hero
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        List<IHero> GetEventSubscribers(ISkill skill);

        /*/// <summary>
        /// Initializes the skill's caster hero used by SkillCasterHero action target
        /// </summary>
        /// <param name="skill"></param>
        void InitializeSkillCasterHero(ISkill skill);*/

        /*/// <summary>
        /// Sets the reference to the status effect's caster hero
        /// </summary>
        /// <param name="statusEffect"></param>
        void InitializeStatusEffectCasterHero(IStatusEffect statusEffect);*/
    }
}