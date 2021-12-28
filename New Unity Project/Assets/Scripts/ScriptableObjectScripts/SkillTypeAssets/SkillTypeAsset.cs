using Logic;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.SkillTypeAssets
{
    public abstract class SkillTypeAsset : MonoBehaviour
    {
        /// <summary>
        /// Active skills enabled, disabled if cooldown <= 0
        /// Basic Skills disabled
        /// Passive Skill enabled, disabled if cooldown <= 0
        /// </summary>
        /// <param name="text"></param>
        public virtual void SkillCooldownTextDisplay(TextMeshProUGUI text)
        {
        }
        
        /// <summary>
        /// Reduces skill cooldown based on the skill cooldown type - 
        /// Normal cooldown, immutable cooldown, and no skill cooldown
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="counter"></param>
        public virtual void ReduceSkillCooldown(ISkill skill, int counter)
        {
        }   
        
        /// <summary>
        /// Resets skill to max skill cooldown based on skill cooldown type - 
        /// Normal cooldown, immutable cooldown, and no skill cooldown
        /// </summary>
        /// <param name="skill"></param>
        public virtual void ResetSkillCooldown(ISkill skill)
        {
        }
        
        /// <summary>
        /// Skill Readiness status action depending on skill type
        /// Active and Basic Skills - Enables select drag target, enables target visual,
        /// skill glow, and hides cooldown text
        /// Passive Skills - hides cooldown text 
        /// </summary>
        /// <param name="skill"></param>
        public virtual void SetSkillReady(ISkill skill)
        {
        }
        
        /// <summary>
        /// Skill Readiness status action depending on skill type
        /// Active and Basic Skills - Disables select drag target, enables target visual,
        /// skill glow, and shows cooldown text
        /// Passive Skills - shows cooldown text if CD > 0 
        /// </summary>
        /// <param name="skill"></param>
        public virtual void SetSkillNotReady(ISkill skill)
        {
        }
        
        







    }
}
