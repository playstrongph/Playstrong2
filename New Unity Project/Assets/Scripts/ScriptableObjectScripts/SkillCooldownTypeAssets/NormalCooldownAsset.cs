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

            skillAttributes.Cooldown -= counter;
            skillAttributes.Cooldown = Mathf.Max(skillAttributes.Cooldown, 0);
            
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
            skillAttributes.Cooldown = Mathf.Min(skillAttributes.Cooldown, maxSkillCooldown);
            
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
            
            
            skillAttributes.Cooldown -= counter;
            skillAttributes.Cooldown = Mathf.Max(skillAttributes.Cooldown, 0);
            
            //TODO: UpdateSkillReadinessStatus
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
            
            skillAttributes.Cooldown = maxSkillCooldown + cooldownCompensation;

            //UpdateSkillReadinessStatus
            skill.SkillLogic.UpdateSkillReadiness.StartAction();
            
            //Update the skill and display skill visual cooldown text
            visualTree.AddCurrent(UpdateSkillCooldownVisual(skill));
        }
        
        
        
        
       
    }
}
