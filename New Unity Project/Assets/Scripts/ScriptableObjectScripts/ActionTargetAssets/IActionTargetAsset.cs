using System.Collections.Generic;
using Logic;

namespace ScriptableObjectScripts.ActionTargetAssets
{
    public interface IActionTargetAsset
    {   
        /// <summary>
        /// Returns list of action or basic condition targets
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        List<IHero> GetActionTargets(IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// Returns a list of heroes subscribing to the basic event
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        List<IHero> GetEventSubscribers(IHero hero);

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