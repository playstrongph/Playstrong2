using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public interface IPortrait
    {
        /// <summary>
        /// Interface reference to portrait canvas.
        /// Set in the inspector.
        /// </summary>
        Canvas PortraitCanvas { get; }
        
        /// <summary>
        /// Interface reference to portrait frame image.
        /// Set in the inspector.
        /// </summary>
        Image FrameImage { get; }

        /// <summary>
        /// Interface reference to portrait image.
        /// Set in the inspector.
        /// </summary>
        Image PortraitImage { get; set; }
        
        /// <summary>
        /// Interface access to this as a game object
        /// </summary>
        GameObject ThisGameObject { get; }
    }
}