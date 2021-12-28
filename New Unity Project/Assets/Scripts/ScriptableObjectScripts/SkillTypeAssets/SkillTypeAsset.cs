﻿using Logic;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.SkillTypeAssets
{
    /// <summary>
    /// Provides logic for logic execution of skill cooldown, skill readiness, and skill enabled status
    /// </summary>
    public abstract class SkillTypeAsset : ScriptableObject, ISkillTypeAsset
    {
        #region SkillCooldown
        
        /// <summary>
        /// Active skills enabled, disabled if cooldown is less or equal to zero/
        /// Basic Skills disabled/ Passive Skill enabled, disabled if cooldown
        /// less or equal to zero
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
        /// Sets skill cooldown to a specific value (clamped between zero and max skill CD)
        /// based on skill cooldown type - Normal, immutable, or no skill cooldown
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="counter"></param>
        public virtual void SetSkillCooldownValue(ISkill skill, int counter)
        {
        }
        
        #endregion  

        #region SkillReadiness

        /// <summary>
        /// Skill Readiness checks skill enabled status and executes status action depending on skill type
        /// Active and Basic Skills - Enables select drag target, enables target visual,  skill glow, and hides cooldown text 
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
        
        #endregion

        #region SkillEnabledDisabled
        
        /// <summary>
        /// Used by 'Silence' and 'Seal' type effects - sets skill enabled status to skill disabled and
        /// executes skill disabled status actions
        /// </summary>
        /// <param name="skill"></param>
        public virtual void DisableSkill(ISkill skill)
        {
        }
        
        /// <summary>
        /// Used by 'Silence' and 'Seal' type effects - sets skill enabled status to skill enabled and
        /// executes skill enabled status actions
        /// </summary>
        /// <param name="skill"></param>
        public virtual void EnableSkill(ISkill skill)
        {
        }
        
        #endregion
    }
}
