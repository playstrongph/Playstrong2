using System.Collections;
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
            private set => startingSkillEnableStatus = value as ScriptableObject;
        }
        
        /// <summary>
        /// Show skill glow visual
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        protected IEnumerator ShowSkillGlowDisplayVisual(ISkill skill)
        {
            var visualTree = skill.CoroutineTrees.MainVisualTree;
            
            skill.SkillVisual.SkillGlowDisplay.ShowGlow();
            
            visualTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Hide skill glow visual
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        protected IEnumerator HideSkillGlowDisplayVisual(ISkill skill)
        {
            var visualTree = skill.CoroutineTrees.MainVisualTree;
            
            skill.SkillVisual.SkillGlowDisplay.HideGlow();
            
            visualTree.EndSequence();
            yield return null;
        }
        
        
        /// <summary>
        /// Displays "X" graphic over the skill
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        protected IEnumerator DisableSkillVisual(ISkill skill)
        {
            var visualTree = skill.CoroutineTrees.MainVisualTree;

            skill.SkillVisual.SilenceGraphic.enabled = true;

            visualTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Hides "X" graphic over the skill
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        protected IEnumerator EnableSkillVisual(ISkill skill)
        {
            var visualTree = skill.CoroutineTrees.MainVisualTree;

            skill.SkillVisual.SilenceGraphic.enabled = false;
            
            visualTree.EndSequence();
            yield return null;
        }
        
        
       
        public virtual void UpdateSkillReadiness(ISkill skill, IUpdateSkillReadiness updateSkillReadiness)
        {
            var skillCooldown = skill.SkillLogic.SkillAttributes.Cooldown;

            if (skillCooldown <= 0)
                updateSkillReadiness.SetSkillReady();
            else
                updateSkillReadiness.SetSkillNotReady();
        }
        
        //TEST - 14 April 2022
        public virtual void ConsumeFightingSpirit(ISkill skill)
        {
            
        }
        //TEST - END




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
