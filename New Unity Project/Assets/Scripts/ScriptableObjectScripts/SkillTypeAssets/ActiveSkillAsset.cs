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
            var visualTree = skill.CoroutineTrees.MainVisualTree;
            
            //Enable get skill target actions - show valid targets glow
            skill.SkillTargetCollider.GetSkillTargets.EnableGetSkillTargetActions();
            
            //Enable select drag target actions - set hero targets and use hero skill
            skill.SkillTargetCollider.SelectDragTarget.EnableSelectDragTargetActions();
            
            //Show skill glows
            visualTree.AddCurrent(ShowSkillGlowDisplayVisual(skill));
        }
        
        /// <summary>
        /// Hides skill glow and disables hero skill targeting
        /// </summary>
        /// <param name="skill"></param>
        public override void SkillNotReadyActions(ISkill skill)
        {
            var visualTree = skill.CoroutineTrees.MainVisualTree;
            
            //Enable get skill target actions - show valid targets glow
            skill.SkillTargetCollider.GetSkillTargets.DisableGetSkillTargetsActions();
            
            //Enable select drag target actions - set hero targets and use hero skill
            skill.SkillTargetCollider.SelectDragTarget.DisableSelectDragTargetActions();
            
            //Show skill glows
            visualTree.AddCurrent(HideSkillGlowDisplayVisual(skill));
        }
        
        public override void DisableActiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset)
        {
            //Set skill enable status to SkillDisabled
            skill.SkillLogic.SkillAttributes.SkillEnableStatus = skillEnableStatusAsset;
            
            //Execute skill disabled status action
            skill.SkillLogic.SkillAttributes.SkillEnableStatus.StatusAction(skill);
            
            //TODO:TEST
            var visualTree = skill.CoroutineTrees.MainVisualTree;
            visualTree.AddCurrent(DisableSkillVisual(skill));

        }
        
        public override void EnableActiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset)
        {
            //Set skill enable status to SkillDisabled
            skill.SkillLogic.SkillAttributes.SkillEnableStatus = skillEnableStatusAsset;
            
            //Execute skill disabled status action
            skill.SkillLogic.SkillAttributes.SkillEnableStatus.StatusAction(skill);
            
            //TODO:TEST
            var visualTree = skill.CoroutineTrees.MainVisualTree;
            visualTree.AddCurrent(EnableSkillVisual(skill));
        }
        
        /// <summary>
        /// No Action
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="skillEnableStatusAsset"></param>
        public override void DisablePassiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset)
        {
        }
        
        /// <summary>
        /// No Action
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="skillEnableStatusAsset"></param>
        public override void EnablePassiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset)
        {
        }
        
        


    }
}
