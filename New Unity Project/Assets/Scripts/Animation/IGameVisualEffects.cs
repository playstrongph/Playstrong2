using Logic;
using UnityEngine;

namespace Animation
{
    public interface IGameVisualEffects
    {
        /// <summary>
        /// Play visual effect, int argument
        /// </summary>
        /// <param name="value"></param>
        void PlayVisualEffect(int value);

        /// <summary>
        /// Play visual effect, hero argument
        /// </summary>
        /// <param name="hero"></param>
        void PlayVisualEffect(IHero hero);
        
        /// <summary>
        /// Total visual effect duration in seconds
        /// </summary>
        float VisualEffectDuration { get; }

        /// <summary>
        /// Returns the game visual effect as a game object
        /// </summary>
        GameObject ThisGameObject { get; }
    }
}