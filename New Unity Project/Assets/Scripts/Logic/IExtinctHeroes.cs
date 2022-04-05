using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public interface IExtinctHeroes
    {
        IPlayer Player { get; }

        /// <summary>
        /// Returns list of living heroes as IHero
        /// Do not directly add to this list
        /// </summary>
        List<IHero> Heroes { get; }

        /// <summary>
        /// Provides access to heroes list as game objects 
        /// </summary>
        List<GameObject> HeroesGameObjects { get; }

        /// <summary>
        /// Returns this as a game object
        /// </summary>
        GameObject ThisGameObject { get; }
    }
}