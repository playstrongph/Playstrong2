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
            var visualTree = skill.CoroutineTrees.MainVisualTree;
            var skillAttributes = skill.SkillLogic.SkillAttributes;
            
            
            skillAttributes.Cooldown -= counter;
            skillAttributes.Cooldown = Mathf.Max(skillAttributes.Cooldown, 0);
            
            //Update skill readiness and start its action
            skill.SkillLogic.UpdateSkillReadiness.StartAction();

            //Update the skill and display skill visual cooldown text
            visualTree.AddCurrent(UpdateSkillCooldownVisual(skill));
        }
        
        /// <summary>
        /// Resets the skill cooldown back to base cooldown after using a skill
        /// </summary>
        /// <param name="skill"></param>
        public override void UseSkillResetCooldown(ISkill skill)
        {
            var visualTree = skill.CoroutineTrees.MainVisualTree;
            var skillAttributes = skill.SkillLogic.SkillAttributes;
            var maxSkillCooldown = skillAttributes.BaseCooldown;
            
            //Compensates for the skill cooldown reduction right after the skill is used
            var cooldownCompensation = 1;
            
            skillAttributes.Cooldown = maxSkillCooldown;

            //Update skill readiness and start its action
            skill.SkillLogic.UpdateSkillReadiness.StartAction();
            
            //Update the skill and display skill visual cooldown text
            visualTree.AddCurrent(UpdateSkillCooldownVisual(skill));
            
            //TODO - Temp, need a better solution
            skillAttributes.Cooldown += cooldownCompensation;
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
