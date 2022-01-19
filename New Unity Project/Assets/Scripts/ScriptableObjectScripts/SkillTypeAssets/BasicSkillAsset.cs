using Logic;
using ScriptableObjectScripts.SkillEnableStatusAssets;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.SkillTypeAssets
{
    [CreateAssetMenu(fileName = "BasicSkill", menuName = "Assets/SkillType/BasicSkill")]
    public class BasicSkillAsset : SkillTypeAsset
    {
        
        /// <summary>
        /// Displays skill glow and enables hero skill targeting
        /// Basic skill readiness status is always 'Ready'
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
        /// No Action for Basic Skills
        /// </summary>
        /// <param name="skill"></param>
        public override void SkillNotReadyActions(ISkill skill)
        {
        }
        
        /// <summary>
        /// No Action
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="skillEnableStatusAsset"></param>
        public override void DisableActiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset)
        {
        }
        
        /// <summary>
        /// No Action
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="skillEnableStatusAsset"></param>
        public override void EnableActiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset)
        {
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
