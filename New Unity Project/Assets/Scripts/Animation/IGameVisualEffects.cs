using Logic;
using TMPro;
using UnityEngine;

namespace Animation
{
    public interface IGameVisualEffects
    {
        /// <summary>
        /// Play visual effect, text argument
        /// </summary>
        /// <param name="text"></param>
        void PlayVisualEffect(TextMeshProUGUI text);

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