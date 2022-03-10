using System;
using DG.Tweening;
using Logic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Animation
{
    public class FloatingTextVisualEffect : GameVisualEffects
    {
        /// <summary>
        /// Damage animation canvas.
        /// Referenced in the inspector
        /// </summary>
        [SerializeField] private Canvas canvas;

        /// <summary>
        /// Text Graphic - Default is none and disabled
        /// Referenced in the inspector
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
        [SerializeField] private float doMoveDuration = 1.5f;

        /// <summary>
        /// Additional delay before destroying the game object
        /// </summary>
        [SerializeField] private float delayInterval = 0.5f;
        
        /// <summary>
        /// Floating text end point
        /// </summary>
        [SerializeField] private float yOffset = 50f;

        #endregion
        
        /// <summary>
        /// Total visual effect duration for damage visual effect
        /// </summary>
        public override float VisualEffectDuration => (delayInterval);


        /// <summary>
        /// Plays the damage animation
        /// </summary>
        /// <param name="text"></param>
        public override void PlayVisualEffect(String text)
        {
            var sequence = DOTween.Sequence();
            
            //sets the distance traveled by the floating text
            var yPos = transform.position.y + yOffset;

            //sets the display text
            displayText.text = text;
         
            sequence
                .AppendCallback(()=>
                    transform.DOMoveY(yPos,doMoveDuration,true).SetEase(Ease.InOutQuad)
                )
                .AppendInterval(doMoveDuration)
                .AppendInterval(doMoveDuration*0.1f)
                .AppendCallback(() => Destroy(gameObject));

        }
    }
}
