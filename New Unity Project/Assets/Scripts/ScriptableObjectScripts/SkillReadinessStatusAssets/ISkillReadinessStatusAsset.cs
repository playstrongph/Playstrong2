using Logic;

namespace ScriptableObjectScripts.SkillReadinessStatusAssets
{
    public interface ISkillReadinessStatusAsset
    {
        /// <summary>
        /// Executes skill readiness actions based on skill type
        /// </summary>
        /// <param name="skill"></param>
        void StatusAction(ISkill skill);
        
        /// <summary>
        /// When skill is disabled - No Action
        /// </summary>
        /// <param name="skill"></param>
        void DisabledSkillAction(ISkill skill);

        /// <summary>
        /// When skill is enabled - default readiness action is executed
        /// </summary>
        /// <param name="skill"></param>
        void EnabledSkillAction(ISkill skill);
    }
}