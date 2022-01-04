using ScriptableObjectScripts.SkillEffectAssets;

namespace Logic
{
    public interface ISkillLogic
    {
        /// <summary>
        /// Interface reference to skill
        /// </summary>
        ISkill Skill { get; }

        /// <summary>
        /// Skill Effect Reference
        /// </summary>
        ISkillEffectAsset SkillEffect { get; set; }

        /// <summary>
        /// Contains the skill properties such as cooldown, skill type, etc.
        /// </summary>
        ISkillAttributes SkillAttributes { get; }
        
        /// <summary>
        /// Contains other skill properties and factors
        /// </summary>
        IOtherSkillAttributes OtherSkillAttributes { get; }
        
        /// <summary>
        /// Loads the skill attributes from the skill asset
        /// </summary>
        ILoadSkillAttributes LoadSkillAttributes { get; }
        
        /// <summary>
        ///  Updates the skill cooldown based on cooldown type
        /// </summary>
        IUpdateSkillCooldown UpdateSkillCooldown { get; }
        
        /// <summary>
        /// Updates the skill readiness status and executes status actions
        /// </summary>
        IUpdateSkillReadiness UpdateSkillReadiness { get; }
        
        /// <summary>
        /// Reference to skill events
        /// </summary>
        ISkillEvents SkillEvents { get; }


    }
}