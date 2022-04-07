using Logic;
using ScriptableObjectScripts.SkillEnableStatusAssets;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.SkillTypeAssets
{
    [CreateAssetMenu(fileName = "PassiveSkill", menuName = "Assets/SkillType/PassiveSkill")]
    public class PassiveSkillAsset : SkillTypeAsset
    {
        public override void DisablePassiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset)
        {
            //Set skill enable status to SkillDisabled
            skill.SkillLogic.SkillAttributes.SkillEnableStatus = skillEnableStatusAsset;
            
            //Execute skill disabled status action
            skill.SkillLogic.SkillAttributes.SkillEnableStatus.StatusAction(skill);
            
            //Note: this is for preview skills, which have no skillEffectAsset
            if (skill.SkillLogic.SkillEffect != null)  
            {
                skill.SkillLogic.SkillEffect.UnsubscribeSkillEffect(skill);
                skill.SkillLogic.SkillEffect.UnsubscribeSkillEffect(skill.CasterHero);    
            }
            
            //Display "X" visual
            var visualTree = skill.CoroutineTrees.MainVisualTree;
            visualTree.AddCurrent(DisableSkillVisual(skill));
        }
        
        public override void EnablePassiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset)
        {
            //Set skill enable status to SkillDisabled
            skill.SkillLogic.SkillAttributes.SkillEnableStatus = skillEnableStatusAsset;
            
            //Execute skill disabled status action
            skill.SkillLogic.SkillAttributes.SkillEnableStatus.StatusAction(skill);
            
            //Note: this is for preview skills, which have no skillEffectAsset
            if (skill.SkillLogic.SkillEffect != null)
            {
                skill.SkillLogic.SkillEffect.SubscribeSkillEffect(skill);
                skill.SkillLogic.SkillEffect.SubscribeSkillEffect(skill.CasterHero);    
            }
            
            //Remove "X" visual
            var visualTree = skill.CoroutineTrees.MainVisualTree;
            visualTree.AddCurrent(EnableSkillVisual(skill));
        }
        
        /// <summary>
        /// No Action 
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="skillEnableStatusAsset"></param>
        public override void DisableActiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset)
        {
           // Leave blank
        }
        
        /// <summary>
        /// No Action
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="skillEnableStatusAsset"></param>
        public override void EnableActiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset)
        {
            // Leave blank
        }
        
        /// <summary>
        /// No Action
        /// </summary>
        /// <param name="skill"></param>
        public override void SkillReadyActions(ISkill skill)
        {
            // Leave blank: Visual Purposes only
         
        }
        
        /// <summary>
        /// No Action
        /// </summary>
        /// <param name="skill"></param>
        public override void SkillNotReadyActions(ISkill skill)
        {
            // Leave blank: Visual Purposes only
        }
        
        
        

    }
}
