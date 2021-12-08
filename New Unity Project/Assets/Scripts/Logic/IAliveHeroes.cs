using UnityEngine;

namespace Logic
{
    public interface IAliveHeroes
    {
        /// <summary>
        /// Interface access to alive heroes as game object
        /// </summary>
        GameObject ThisGameObject { get; }
    }
}