using DG.Tweening;
using Logic;
using UnityEngine;

namespace Animation
{
    public class DeathVisualEffect : GameVisualEffects
    {
        [SerializeField] private GameObject specialEffect;

        [SerializeField] private float delayInterval = 1f;
        
        private GameObject SpecialEffect
        {
            get => specialEffect;
            set => specialEffect = value as GameObject;
        }
        
        /// <summary>
        /// Total visual effect duration for damage visual effect
        /// </summary>
        public override float VisualEffectDuration => (delayInterval);

        public override void PlayVisualEffect(IHero targetHero)
        {
            var s = DOTween.Sequence();

            s.AppendCallback(() =>
                    Instantiate(SpecialEffect, targetHero.ThisGameObject.transform))
                
                .AppendInterval(delayInterval)
                
                .AppendCallback(() => Destroy(gameObject));
        }

    }
}
