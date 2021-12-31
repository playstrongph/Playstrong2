using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillEnableStatusAssets
{
    [CreateAssetMenu(fileName = "SkillEnabled", menuName = "Assets/SkillEnableStatus/SkillEnabled")]
    public class SkillEnabledAsset : SkillEnableStatusAsset
    {
        /// <summary>
        /// Skill enabled status action 
        /// </summary>
        /// <param name="skill"></param>
        public override void StatusAction(ISkill skill)
        {
            skill.SkillLogic.UpdateSkillReadiness.EnableSkillReadiness();         
        }





    }
}
