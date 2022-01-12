﻿using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public class DamageVisualEffect : MonoBehaviour, IDamageVisualEffect
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
        [SerializeField] private float doScaleDuration = 0.2f;
        
        /// <summary>
        /// Scale enhancer
        /// </summary>
        [SerializeField] private float localScaleMultiplier = 1.5f;
        
        /// <summary>
        /// Number of times the animation bounces
        /// </summary>
        [SerializeField] private int doScaleLoopCount = 4;
        
        /// <summary>
        /// Duration of the image fading to full invisible
        /// </summary>
        [SerializeField] private float fadeInterval = 0.2f;
        
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
        [SerializeField] private float delayInterval = 1.5f;

        #endregion

        /// <summary>
        /// Plays the damage animation
        /// </summary>
        /// <param name="damageText"></param>
        public void PlayVisualEffect(int damageText)
        {
            DamageEffect(damageText);

        }
        
        /// <summary>
        /// Damage effect tween animation
        /// </summary>
        /// <param name="damageText"></param>
        private void DamageEffect(int damageText)
        {
            //Display damage animation
            canvasGroup.alpha = fadeAlphaStart;

            //Display damage text
            text.text = "-" + damageText.ToString();
            
            //delay before destroying the game object. Setting delay interval to zero results to error
            var totalInterval = fadeInterval + delayInterval*doScaleLoopCount * doScaleDuration;

            var s = DOTween.Sequence();
            
            //Bounce image animation
            s.AppendCallback(() =>
                    transform.DOScale(transform.localScale * localScaleMultiplier, doScaleDuration)
                        .SetLoops(doScaleLoopCount, LoopType.Yoyo).SetEase(Ease.InOutQuad))
                .AppendInterval(doScaleDuration * doScaleLoopCount)
                .AppendCallback(() =>
                    //Fade the damage image
                    canvasGroup.DOFade(fadeAlphaEnd, fadeInterval))
                
                .AppendInterval(totalInterval)
                .AppendCallback(() => Destroy(gameObject));
        }
    }
}
