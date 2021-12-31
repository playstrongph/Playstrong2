using Logic;
using ScriptableObjectScripts.SkillEnableStatusAssets;
using ScriptableObjectScripts.SkillReadinessStatusAssets;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.SkillTypeAssets
{
    [CreateAssetMenu(fileName = "ActiveSkill", menuName = "Assets/SkillType/ActiveSkill")]
    public class ActiveSkillAsset : SkillTypeAsset
    {

        /// <summary>
        /// Displays skill glow and enables hero skill targeting
        /// </summary>
        /// <param name="skill"></param>
        public override void SkillReadyActions(ISkill skill)
        {
            //Enable get skill target actions - show valid targets glow
            skill.SkillTargetCollider.GetSkillTargets.EnableGetSkillTargetActions();
            
            //Enable select drag target actions - set hero targets and use hero skill
            skill.SkillTargetCollider.SelectDragTarget.EnableSelectDragTargetActions();
            
            //Show skill glows
            skill.SkillVisual.SkillGlowDisplay.ShowGlow();
        }
        
        /// <summary>
        /// Hides skill glow and disables hero skill targeting
        /// </summary>
        /// <param name="skill"></param>
        public override void SkillNotReadyActions(ISkill skill)
        {
            //Enable get skill target actions - show valid targets glow
            skill.SkillTargetCollider.GetSkillTargets.DisableGetSkillTargetsActions();
            
            //Enable select drag target actions - set hero targets and use hero skill
            skill.SkillTargetCollider.SelectDragTarget.DisableSelectDragTargetActions();
            
            //Show skill glows
            skill.SkillVisual.SkillGlowDisplay.HideGlow();
        }
        
        public override void DisableActiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset)
        {
            //Set active skill enable status to SkillDisabled
            skill.SkillLogic.SkillAttributes.SkillEnableStatus = skillEnableStatusAsset;
            
            //Execute skill disabled status action
            skill.SkillLogic.SkillAttributes.SkillEnableStatus.StatusAction(skill);
        }
        
        public override void EnableActiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset)
        {
            //Set active skill enable status to SkillDisabled
            skill.SkillLogic.SkillAttributes.SkillEnableStatus = skillEnableStatusAsset;
            
            //Execute skill disabled status action
            skill.SkillLogic.SkillAttributes.SkillEnableStatus.StatusAction(skill);
        }
        
        
        
        


    }
}
