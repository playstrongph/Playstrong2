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
        
        
    }
}