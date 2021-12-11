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
    }
}