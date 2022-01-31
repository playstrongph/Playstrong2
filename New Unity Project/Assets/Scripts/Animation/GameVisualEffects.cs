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
        public virtual float VisualEffectDuration { get => 0; protected set => value = 0; }

        public GameObject ThisGameObject => this.gameObject;
    }
}
