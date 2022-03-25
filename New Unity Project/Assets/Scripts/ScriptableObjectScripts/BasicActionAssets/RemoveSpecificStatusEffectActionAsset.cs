using System.Collections;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.GameAnimationAssets;
using ScriptableObjectScripts.StandardActionAssets;
using ScriptableObjectScripts.StatusEffectAssets;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "RemoveSpecificStatusEffectAction", menuName = "Assets/BasicActions/R/RemoveSpecificStatusEffectAction")]
    public class RemoveSpecificStatusEffectActionAsset : BasicActionAsset
    {   
       
        [SerializeField] private ScriptableObject statusEffectAsset;

        private IStatusEffectAsset StatusEffectAsset
        {
            get => statusEffectAsset as IStatusEffectAsset;
            set => statusEffectAsset = value as ScriptableObject;
        }

        /// <summary>
        /// Increase attack logic execution
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            
            RemoveStatusEffect(targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Remove the specific status effect from the hero
        /// </summary>
        /// <param name="hero"></param>
        private void RemoveStatusEffect(IHero hero)
        {
            var buffs = hero.HeroStatusEffects.BuffEffects.StatusEffects;
            var debuffs  = hero.HeroStatusEffects.DebuffEffects.StatusEffects;
            var uniqueStatusEffects = hero.HeroStatusEffects.UniqueStatusEffects.StatusEffects;
            
            foreach (var statusEffect in buffs)
            {
                if (statusEffect.StatusEffectName == StatusEffectAsset.StatusEffectName)
                {
                    statusEffect.RemoveStatusEffect.StartAction(hero);
                }
            }
            
            foreach (var statusEffect in debuffs)
            {
                if (statusEffect.StatusEffectName == StatusEffectAsset.StatusEffectName)
                {
                    statusEffect.RemoveStatusEffect.StartAction(hero);
                }
            }
            
            foreach (var statusEffect in uniqueStatusEffects)
            {
                if (statusEffect.StatusEffectName == StatusEffectAsset.StatusEffectName)
                {
                    statusEffect.RemoveStatusEffect.StartAction(hero);
                }
            }
        }
    }
}
