using Logic;
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
            //Enable get skill target actions - show valid targets glow
            skill.SkillTargetCollider.GetSkillTargets.EnableGetSkillTargetActions();
            
            //Enable select drag target actions - set hero targets and use hero skill
            skill.SkillTargetCollider.SelectDragTarget.EnableSelectDragTargetActions();
            
            //Show skill glows
            skill.SkillVisual.SkillGlowDisplay.ShowGlow();
        }
        
        /// <summary>
        /// No Action for Basic Skills
        /// </summary>
        /// <param name="skill"></param>
        public override void SkillNotReadyActions(ISkill skill)
        {
        }
        
        
        
        


    }
}
