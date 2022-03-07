using System;
using DG.Tweening;
using Logic;
using UnityEngine;
using UnityEngine.UI;

namespace Animation
{
    public class HeroPreActionVisualEffect : GameVisualEffects
    {
        /// <summary>
        /// Set in the inspector
        /// </summary>
        [SerializeField] private Canvas canvas;

        /// <summary>
        /// Set in the inspector
        /// </summary>
        [SerializeField] private CanvasGroup canvasGroup;
        
        /// <summary>
        /// Set in the inspector
        /// </summary>
        [SerializeField] private Image image = null;
        
        [Header("DO TWEEN VALUES")]
        [SerializeField] private float doScaleDuration = 0.2f;
        
        /// <summary>
        /// Scale enhancer
        /// </summary>
        [SerializeField] private float localScaleMultiplier = 1.5f;
        
        /*/// <summary>
        /// Additional delay before destroying the game object
        /// </summary>
        [SerializeField] private float doMoveDuration = 0.25f;*/
        
        /// <summary>
        /// Delay between do scale and do move
        /// </summary>
        [SerializeField] private float displayInterval = 0.2f;
        
        /// <summary>
        /// Additional delay before destroying the game object
        /// </summary>
        [SerializeField] private float delayInterval = 0.1f;
        
        /// <summary>
        /// Total visual effect duration for hero projectile visual effect
        /// </summary>
        public override float VisualEffectDuration => doScaleDuration + displayInterval;
        
        
        /// <summary>
        /// Scales the caster hero to indicate action
        /// No targetHero requirements - only for argument signature
        /// </summary>
        /// <param name="casterHero"></param>
        public override void PlayVisualEffect(IHero casterHero)
        {
            //Set projectile image
            image.sprite = casterHero.HeroVisual.HeroGraphic.HeroImage.sprite;

            var s = DOTween.Sequence();

            s.AppendCallback(() =>
                    transform.DOScale(transform.localScale * localScaleMultiplier,
                            doScaleDuration).SetEase(Ease.InOutQuad))
                
                .AppendInterval(doScaleDuration)
                
                .AppendInterval(displayInterval)

                .AppendInterval(delayInterval)
                
                .AppendCallback(() =>
                    Destroy(gameObject));
        }




    }
}
