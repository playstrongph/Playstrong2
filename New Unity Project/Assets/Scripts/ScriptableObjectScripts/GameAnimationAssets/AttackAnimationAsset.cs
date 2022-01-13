using Animation;
using DG.Tweening;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.GameAnimationAssets
{
    [CreateAssetMenu(fileName = "AttackAnimation", menuName = "Assets/GameAnimations/AttackAnimation")]
    public class AttackAnimationAsset : GameAnimationsAsset
    {
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IAttackProjectile))]
        private GameObject attackProjectilePrefab = null;
        
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
        /// Additional delay before destroying the game object
        /// </summary>
        [SerializeField] private float doMoveDuration = 0.1f;
        
        /// <summary>
        /// Additional delay before destroying the game object
        /// </summary>
        [SerializeField] private float delayInterval = 0.1f;

        public override void PlayAnimation(IHero casterHero, int value)
        {
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            var attackProjectileGameObject = Instantiate(attackProjectilePrefab, casterHero.ThisGameObject.transform);
            var attackProjectile = attackProjectileGameObject.GetComponent<IAttackProjectile>();
            var projectileGraphic = casterHero.HeroVisual.HeroGraphic.HeroImage.sprite;
            var totalInterval = (1 + delayInterval) * (doMoveDuration + doScaleDuration);
            
            //Set Projectile Graphic
            attackProjectile.SetProjectileGraphic(projectileGraphic);


            var s = DOTween.Sequence();

            s.AppendCallback(() =>
                    attackProjectileGameObject.transform
                        .DOScale(attackProjectileGameObject.transform.localScale * localScaleMultiplier,
                            doScaleDuration)
                        .SetEase(Ease.InOutQuad))
                .AppendInterval(doScaleDuration)
                .AppendCallback(() =>
                    attackProjectileGameObject.transform
                        .DOMove(targetedHero.ThisGameObject.transform.position, doMoveDuration).SetEase(Ease.InOutQuad))
                .AppendInterval(doMoveDuration)
                .AppendInterval(totalInterval)
                .AppendCallback(() =>
                    Destroy(attackProjectileGameObject));

        }


    }
}
