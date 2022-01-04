using System;
using Logic;
using ScriptableObjectScripts.StandardActionAssets;
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
        
        /// <summary>
        /// Does nothing
        /// </summary>
        /// <param name="skillAction"></param>
        /// <param name="hero"></param>
        public override void SkillStartAction(ISkillActionAsset skillAction, IHero hero)
        {
            
        }

    }
}
