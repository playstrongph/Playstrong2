using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public interface IDeadHeroes
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
        /// Used to add hero objects in the living heroes
        /// for inspector troubleshooting purposes only
        /// </summary>
        List<GameObject> HeroesGameObjects { get; }
        
        /// <summary>
        /// Returns list of living heroes as IHero
        ///  Do not directly add to this list
        /// </summary>
        List<IHero> Heroes { get; }
    }
}