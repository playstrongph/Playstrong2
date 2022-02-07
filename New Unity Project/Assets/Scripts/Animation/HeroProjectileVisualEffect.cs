using System;
using DG.Tweening;
using Logic;
using UnityEngine;
using UnityEngine.UI;

namespace Animation
{
    public class HeroProjectileVisualEffect : GameVisualEffects
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
        
        /// <summary>
        /// Additional delay before destroying the game object
        /// </summary>
        [SerializeField] private float doMoveDuration = 0.25f;
        
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
        public override float VisualEffectDuration => doScaleDuration + displayInterval + doMoveDuration;

        public override void PlayVisualEffect(IHero casterHero,IHero targetHero)
        {
            //var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;

            //Set projectile image
            image.sprite = casterHero.HeroVisual.HeroGraphic.HeroImage.sprite;

            var s = DOTween.Sequence();

            s.AppendCallback(() =>
                    transform.DOScale(transform.localScale * localScaleMultiplier,
                            doScaleDuration).SetEase(Ease.InOutQuad))
                
                .AppendInterval(doScaleDuration)
                
                .AppendInterval(displayInterval)
                
                .AppendCallback(() =>
                    transform.DOMove(targetHero.ThisGameObject.transform.position, doMoveDuration).SetEase(Ease.InOutQuad))
                
                .AppendInterval(doMoveDuration)
                
                .AppendInterval(delayInterval)
                
                .AppendCallback(() =>
                    Destroy(gameObject));
        }




    }
}
