using System;
using DG.Tweening;
using Logic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Animation
{
    public class DamageVisualEffect : GameVisualEffects
    {
        /// <summary>
        /// Damage animation canvas
        /// </summary>
        [SerializeField] private Canvas canvas;
        
        /// <summary>
        /// Canvas group for alpha control, set in the inspector.
        /// </summary>
        [SerializeField] private CanvasGroup canvasGroup = null;
        
        /// <summary>
        /// Damage text, set in the inspector
        /// </summary>
        [SerializeField] private TextMeshProUGUI text = null;

        /// <summary>
        /// Damage cloud
        /// </summary>
        [SerializeField] private Image image;


        #region TWEENER VALUES
        
        /// <summary>
        /// Duration of the change scale animation 
        /// </summary>
        [Header("DO TWEEN VALUES")]
        [SerializeField] private float doScaleDuration = 0.15f;
        
        /// <summary>
        /// Scale enhancer
        /// </summary>
        [SerializeField] private float localScaleMultiplier = 1.6f;
        
        /// <summary>
        /// Number of times the animation bounces
        /// </summary>
        [SerializeField] private int doScaleLoopCount = 4;
        
        /// <summary>
        /// Duration of the image fading to full invisible
        /// </summary>
        [SerializeField] private float fadeInterval = 1;
        
        /// <summary>
        /// Alpha value start, 1 means fully visible 
        /// </summary>
        [SerializeField] private float fadeAlphaStart = 1.0f;
        
        /// <summary>
        /// Alpha value end, 0 means fully invisible
        /// </summary>
        [SerializeField] private float fadeAlphaEnd = 0.0f;
        
        /// <summary>
        /// Additional delay before destroying the game object
        /// </summary>
        [SerializeField] private float delayInterval = 0.1f;

        #endregion
        
        /// <summary>
        /// Total visual effect duration for damage visual effect
        /// </summary>
        public override float VisualEffectDuration => (doScaleDuration * doScaleLoopCount) + fadeInterval;


        /// <summary>
        /// Plays the damage animation
        /// </summary>
        /// <param name="targetedHero"></param>
        public override void PlayVisualEffect(IHero targetedHero)
        {

            //Display damage animation
            canvasGroup.alpha = fadeAlphaStart;
            
            var damageValue = targetedHero.HeroLogic.TakeDamage.FinalDamageTaken;
    
            //Display damage text
            text.text = "-" + damageValue.ToString();

            var s = DOTween.Sequence();
            
            //Bounce image animation
            s.AppendCallback(() =>
                    transform.DOScale(transform.localScale * localScaleMultiplier, doScaleDuration)
                        .SetLoops(doScaleLoopCount, LoopType.Yoyo).SetEase(Ease.InOutQuad))
                .AppendInterval(doScaleDuration * doScaleLoopCount)
                
                .AppendCallback(() =>
                    //Fade the damage image
                    canvasGroup.DOFade(fadeAlphaEnd, fadeInterval))
                
                .AppendInterval(fadeInterval)
                
                .AppendInterval(delayInterval)
                
                .AppendCallback(() => Destroy(gameObject));

        }
    }
}
