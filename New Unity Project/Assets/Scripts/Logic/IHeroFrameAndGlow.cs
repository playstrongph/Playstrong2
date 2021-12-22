using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

namespace Logic
{
    public interface IHeroFrameAndGlow
    {   
        /// <summary>
        /// returns the game object component
        /// </summary>
        GameObject ThisGameObject { get; }
        
        /// <summary>
        /// turns on the green border
        /// </summary>
        void EnableActionLightAndGlow();
        
        /// <summary>
        /// turns off the green border
        /// </summary>
        void DisableActionLightAndGlow();
        
        /// <summary>
        /// turns on the red border
        /// </summary>
        void EnableEnemyLightAndGlow();
        
        /// <summary>
        /// turns off the red border
        /// </summary>
        void DisableEnemyLightAndGlow();
        
        /// <summary>
        /// turns on the yellow border
        /// </summary>
        void EnableAllyLightAndGlow();
        
        /// <summary>
        /// turns off the yellow border
        /// </summary>
        void DisableAllyLightAndGlow();
        
        /// <summary>
        /// turns on the taunt frame
        /// </summary>
        void EnableFrameImage();
        
        /// <summary>
        /// turns off the taunt frame
        /// </summary>
        void DisableFrameImage();

    }
}