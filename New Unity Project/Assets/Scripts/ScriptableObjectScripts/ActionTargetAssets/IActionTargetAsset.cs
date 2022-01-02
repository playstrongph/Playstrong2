using System.Collections.Generic;
using Logic;

namespace ScriptableObjectScripts.ActionTargetAssets
{
    public interface IActionTargetAsset
    {   
        /// <summary>
        /// Returns list of action or basic condition targets
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        List<IHero> ActionTargets(IHero hero);
        
        /// <summary>
        /// Initializes the skill's caster hero used by SkillCasterHero action target
        /// </summary>
        /// <param name="skill"></param>
        void InitializeSkillCasterHero(ISkill skill);
    }
}