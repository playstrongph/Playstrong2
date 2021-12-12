using UnityEngine;

namespace Logic
{
    public interface IDisplayPortraits
    {
        /// <summary>
        /// Reference to display portrait as a game object
        /// </summary>
        GameObject ThisGameObject { get; }
    }
}