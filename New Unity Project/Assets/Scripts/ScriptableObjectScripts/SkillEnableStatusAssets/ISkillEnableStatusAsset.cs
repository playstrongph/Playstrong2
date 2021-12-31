using Logic;

namespace ScriptableObjectScripts.SkillEnableStatusAssets
{
    public interface ISkillEnableStatusAsset
    {
        /// <summary>
        /// Enabled/Disabled skills status action
        /// </summary>
        /// <param name="skill"></param>
        void StatusAction(ISkill skill);
    }
}