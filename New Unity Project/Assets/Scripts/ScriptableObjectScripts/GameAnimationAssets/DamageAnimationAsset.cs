using Animation;
using DG.Tweening;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.GameAnimationAssets
{
    [CreateAssetMenu(fileName = "DamageAnimation", menuName = "Assets/GameAnimations/DamageAnimation")]
    public class DamageAnimationAsset : GameAnimationsAsset
    {
        //[SerializeField] private GameObject damageVisualEffectPrefab = null;

        public override void PlayAnimation(IHero hero, int value)
        {
            /*var damageVisualEffectGameObject = Instantiate(damageVisualEffectPrefab, hero.ThisGameObject.transform);
            var damageVisualEffect = damageVisualEffectGameObject.GetComponent<IGameVisualEffects>();

            damageVisualEffect.PlayVisualEffect(value);*/
            
            
            //TEST
            foreach (var gameVisualEffect in GameVisualEffects)
            {
                var gameVisualEffectObject = Instantiate(gameVisualEffect.ThisGameObject, hero.ThisGameObject.transform);
                var visualEffect = gameVisualEffectObject.GetComponent<IGameVisualEffects>();

                visualEffect.PlayVisualEffect(value);
            }
        }
            

    }
}
