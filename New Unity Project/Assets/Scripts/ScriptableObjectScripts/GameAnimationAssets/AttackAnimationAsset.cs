using Animation;
using DG.Tweening;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.GameAnimationAssets
{
    [CreateAssetMenu(fileName = "AttackAnimation", menuName = "Assets/GameAnimations/AttackAnimation")]
    public class AttackAnimationAsset : GameAnimationsAsset
    {
        /*[SerializeField] 
        private GameObject attackProjectilePrefab = null;*/
        
        
        /// <summary>
        /// Play animation in visual effects
        /// </summary>
        /// <param name="casterHero"></param>
        public override void PlayAnimation(IHero casterHero)
        {
            /*var attackProjectileGameObject = Instantiate(attackProjectilePrefab, casterHero.ThisGameObject.transform);
            var attackProjectile = attackProjectileGameObject.GetComponent<IGameVisualEffects>();
            
            attackProjectile.PlayVisualEffect(casterHero);*/
            
            foreach (var gameVisualEffect in GameVisualEffects)
            {
                var gameVisualEffectObject = Instantiate(gameVisualEffect.ThisGameObject, casterHero.ThisGameObject.transform);
                var visualEffect = gameVisualEffectObject.GetComponent<IGameVisualEffects>();
                
                visualEffect.PlayVisualEffect(casterHero);
            }
            
        }

    }
}
