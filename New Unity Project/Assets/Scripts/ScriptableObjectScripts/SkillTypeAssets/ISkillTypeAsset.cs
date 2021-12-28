using Logic;
using TMPro;

namespace ScriptableObjectScripts.SkillTypeAssets
{
    public interface ISkillTypeAsset
    {
        /// <summary>
        /// Active skills enabled, disabled if cooldown is less or equal to zero/
        /// Basic Skills disabled/ Passive Skill enabled, disabled if cooldown
        /// less or equal to zero
        /// </summary>
        /// <param name="text"></param>
        void SkillCooldownTextDisplay(TextMeshProUGUI text);

        /// <summary>
        /// Reduces skill cooldown based on the skill cooldown type - 
        /// Normal cooldown, immutable cooldown, and no skill cooldown
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="counter"></param>
        void ReduceSkillCooldown(ISkill skill, int counter);

        /// <summary>
        /// Resets skill to max skill cooldown based on skill cooldown type - 
        /// Normal cooldown, immutable cooldown, and no skill cooldown
        /// </summary>
        /// <param name="skill"></param>
        void ResetSkillCooldown(ISkill skill);

        /// <summary>
        /// Sets skill cooldown to a specific value (clamped between zero and max skill CD)
        /// based on skill cooldown type - Normal, immutable, or no skill cooldown
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="counter"></param>
        void SetSkillCooldownValue(ISkill skill, int counter);

        /// <summary>
        /// Skill Readiness checks skill enabled status and executes status action depending on skill type
        /// Active and Basic Skills - Enables select drag target, enables target visual,  skill glow, and hides cooldown text 
        /// Passive Skills - hides cooldown text  
        /// </summary>
        /// <param name="skill"></param>
        void SetSkillReady(ISkill skill);

        /// <summary>
        /// Skill Readiness status action depending on skill type
        /// Active and Basic Skills - Disables select drag target, enables target visual,
        /// skill glow, and shows cooldown text
        /// Passive Skills - shows cooldown text if CD > 0 
        /// </summary>
        /// <param name="skill"></param>
        void SetSkillNotReady(ISkill skill);

        /// <summary>
        /// Used by 'Silence' and 'Seal' type effects - sets skill enabled status to skill disabled and
        /// executes skill disabled status actions
        /// </summary>
        /// <param name="skill"></param>
        void DisableSkill(ISkill skill);

        /// <summary>
        /// Used by 'Silence' and 'Seal' type effects - sets skill enabled status to skill enabled and
        /// executes skill enabled status actions
        /// </summary>
        /// <param name="skill"></param>
        void EnableSkill(ISkill skill);
    }
}