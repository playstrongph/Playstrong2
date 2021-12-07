using UnityEngine;

namespace Logic
{
    public interface IHeroSkills
    {
        
        /// <summary>
        /// Interface access to this as a game object
        /// </summary>
        GameObject ThisGameObject { get; }
    }
}