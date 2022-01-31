using System;
using DG.Tweening;
using Logic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Animation
{
    public class HeroAttributeTextBounceVisualEffect : GameVisualEffects
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
        /// Damage cloud
        /// </summary>
        [SerializeField] private Image image;
        
        /// <summary>
        /// Display text
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI displayText = null;


        #region TWEENER VALUES
        
        /// <summary>
        /// Duration of the change scale animation 
        /// </summary>
        [Header("DO TWEEN VALUES")]
        [SerializeField] private float doScaleDuration = 0.2f;
        
        /// <summary>
        /// Scale enhancer
        /// </summary>
        [SerializeField] private float localScaleMultiplier = 1.4f;
        
        /// <summary>
        /// Number of times the animation bounces
        /// </summary>
        [SerializeField] private int doScaleLoopCount = 2;

        /// <summary>
        /// Additional delay before destroying the game object
        /// </summary>
        [SerializeField] private float delayInterval = 0.1f;

        #endregion
        
        /// <summary>
        /// Total visual effect duration for damage visual effect
        /// </summary>
        public override float VisualEffectDuration => (doScaleDuration * doScaleLoopCount);


        /// <summary>
        /// Plays the damage animation
        /// </summary>
        /// <param name="text"></param>
        public override void PlayVisualEffect(TextMeshProUGUI text)
        {
            //Set display text properties
            displayText.fontStyle = text.fontStyle;
            displayText.fontSize = text.fontSize;
            displayText.faceColor = text.faceColor;
            displayText.color = text.color;
            displayText.text = text.text;
            displayText.transform.position = text.transform.position;
            
            //Display damage animation
            //canvasGroup.alpha = 1;


            var s = DOTween.Sequence();
            
            //Bounce image animation
            s.AppendCallback(() =>
                    transform.DOScale(transform.localScale * localScaleMultiplier, doScaleDuration)
                        .SetLoops(doScaleLoopCount, LoopType.Yoyo).SetEase(Ease.InOutQuad))
                .AppendInterval(doScaleDuration * doScaleLoopCount)
                .AppendInterval(delayInterval)
                .AppendCallback(() => Destroy(gameObject));

        }
    }
}
