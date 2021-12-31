using System;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillReadinessStatusAssets
{
    public abstract class SkillReadinessStatusAsset : ScriptableObject, ISkillReadinessStatusAsset
    {
        /// <summary>
        /// Placeholder for variable requirement in void action method
        /// </summary>
        protected ISkill Skill;
        
        /// <summary>
        /// When skill is disabled, readiness status action is not executed
        /// When skill is enabled, readiness status action is executed
        /// </summary>
        protected Action ReadinessAction;
        
        private void OnEnable()
        {
           //Default setting is for an enabled skill
            ReadinessAction = EnabledStatusAction;
        }

        /// <summary>
        /// Executes skill readiness actions based on skill type
        /// </summary>
        /// <param name="skill"></param>
        public virtual void StatusAction(ISkill skill)
        {
            
        }
        
        
        /// <summary>
        /// When skill is disabled - No Action
        /// </summary>
        /// <param name="skill"></param>
        public void DisabledSkillAction(ISkill skill)
        {
            ReadinessAction = DisabledStatusAction;
        }
        
        /// <summary>
        /// When skill is enabled - default readiness action is executed
        /// </summary>
        /// <param name="skill"></param>
        public void EnabledSkillAction(ISkill skill)
        {
            ReadinessAction = EnabledStatusAction;
        }

        /// <summary>
        /// Status action when skill is enabled
        /// </summary>
        protected virtual void EnabledStatusAction()
        {

        }

        /// <summary>
        /// Status action when skill is disabled
        /// </summary>
        private void DisabledStatusAction()
        {
            
        }
        
        




    }
}
