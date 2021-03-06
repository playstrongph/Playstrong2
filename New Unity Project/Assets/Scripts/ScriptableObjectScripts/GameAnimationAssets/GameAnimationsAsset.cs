using System;
using System.Collections.Generic;
using Animation;
using Logic;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScriptableObjectScripts.GameAnimationAssets
{
    [CreateAssetMenu(fileName = "GenericAnimation", menuName = "Assets/GameAnimations/GenericAnimation")]
    public class GameAnimationsAsset : ScriptableObject, IGameAnimationsAsset
    {
        
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IGameVisualEffects))]
        private List<Object> gameVisualEffects = new List<Object>();
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
        
        /// <summary>
        /// Play animation - single hero argument
        /// </summary>
        /// <param name="hero"></param>
        public void PlayAnimation(IHero hero)
        {
            foreach (var gameVisualEffect in GameVisualEffects)
            {
                var gameVisualEffectObject = Instantiate(gameVisualEffect.ThisGameObject, hero.ThisGameObject.transform);
                var visualEffect = gameVisualEffectObject.GetComponent<IGameVisualEffects>();
                
                visualEffect.PlayVisualEffect(hero);
            }
        }
        
        /// <summary>
        /// Play animation - single hero argument
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void PlayAnimation(IHero casterHero,IHero targetHero)
        {
            foreach (var gameVisualEffect in GameVisualEffects)
            {
                var gameVisualEffectObject = Instantiate(gameVisualEffect.ThisGameObject, casterHero.ThisGameObject.transform);
                var visualEffect = gameVisualEffectObject.GetComponent<IGameVisualEffects>();
                
                visualEffect.PlayVisualEffect(casterHero,targetHero);
            }
        }
        
        /// <summary>
        /// Play animation  - Text arrgument 
        /// </summary>
        /// <param name="text"></param>
        public void PlayAnimation(TextMeshProUGUI text)
        {
            foreach (var gameVisualEffect in GameVisualEffects)
            {
                var gameVisualEffectObject = Instantiate(gameVisualEffect.ThisGameObject, text.gameObject.transform);
                
                var visualEffect = gameVisualEffectObject.GetComponent<IGameVisualEffects>();
                
                visualEffect.PlayVisualEffect(text);
            }
        }
        
        public void PlayAnimation(String text,IHero targetHero)
        {
            foreach (var gameVisualEffect in GameVisualEffects)
            {
                var gameVisualEffectObject = Instantiate(gameVisualEffect.ThisGameObject, targetHero.ThisGameObject.transform);
                
                var visualEffect = gameVisualEffectObject.GetComponent<IGameVisualEffects>();
                
                visualEffect.PlayVisualEffect(text);
            }
        }

    }
}
