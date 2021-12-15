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
        GameObject CrossHair { get; }
        
        /// <summary>
        /// Interface reference to triangle
        /// </summary>
        GameObject Triangle { get; }
        
        /// <summary>
        /// Interface reference to target line
        /// </summary>
        LineRenderer TargetLine { get; }
        
        /// <summary>
        /// Reference to display skill preview
        /// currently no public methods set
        /// </summary>
        IDisplaySkillPreview DisplaySkillPreview { get; }
        
        /// <summary>
        /// Reference to select drag target
        /// </summary>
        ISelectDragTarget SelectDragTarget { get;}

        /// <summary>
        /// Reference to draggable component
        /// </summary>
        IDraggable Draggable { get; }
        
        /// <summary>
        /// Reference to skill target collider as a game object
        /// </summary>
        GameObject ThisGameObject { get; }
        
        /// <summary>
        /// Skill target canvas
        /// </summary>
        Canvas TargetCanvas { get; }
    }
}