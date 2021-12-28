using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillCooldownTypeAssets
{
    
    [CreateAssetMenu(fileName = "NormalCooldown", menuName = "Assets/SkillCooldownType/NormalCooldown")]
    public class NormalCooldownAsset : SkillCooldownTypeAsset
    {
        /// <summary>
        /// Reduces the value of the skill cooldown and skill cooldown text
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="counter"></param>
        public override void ReduceCooldown(ISkill skill, int counter)
        {
            var skillAttributes = skill.SkillLogic.SkillAttributes;
            var maxSkillCooldown = skillAttributes.BaseCooldown;
            
            skillAttributes.Cooldown -= counter;
            skillAttributes.Cooldown = Mathf.Clamp(skillAttributes.Cooldown, 0, maxSkillCooldown);
            
            //TODO: UpdateSkillReadinessStatus
            
            //Update the skill and display skill visual cooldown text
            skill.SkillVisual.UpdateSkillCooldownVisual.StartAction(skillAttributes.Cooldown);
        }
        
        /// <summary>
        /// Increases the value of the skill cooldown and skill cooldown text
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="counter"></param>
        public override void IncreaseCooldown(ISkill skill, int counter)
        {
            var skillAttributes = skill.SkillLogic.SkillAttributes;
            var maxSkillCooldown = skillAttributes.BaseCooldown;
            
            skillAttributes.Cooldown += counter;
            skillAttributes.Cooldown = Mathf.Clamp(skillAttributes.Cooldown, 0, maxSkillCooldown);
            
            //TODO: UpdateSkillReadinessStatus
            
            //Update the skill and display skill visual cooldown text
            skill.SkillVisual.UpdateSkillCooldownVisual.StartAction(skillAttributes.Cooldown);
        }
        
        /// <summary>
        /// Sets the value of the skill cooldown and text to a specific value
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="value"></param>
        public override void SetCooldownToValue(ISkill skill, int value)
        {
            var skillAttributes = skill.SkillLogic.SkillAttributes;
            var maxSkillCooldown = skillAttributes.BaseCooldown;
            
            skillAttributes.Cooldown = value;
            skillAttributes.Cooldown = Mathf.Clamp(skillAttributes.Cooldown, 0, maxSkillCooldown);
            
            //TODO: UpdateSkillReadinessStatus
            
            //Update the skill and display skill visual cooldown text
            skill.SkillVisual.UpdateSkillCooldownVisual.StartAction(skillAttributes.Cooldown);
        }
        
        /// <summary>
        /// Sets the value of the skill cooldown and text to a specific value
        /// </summary>
        /// <param name="skill"></param>
        public override void ResetCooldownToMax(ISkill skill)
        {
            var skillAttributes = skill.SkillLogic.SkillAttributes;
            var maxSkillCooldown = skillAttributes.BaseCooldown;
            
            skillAttributes.Cooldown = maxSkillCooldown;

            //TODO: UpdateSkillReadinessStatus
            
            //Update the skill and display skill visual cooldown text
            skill.SkillVisual.UpdateSkillCooldownVisual.StartAction(skillAttributes.Cooldown);
        }
        
        public override void RefreshCooldownToZero(ISkill skill)
        {
            var skillAttributes = skill.SkillLogic.SkillAttributes;

            skillAttributes.Cooldown = 0;

            //TODO: UpdateSkillReadinessStatus
            
            //Update the skill and display skill visual cooldown text
            skill.SkillVisual.UpdateSkillCooldownVisual.StartAction(skillAttributes.Cooldown);
        }
        
        
        
        
       
    }
}
