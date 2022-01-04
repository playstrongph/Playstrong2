using System;
using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.SkillReadinessStatusAssets
{
    [CreateAssetMenu(fileName = "SkillReady", menuName = "Assets/SkillReadinessStatus/SkillReady")]
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
        
       /// <summary>
       /// Executes skill action's skill start action when skill readiness is in 'SkillReady' state
       /// </summary>
       /// <param name="skillAction"></param>
       /// <param name="hero"></param>
        public override void SkillStartAction(ISkillActionAsset skillAction, IHero hero)
        {
            skillAction.SkillStartAction(hero);
        }

    }
}
