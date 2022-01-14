using System.Collections.Generic;
using Animation;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.GameAnimationAssets
{
    [CreateAssetMenu(fileName = "GenericAnimation", menuName = "Assets/GameAnimations/GenericAnimation")]
    public class GameAnimationsAsset : ScriptableObject, IGameAnimationsAsset
    {
        public void PlayAnimation(IHero hero)
        {
            foreach (var gameVisualEffect in GameVisualEffects)
            {
                var gameVisualEffectObject = Instantiate(gameVisualEffect.ThisGameObject, hero.ThisGameObject.transform);
                var visualEffect = gameVisualEffectObject.GetComponent<IGameVisualEffects>();
                
                visualEffect.PlayVisualEffect(hero);
            }
        }

        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IGameVisualEffects))]
        private List<Object> gameVisualEffects;
        /// <summary>
        /// Visual effects to be used in the animation
        /// </summary>
        private List<IGameVisualEffects> GameVisualEffects
        {
            get
            {
                var visualEffects = new List<IGameVisualEffects>();
                foreach (var visualEffect in gameVisualEffects)
                {
                    visualEffects.Add(visualEffect as IGameVisualEffects);
                }
                return visualEffects;
            }
        }

        /// <summary>
        /// Sum of all visual effect durations
        /// </summary>
        public float AnimationDuration
        {
            get
            {
                float duration = 0;
                foreach (var visualEffect in GameVisualEffects)
                {
                    duration += visualEffect.VisualEffectDuration;
                }

                return duration;
            }
            private set => value = 0;
        }
    }
}
