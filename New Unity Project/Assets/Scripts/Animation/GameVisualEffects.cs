﻿using Logic;
using UnityEngine;

namespace Animation
{
    public abstract class GameVisualEffects : MonoBehaviour, IGameVisualEffects
    {
        /// <summary>
        /// Play visual effect, int argument
        /// </summary>
        /// <param name="value"></param>
        public virtual void PlayVisualEffect(int value)
        {
        }
        
        /// <summary>
        /// Play visual effect, hero argument
        /// </summary>
        /// <param name="hero"></param>
        public virtual void PlayVisualEffect(IHero hero)
        {
        }
        
        /// <summary>
        /// Total visual effect duration in seconds
        /// </summary>
        public float VisualEffectDuration { get; protected set; }

        public GameObject ThisGameObject => this.gameObject;
    }
}
