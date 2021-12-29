using ScriptableObjectScripts.SkillCooldownTypeAssets;
using ScriptableObjectScripts.SkillTargetsAssets;
using ScriptableObjectScripts.SkillTypeAssets;

namespace Logic
{
    public interface ISkillAttributes
    {
        /// <summary>
        /// Skill cooldown reference
        /// </summary>
        int Cooldown { get; set; }
        
        /// <summary>
        /// Base Cooldown reference
        /// </summary>
        int BaseCooldown { get; set; }
        
        /// <summary>
        /// Skill type reference
        /// </summary>
        ISkillTypeAsset SkillType { get; set; }

        /// <summary>
        /// Skill valid targets - allies, enemies, other allies, or none (passive skills))
        /// </summary>
        ISkillTargetsAsset SkillTargets { get; set; }
        
        /// <summary>
        /// Skill cooldown types - normal, immutable, and no cooldown
        /// </summary>
        ISkillCooldownTypeAsset SkillCooldownType { get; set; }

    }
}