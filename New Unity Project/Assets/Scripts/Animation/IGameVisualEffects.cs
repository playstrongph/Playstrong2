using System;
using Logic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Animation
{
    public interface IGameVisualEffects
    {
        /// <summary>
        /// Play visual effect, textMeshPro argument
        /// </summary>
        /// <param name="text"></param>
        void PlayVisualEffect(TextMeshProUGUI text);
        
        
        /// <summary>
        /// Play visual effect, text argument
        /// </summary>
        /// <param name="text"></param>
        void PlayVisualEffect(String text);

        /// <summary>
        /// Play visual effect, hero argument
        /// </summary>
        /// <param name="hero"></param>
        void PlayVisualEffect(IHero hero);

        /// <summary>
        /// Play visual effect - caster to target hero effect (2 arguments)
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void PlayVisualEffect(IHero casterHero, IHero targetHero);
        
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