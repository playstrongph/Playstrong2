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
        /// Additional delay before destroying the game object
        /// </summary>
        [SerializeField] private float delayInterval = 0.1f;

        public override void PlayVisualEffect(IHero casterHero)
        {
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            var destroyDelayInterval = delayInterval*(doMoveDuration + doScaleDuration);
            
            //Set projectile image
            image.sprite = casterHero.HeroVisual.HeroGraphic.HeroImage.sprite;

            var s = DOTween.Sequence();

            s.AppendCallback(() =>
                    transform.DOScale(transform.localScale * localScaleMultiplier,
                            doScaleDuration).SetEase(Ease.InOutQuad))
                
                .AppendInterval(doScaleDuration)
                
                .AppendCallback(() =>
                    transform.DOMove(targetedHero.ThisGameObject.transform.position, doMoveDuration).SetEase(Ease.InOutQuad))
                
                .AppendInterval(doMoveDuration)
                .AppendInterval(destroyDelayInterval)
                .AppendCallback(() =>
                    Destroy(gameObject));
        }




    }
}
