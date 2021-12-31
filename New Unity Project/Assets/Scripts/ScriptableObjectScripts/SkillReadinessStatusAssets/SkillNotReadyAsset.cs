using System;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillReadinessStatusAssets
{
    [CreateAssetMenu(fileName = "SkillNotReady", menuName = "Assets/SkillReadinessStatus/SkillNotReady")]
    public class SkillNotReadyAsset : SkillReadinessStatusAsset
    {   
       
        /// <summary>
        /// Executes skill readiness actions based on skill type
        /// </summary>
        /// <param name="skill"></param>
        public override void StatusAction(ISkill skill)
        {
            skill.SkillLogic.SkillAttributes.SkillType.SkillNotReadyActions(skill);
        }

    }
}
