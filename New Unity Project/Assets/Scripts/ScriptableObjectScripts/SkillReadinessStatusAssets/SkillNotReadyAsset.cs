using System;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillReadinessStatusAssets
{
    [CreateAssetMenu(fileName = "SkillNotReady", menuName = "Assets/SkillReadiness/SkillNotReady")]
    public class SkillNotReadyAsset : SkillReadinessStatusAsset
    {   
       
        /// <summary>
        /// Executes skill readiness actions based on skill type
        /// </summary>
        /// <param name="skill"></param>
        public override void StatusAction(ISkill skill)
        {
            //Initialize local Skill variable
            Skill = skill;
            
            //Default action is EnabledStatusAction
            ReadinessAction();
        }
        
        /// <summary>
        /// This is the default readiness action for skill 'Not Ready'
        /// </summary>
        protected override void EnabledStatusAction()
        {
            Skill.SkillLogic.SkillAttributes.SkillType.SkillNotReadyActions(Skill);
            
        }
        
        


    }
}
