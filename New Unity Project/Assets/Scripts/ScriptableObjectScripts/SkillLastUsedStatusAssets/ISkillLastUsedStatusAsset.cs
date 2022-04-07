using Logic;

namespace ScriptableObjectScripts.SkillReadinessStatusAssets
{
    public interface ISkillLastUsedStatusAsset
    {
        /// <summary>
        /// Allows skill cooldown reduction next turn
        /// </summary>
        /// <param name="skill"></param>
        void StatusAction(ISkill skill);
    }
}