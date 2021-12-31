using System;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillReadinessStatusAssets
{
    [CreateAssetMenu(fileName = "SkillReady", menuName = "Assets/SkillReadiness/SkillReady")]
    public class SkillReadyAsset : SkillReadinessStatusAsset
    {   
       
        /// <summary>
        /// Executes skill readiness actions based on skill type
        /// </summary>
        /// <param name="skill"></param>
        public override void StatusAction(ISkill skill)
        {
            skill.SkillLogic.SkillAttributes.SkillType.SkillReadyActions(skill);
        }

    }
}
