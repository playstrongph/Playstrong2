using UnityEngine;

namespace Logic
{
    public interface IHeroAndSkillPreviews
    {
        /// <summary>
        /// Returns this as a game object
        /// </summary>
        GameObject ThisGameObject { get; }
    }
}