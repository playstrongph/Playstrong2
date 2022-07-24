using System;
using System.Text;
using Logic;
using TMPro;
using UnityEngine;

namespace Animation
{
    public abstract class GameVisualEffects : MonoBehaviour, IGameVisualEffects
    {
        /// <summary>
        /// Play visual effect, text argument
        /// </summary>
        /// <param name="text"></param>
        public virtual void PlayVisualEffect(TextMeshProUGUI text)
        {
        }
        
        
        public virtual void PlayVisualEffect(String text)
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
        /// Play visual effect, hero argument, and int value
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="value"></param>
        public virtual void PlayVisualEffect(IHero hero,int value)
        {
        }
        
        /// <summary>
        /// Play visual effect - caster to target hero effect (2 arguments)
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public virtual void PlayVisualEffect(IHero casterHero,IHero targetHero)
        {
        }
        
        /// <summary>
        /// Total visual effect duration in seconds
        /// </summary>
        public virtual float VisualEffectDuration { get => 0; protected set => value = 0; }

        public GameObject ThisGameObject => this.gameObject;
    }
}
