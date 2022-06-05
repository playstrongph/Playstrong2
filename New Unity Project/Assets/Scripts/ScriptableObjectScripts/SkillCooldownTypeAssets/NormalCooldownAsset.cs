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
        public override void DecreaseCooldown(ISkill skill, int counter)
        {
            var visualTree = skill.CoroutineTrees.MainVisualTree;
            var skillAttributes = skill.SkillLogic.SkillAttributes;
            var maxSkillCooldown = skillAttributes.BaseCooldown;

            skillAttributes.Cooldown -= counter;
            
            //skillAttributes.Cooldown = Mathf.Max(skillAttributes.Cooldown, 0);
            
            //Clamp to 0 in case of negative values
            //Clamp to maxSkillCooldown for higher values
            skillAttributes.Cooldown = Mathf.Clamp(skillAttributes.Cooldown, 0, maxSkillCooldown);
            
            //TODO: UpdateSkillReadinessStatus
            skill.SkillLogic.UpdateSkillReadiness.StartAction();
            
            //Update the skill and display skill visual cooldown text
            visualTree.AddCurrent(UpdateSkillCooldownVisual(skill));
        }
        
        /// <summary>
        /// Increases the value of the skill cooldown and skill cooldown text
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="counter"></param>
        public override void IncreaseCooldown(ISkill skill, int counter)
        {
            var visualTree = skill.CoroutineTrees.MainVisualTree;
            var skillAttributes = skill.SkillLogic.SkillAttributes;
            var maxSkillCooldown = skillAttributes.BaseCooldown;
            
            skillAttributes.Cooldown += counter;
            
            //skillAttributes.Cooldown = Mathf.Min(skillAttributes.Cooldown, maxSkillCooldown);
            
            //Clamp to 0 in case of negative values
            //Clamp to maxSkillCooldown for higher values
            skillAttributes.Cooldown = Mathf.Clamp(skillAttributes.Cooldown, 0, maxSkillCooldown);
            
            //TODO: UpdateSkillReadinessStatus
            skill.SkillLogic.UpdateSkillReadiness.StartAction();
            
            //Update the skill and display skill visual cooldown text
            visualTree.AddCurrent(UpdateSkillCooldownVisual(skill));
        }
        
        /// <summary>
        /// Sets the value of the skill cooldown and text to a specific value
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="value"></param>
        public override void SetCooldownToValue(ISkill skill, int value)
        {
            var visualTree = skill.CoroutineTrees.MainVisualTree;
            var skillAttributes = skill.SkillLogic.SkillAttributes;
            var maxSkillCooldown = skillAttributes.BaseCooldown;
            
            skillAttributes.Cooldown = value;
            
            skillAttributes.Cooldown = Mathf.Clamp(skillAttributes.Cooldown, 0, maxSkillCooldown);
            
            //TODO: UpdateSkillReadinessStatus
            skill.SkillLogic.UpdateSkillReadiness.StartAction();
            
            //Update the skill and display skill visual cooldown text
            visualTree.AddCurrent(UpdateSkillCooldownVisual(skill));
        }
        
        /// <summary>
        /// Sets the value of the skill cooldown and text to a specific value
        /// </summary>
        /// <param name="skill"></param>
        public override void ResetCooldownToMax(ISkill skill)
        {
            var visualTree = skill.CoroutineTrees.MainVisualTree;
            var skillAttributes = skill.SkillLogic.SkillAttributes;
            var maxSkillCooldown = skillAttributes.BaseCooldown;
            
            skillAttributes.Cooldown = maxSkillCooldown;

            //TODO: UpdateSkillReadinessStatus
            skill.SkillLogic.UpdateSkillReadiness.StartAction();
            
            //Update the skill and display skill visual cooldown text
            visualTree.AddCurrent(UpdateSkillCooldownVisual(skill));
        }
        
        /// <summary>
        /// Sets the value of the skill cooldown to zero
        /// </summary>
        /// <param name="skill"></param>
        public override void RefreshCooldownToZero(ISkill skill)
        {
            var visualTree = skill.CoroutineTrees.MainVisualTree;
            var skillAttributes = skill.SkillLogic.SkillAttributes;

            skillAttributes.Cooldown = 0;

            //TODO: UpdateSkillReadinessStatus
            skill.SkillLogic.UpdateSkillReadiness.StartAction();
            
            //Update the skill and display skill visual cooldown text
            visualTree.AddCurrent(UpdateSkillCooldownVisual(skill));
        }
        
        /// <summary>
        /// Reduces the skill cooldown at the end of the hero turn
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="counter"></param>
        public override void TurnControllerReduceCooldown(ISkill skill, int counter = 1)
        {
            var visualTree = skill.CoroutineTrees.MainVisualTree;
            var skillAttributes = skill.SkillLogic.SkillAttributes;

            //TODO: Transfer this to skill last used turn status
            //skillAttributes.Cooldown -= counter;
            //skillAttributes.Cooldown = Mathf.Max(skillAttributes.Cooldown, 0);
            
            //TODO Test
            skillAttributes.SkillLastUsedStatus.StatusAction(skill,counter);
            
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

            skillAttributes.Cooldown = maxSkillCooldown;
            
            //Update skill readiness and start its action
            //TODO: Removed - skill readiness update happens at useSkill/HeroStartTurn?
            //skill.SkillLogic.UpdateSkillReadiness.StartAction();

            //Update the skill and display skill visual cooldown text
            visualTree.AddCurrent(UpdateSkillCooldownVisual(skill));
        }

        public override void UpdateSkillReadiness(ISkill skill)
        {
            var visualTree = skill.CoroutineTrees.MainVisualTree;
            
            //Skill Type check and Skill Enabled Check
            skill.SkillLogic.UpdateSkillReadiness.StartAction();
            
            //TODO - is this required?
            //Update the skill and display skill visual cooldown text
            visualTree.AddCurrent(UpdateSkillCooldownVisual(skill));
        }





    }
}
