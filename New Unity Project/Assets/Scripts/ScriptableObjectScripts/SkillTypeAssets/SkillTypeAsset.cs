using Logic;
using ScriptableObjectScripts.SkillEnableStatusAssets;
using ScriptableObjectScripts.SkillReadinessStatusAssets;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.SkillTypeAssets
{
    /// <summary>
    /// Provides logic for logic execution of skill cooldown, skill readiness, and skill enabled status
    /// </summary>
    public abstract class SkillTypeAsset : ScriptableObject, ISkillTypeAsset
    {
        
        /// <summary>
        /// Default starting skill readiness status for each skill type
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkillReadinessStatusAsset))]
        private ScriptableObject startingSkillReadiness;
        public ISkillReadinessStatusAsset StartingSkillReadiness
        {
            get => startingSkillReadiness as ISkillReadinessStatusAsset;
            private set => startingSkillReadiness = value as ScriptableObject;
        }

        /// <summary>
        /// Default - Skill Enabled
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkillEnableStatusAsset))]
        private ScriptableObject startingSkillEnableStatus;
        public ISkillEnableStatusAsset StartingSkillEnableStatus
        {
            get => startingSkillEnableStatus as ISkillEnableStatusAsset;
            private set => startingSkillReadiness = value as ScriptableObject;
        }




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
        /// Used by 'Silence' type effects - sets skill enabled status to skill disabled
        /// and executes skill disabled status actions
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="skillEnableStatusAsset"></param>
        public virtual void DisableActiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset)
        {
        }
        
        /// <summary>
        /// Used by 'Silence' type effects - sets skill enabled status to skill disabled
        /// and executes skill disabled status actions
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="skillEnableStatusAsset"></param>
        public virtual void EnableActiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset)
        {
        }
        
        /// <summary>
        /// Used by 'Seal' type effects - sets skill enabled status to skill disabled
        /// and executes skill disabled status actions
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="skillEnableStatusAsset"></param>
        public virtual void DisablePassiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset)
        {
        }
        
        /// <summary>
        /// Used by 'Seal' type effects - sets skill enabled status to skill disabled
        /// and executes skill disabled status actions
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="skillEnableStatusAsset"></param>
        public virtual void EnablePassiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset)
        {
        }
        
        #endregion
    }
}
