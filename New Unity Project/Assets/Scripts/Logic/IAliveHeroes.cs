using UnityEngine;

namespace Logic
{
    public interface IAliveHeroes
    {   
        /// <summary>
        /// Reference to player
        /// </summary>
        IPlayer Player { get; }

        /// <summary>
        /// Interface access to alive heroes as game object
        /// </summary>
        GameObject ThisGameObject { get; }
        
        /// <summary>
        /// Gives access to currently displayed portrait and skills based on last hero selected by the player
        /// </summary>
        IDisplayedPortraitAndSkills DisplayedPortraitAndSkills { get; }
    }
}