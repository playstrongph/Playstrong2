using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public class DamageAnimation : MonoBehaviour
    {
        /// <summary>
        /// Damage animation canvas
        /// </summary>
        [SerializeField] private Canvas canvas;
        
        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private CanvasGroup canvasGroup;
        
        /// <summary>
        /// Damage text
        /// </summary>
        [SerializeField] private TextMeshProUGUI text;

        /// <summary>
        /// Damage cloud
        /// </summary>
        [SerializeField] private Image image;


        #region TWEENER VALUES
        
        /// <summary>
        /// Duration of the change scale animation 
        /// </summary>
        [SerializeField] private float doScaleDuration = 0.2f;
        
        
        [SerializeField] private float localScaleMultiplier = 1.5f;
        [SerializeField] private int doScaleLoopCount = 4;
        [SerializeField] private float fadeInterval = 0.2f;
        [SerializeField] private float fadeAlphaStart = 1.0f;
        [SerializeField] private float fadeAlphaEnd = 0.0f;

        #endregion

        /// <summary>
        /// Plays the damage animation
        /// </summary>
        /// <param name="damageText"></param>
        public void PlayAnimation(int damageText)
        {
            //Display damage animation
            canvasGroup.alpha = fadeAlphaStart;

            //Display damage text
            text.text = "-" + damageText.ToString();
            
            //Bounce image animation
            transform.DOScale(transform.localScale * localScaleMultiplier, doScaleDuration)
                .SetLoops(doScaleLoopCount, LoopType.Yoyo).SetEase(Ease.InOutQuad);
            
            //Fade the damage image
            canvasGroup.DOFade(fadeAlphaEnd, fadeInterval);
        }
    }
}
