using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillCooldownTypeAssets
{
    
    [CreateAssetMenu(fileName = "ImmutableCooldown", menuName = "Assets/SkillCooldownType/ImmutableCooldown")]
    public class ImmutableCooldownAsset : SkillCooldownTypeAsset
    {

        /// <summary>
        /// Reduces the skill cooldown at the end of the hero turn
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="counter"></param>
        public override void TurnControllerReduceCooldown(ISkill skill, int counter = 1)
        {
            var skillAttributes = skill.SkillLogic.SkillAttributes;
            var maxSkillCooldown = skillAttributes.BaseCooldown;
            
            skillAttributes.Cooldown -= counter;
            skillAttributes.Cooldown = Mathf.Clamp(skillAttributes.Cooldown, 0, maxSkillCooldown);
            
            //TODO: UpdateSkillReadinessStatus
            
            //Update the skill and display skill visual cooldown text
            skill.SkillVisual.UpdateSkillCooldownVisual.StartAction();
        }
        
        /// <summary>
        /// Resets the skill cooldown back to base cooldown after using a skill
        /// </summary>
        /// <param name="skill"></param>
        public override void UseSkillResetCooldown(ISkill skill)
        {
            var skillAttributes = skill.SkillLogic.SkillAttributes;
            var maxSkillCooldown = skillAttributes.BaseCooldown;
            
            skillAttributes.Cooldown = maxSkillCooldown;

            //TODO: UpdateSkillReadinessStatus
            
            //Update the skill and display skill visual cooldown text
            skill.SkillVisual.UpdateSkillCooldownVisual.StartAction();
        }
        
        
        public override void DecreaseCooldown(ISkill skill, int counter)
        {
        }

        public override void IncreaseCooldown(ISkill skill, int counter)
        {
        }
        
        public override void SetCooldownToValue(ISkill skill, int value)
        {
        }

        public override void ResetCooldownToMax(ISkill skill)
        {
        }

        public override void RefreshCooldownToZero(ISkill skill)
        {
        }

    }
}
