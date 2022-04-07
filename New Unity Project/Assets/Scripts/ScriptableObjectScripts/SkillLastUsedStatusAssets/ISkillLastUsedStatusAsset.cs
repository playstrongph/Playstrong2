using Logic;

namespace ScriptableObjectScripts.SkillLastUsedStatusAssets
{
    public interface ISkillLastUsedStatusAsset
    {
        /// <summary>
        /// Allows skill cooldown reduction next turn
        /// </summary>
        /// <param name="skill"></param>
        /// /// <param name="counter"></param>
        void StatusAction(ISkill skill,int counter);
    }
}