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
        #region SkillReadiness

        /// <summary>
        /// Skill Readiness checks skill enabled status and executes status action depending on skill type
        /// Active and Basic Skills - Enables select drag target, enables target visual,  skill glow, and hides cooldown text 
        /// Passive Skills - hides cooldown text  
        /// </summary>
        /// <param name="skill"></param>
        public virtual void SkillReadyActions(ISkill skill)
        {
        }
        
        /// <summary>
        /// Skill Readiness status action depending on skill type
        /// Active and Basic Skills - Disables select drag target, enables target visual,
        /// skill glow, and shows cooldown text
        /// Passive Skills - shows cooldown text if CD > 0 
        /// </summary>
        /// <param name="skill"></param>
        public virtual void SkillNotReadyActions(ISkill skill)
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
