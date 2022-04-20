using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace Logic
{
    public class RemoveStatusEffect : MonoBehaviour, IRemoveStatusEffect
    {

        [SerializeField] private List<ScriptableObject> deathExemptionList = new List<ScriptableObject>();
        
        /// <summary>
        /// Status effects not to be removed at death
        /// </summary>
        private List<IStatusEffectAsset> DeathExemptionList
        {
            get
            {
                var exemptedList = new List<IStatusEffectAsset>();
                foreach (var statusEffectObject in deathExemptionList)
                {
                    var statusEffect = statusEffectObject as IStatusEffectAsset;
                    exemptedList.Add(statusEffect);
                }

                return exemptedList;
            }
        }

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
        /// Remove status effects not part of the exemption list when the hero dies
        /// </summary>
        /// <param name="hero"></param>
        public void RemoveAtDeath(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            //Need to use status effect name because of status effect asset "clones"
            var exemptionListNames = new List<String>();
            
            //Name of status effect to be checked against the exemption list
            var statusEffectName = _statusEffect.StatusEffectName;

            foreach (var exemptStatusEffectAsset in DeathExemptionList)
            {
               exemptionListNames.Add(exemptStatusEffectAsset.StatusEffectName);
            }
            
            //if status effect is not in the exemption list, you can remove
            if(!exemptionListNames.Contains(statusEffectName))
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

            Debug.Log("Remove Status Effect: DestroyGameObjects");
                
            var statusEffectPreviewObject = _statusEffect.PreviewStatusEffect.ThisGameObject;
            
                if(statusEffectPreviewObject!=null)
                    Destroy(statusEffectPreviewObject);
            
                if(this.gameObject != null)
                    Destroy(this.gameObject);    
            

            
        }

    }
}
