using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public interface ISkillTargetCollider
    {
        /// <summary>
        /// Interface reference to skill
        /// </summary>
        ISkill Skill { get; }
        
        /// <summary>
        /// Interface reference to crossHair
        /// </summary>
        Image CrossHair { get; }
        
        /// <summary>
        /// Interface reference to triangle
        /// </summary>
        Image Triangle { get; }
        
        /// <summary>
        /// Interface reference to target line
        /// </summary>
        LineRenderer TargetLine { get; }
        
        /// <summary>
        /// Reference to display skill preview
        /// currently no public methods set
        /// </summary>
        IDisplaySkillPreview DisplaySkillPreview { get; }
    }
}