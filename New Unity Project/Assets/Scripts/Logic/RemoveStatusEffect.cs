using System;
using System.Collections;
using UnityEngine;

namespace Logic
{
    public class RemoveStatusEffect : MonoBehaviour, IRemoveStatusEffect
    {

        private IStatusEffect _statusEffect;

        private void Awake()
        {
            _statusEffect = GetComponent<IStatusEffect>();
        }
        
        /// <summary>
        /// Removes and destroys the status effect
        /// </summary>
        /// <param name="hero"></param>
        public void StartAction(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            logicTree.AddCurrent(RemoveEffect(hero));
        }
        
        /// <summary>
        /// Reverses the statusEffect 'effect' and destroys it 
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        private IEnumerator RemoveEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            var heroStatusEffects = hero.HeroStatusEffects;

            //Unapply status effect action
            _statusEffect.StatusEffectAsset.UnsubscribeAction(hero);
            
            //TEST
            //TODO: fix hero,hero
            //_statusEffect.StatusEffectAsset.UndoApplyAction(hero,hero);
            
            //Removes status effect from the respective list - buff, debuff, or unique status effects list
            _statusEffect.StatusEffectType.RemoveFromStatusEffectsList(heroStatusEffects,_statusEffect);
            
            //Destroys the status effect game object and preview game object
            logicTree.AddCurrent(DestroyStatusEffectAndPreviewGameObjects(hero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// logic tree wrapper
        /// </summary>
        /// <param name="hero"></param>
        private IEnumerator DestroyStatusEffectAndPreviewGameObjects(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            var visualTree = hero.CoroutineTrees.MainVisualTree;
            
            visualTree.AddCurrent(DestroyStatusEffectAndPreviewGameObjectsVisual(hero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Destroys the status effect, and status effect preview visual game objects
        /// </summary>
        /// <param name="hero"></param>
        private IEnumerator DestroyStatusEffectAndPreviewGameObjectsVisual(IHero hero)
        {
            var visualTree = hero.CoroutineTrees.MainVisualTree;

            DestroyGameObjects();
            
            visualTree.EndSequence();
            yield return null;
        }

        private void DestroyGameObjects()
        {
            var statusEffectPreviewObject = _statusEffect.PreviewStatusEffect.ThisGameObject;
            
            if(statusEffectPreviewObject!=null)
                Destroy(statusEffectPreviewObject);
            
            if(this.gameObject != null)
                Destroy(this.gameObject);
        }

    }
}
