using Logic;
using ScriptableObjectScripts.SkillEnableStatusAssets;
using ScriptableObjectScripts.SkillReadinessStatusAssets;
using TMPro;

namespace ScriptableObjectScripts.SkillTypeAssets
{
    public interface ISkillTypeAsset
    {
        /// <summary>
        /// Default starting skill readiness status for each skill type
        /// </summary>
        ISkillReadinessStatusAsset StartingSkillReadiness { get; }

        /// <summary>
        /// Skill Readiness checks skill enabled status and executes status action depending on skill type
        /// Active and Basic Skills - Enables select drag target, enables target visual,  skill glow, and hides cooldown text 
        /// Passive Skills - hides cooldown text  
        /// </summary>
        /// <param name="skill"></param>
        void SkillReadyActions(ISkill skill);

        /// <summary>
        /// Skill Readiness status action depending on skill type
        /// Active and Basic Skills - Disables select drag target, enables target visual,
        /// skill glow, and shows cooldown text
        /// Passive Skills - shows cooldown text if CD > 0 
        /// </summary>
        /// <param name="skill"></param>
        void SkillNotReadyActions(ISkill skill);

        /// <summary>
        /// Used by 'Silence' type effects - sets skill enabled status to skill disabled and
        /// executes skill disabled status actions
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="skillEnableStatusAsset"></param>
        void DisableActiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset);

        /// <summary>
        /// Used by 'Silence' type effects - sets skill enabled status to skill enabled and
        /// executes skill enabled status actions
        /// </summary>
        /// <param name="skill"></param>
        ///  /// <param name="skillEnableStatusAsset"></param>
        void EnableActiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset);
        
        /// <summary>
        /// Used by 'Seal' type effects - sets skill enabled status to skill disabled and
        /// executes skill disabled status actions
        /// </summary>
        /// <param name="skill"></param>
        ///  /// <param name="skillEnableStatusAsset"></param>
        void DisablePassiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset);

        /// <summary>
        /// Used by 'Seal' type effects - sets skill enabled status to skill enabled and
        /// executes skill enabled status actions
        /// </summary>
        /// <param name="skill"></param>
        ///  /// <param name="skillEnableStatusAsset"></param>
        void EnablePassiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset);
    }
}