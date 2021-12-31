using Logic;

namespace ScriptableObjectScripts.SkillEnableStatusAssets
{
    public interface ISkillEnabledAsset
    {
        /// <summary>
        /// Skill enabled status action - SkillEnabled and SkillDisabled
        /// </summary>
        /// <param name="skill"></param>
        void StatusAction(ISkill skill);
    }
}