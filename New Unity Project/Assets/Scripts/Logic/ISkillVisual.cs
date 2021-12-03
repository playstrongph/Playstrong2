using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

namespace Logic
{
    public interface ISkillVisual
    {
        /// <summary>
        /// Interface reference to skill
        /// </summary>
        ISkill Skill { get; }
        
        /// <summary>
        /// Interface reference to the skill canvas
        /// </summary>
        Canvas SkillCanvas { get; }
        
        /// <summary>
        /// Interface reference to the frames' glow image
        /// </summary>
        Image FrameGlowImage { get; }
        
        /// <summary>
        /// Interface reference to the frames' light 2D source 
        /// </summary>
        Light2D FrameLight2D { get; }
        
        /// <summary>
        /// Interface reference to the frames' graphic
        /// </summary>
        Image FrameGraphic { get; }
        
        /// <summary>
        /// Interface reference to the skill graphic
        /// </summary>
        Image SkillGraphic { get; }
        
        /// <summary>
        /// Interface reference to the skill cooldown image
        /// </summary>
        Image CooldownIcon { get; }

        /// <summary>
        /// Interface reference to the skill cooldown text
        /// </summary>
        TextMeshProUGUI CooldownText { get; }
    }
}