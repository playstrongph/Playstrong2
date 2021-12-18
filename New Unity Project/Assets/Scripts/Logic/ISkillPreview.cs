using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public interface ISkillPreview
    {

        /// <summary>
        /// Interface reference to skill
        /// </summary>
        ISkill Skill { get; }
        
        /// <summary>
        /// Interface reference to skill preview canvas
        /// </summary>
        Canvas PreviewCanvas { get; }

        /// <summary>
        /// Interface reference to skill preview frame Image
        /// </summary>
        Image FrameImage { get; set; }

        /// <summary>
        /// Interface reference to skill preview graphic image
        /// </summary>
        Image GraphicImage { get; set; }
        
        /// <summary> 
        /// Interface reference to skill preview cooldown
        /// </summary>
        TextMeshProUGUI Cooldown { get;  }
        
        /// <summary>
        /// Interface reference to skill preview name
        /// </summary>
        TextMeshProUGUI PreviewName { get;  }
        
        /// <summary>
        /// Interface reference to skill preview description
        /// </summary>
        TextMeshProUGUI Description { get; }
        
        /// <summary>
        /// Returns this as a game object
        /// </summary>
        GameObject ThisGameObject { get; }
        
        /// <summary>
        /// Loads the skill preview details and sets the board location
        /// </summary>
        ILoadSkillPreviewVisual LoadSkillPreviewVisual { get; }


    }
}