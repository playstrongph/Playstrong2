using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillEnableStatusAssets
{
    [CreateAssetMenu(fileName = "SkillDisabled", menuName = "Assets/SkillEnableStatus/SkillDisabled")]
    public class SkillDisabledAsset : SkillEnableStatusAsset
    {
        /// <summary>
        /// Skill enabled status action 
        /// </summary>
        /// <param name="skill"></param>
        public override void StatusAction(ISkill skill)
        {
            skill.SkillLogic.UpdateSkillReadiness.DisableSkillReadiness();         
        }





    }
}
