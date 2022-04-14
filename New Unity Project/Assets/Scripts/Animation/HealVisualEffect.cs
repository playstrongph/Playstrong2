using System;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.GameAnimationAssets;
using TMPro;
using UnityEngine;

namespace Animation
{
    public class HealVisualEffect : GameVisualEffects
    {
        [SerializeField] private Canvas canvas;

        [SerializeField] private CanvasGroup canvasGroup = null;

        [SerializeField] private TextMeshProUGUI text = null;

        [SerializeField] private GameObject specialEffect;

        [SerializeField] private float delayInterval = 1f;

        [Header("DO TWEEN VALUES")]
        
        [SerializeField] private int fadeInterval = 0;
        [SerializeField]private int fadeAlphaStart = 0;
        [SerializeField] private int fadeAlphaEnd = 0;
        //[SerializeField] private int textDelayInterval = 0;

        private GameObject SpecialEffect
        {
            get => specialEffect;
            set => specialEffect = value as GameObject;
        }
        
        /// <summary>
        /// Total visual effect duration 
        /// </summary>
        public override float VisualEffectDuration => (delayInterval);
        
        
        /// <summary>
        /// This is the healing SFX animation
        /// </summary>
        /// <param name="targetHero"></param>
        public override void PlayVisualEffect(IHero targetHero)
        {
            var s = DOTween.Sequence();

            s.AppendCallback(() =>
                Instantiate(SpecialEffect, targetHero.ThisGameObject.transform));
        }


        /// <summary>
        /// This is the healing text display
        /// </summary>
        /// <param name="localText"></param>
        public override void PlayVisualEffect(string localText)
        {
            text.text = "+" + localText;
            
            //canvasGroup.alpha = fadeAlphaStart;
            canvasGroup.alpha = 0;
            
            var sequence = DOTween.Sequence();
            var fadeInTime = 0.5f;

            sequence
                //Heal amount fade-in sequence
                .AppendInterval(fadeInTime)   
                .AppendCallback(() => canvasGroup.DOFade(fadeAlphaStart, 1))
                .AppendInterval(fadeInTime)
                
                //heal amount fade-out sequence
                .AppendCallback(() => canvasGroup.DOFade(fadeAlphaEnd, fadeInterval))
                
                .AppendInterval(fadeInterval) //Do Fade delay interval
                .AppendInterval(delayInterval) //ensures animation is completed before destroying
                .OnComplete(() => Destroy(gameObject));

        }
    }
}
