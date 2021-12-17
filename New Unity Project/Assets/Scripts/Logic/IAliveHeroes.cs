using System.Collections.Generic;
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
        
        /// <summary>
        /// Used to add hero objects in the living heroes
        /// for inspector troubleshooting purposes only
        /// </summary>
        List<Object> HeroesList { get; }
        
        /// <summary>
        /// Returns list of living heroes as IHero
        ///  Do not directly add to this list
        /// </summary>
        List<IHero> Heroes { get; }
    }
}