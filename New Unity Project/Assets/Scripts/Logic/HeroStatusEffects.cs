using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Logic
{
    public class HeroStatusEffects : MonoBehaviour, IHeroStatusEffects
    {
        /// <summary>
        /// Reference to Hero where other
        /// components can be accessed
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHero))]
        private Object hero;
        public IHero Hero
        {
            get => hero as IHero;
            set => hero = value as Object;
        }

        /// <summary>
        /// Reference to status effects canvas
        /// </summary>
        [SerializeField] private Canvas statusEffectsCanvas;
        public Canvas StatusEffectsCanvas
        {
            get => statusEffectsCanvas;
            set => statusEffectsCanvas = value;
        }
        
        [Header("PREFABS")]
        
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffect))]
        private Object statusEffectPrefab;
        /// <summary>
        /// Returns status effect prefab as interface object
        /// </summary>
        public IStatusEffect StatusEffectPrefab
        {
            get => statusEffectPrefab as IStatusEffect;
            private set => statusEffectPrefab = value as Object;
        }

        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IPreviewStatusEffect))]
        private Object previewStatusEffectPrefab;
        /// <summary>
        /// Returns preview status effect prefab as an interface object
        /// </summary>
        public IPreviewStatusEffect PreviewStatusEffectPrefab
        {
            get => previewStatusEffectPrefab as IPreviewStatusEffect;
            private set => previewStatusEffectPrefab = value as Object;
        }
        
        /// <summary>
        /// All hero buff effects
        /// </summary>
        public IBuffEffects BuffEffects { get; private set; }
        
        /// <summary>
        /// All hero debuff effects
        /// </summary>
        public IDebuffEffects DebuffEffects { get; private set; }
        
        /// <summary>
        /// All hero unique status effects
        /// </summary>
        public IUniqueStatusEffects UniqueStatusEffects { get; private set; }

        /// <summary>
        /// Updates all the status effect counters
        /// </summary>
        public IUpdateAllStatusEffectCounters UpdateStatusEffectCounters { get; private set; }

        private void Awake()
        {
            BuffEffects = GetComponent<IBuffEffects>();
            DebuffEffects = GetComponent<IDebuffEffects>();
            UniqueStatusEffects = GetComponent<IUniqueStatusEffects>();
            UpdateStatusEffectCounters = GetComponent<IUpdateAllStatusEffectCounters>();
        }

        
        /// <summary>
        /// Returns a list of all the hero's status effects - buffs, debuffs, unique status effects
        /// </summary>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public List<IStatusEffect> GetAllStatusEffects(IHero targetHero)
        {
            var allStatusEffects = new List<IStatusEffect>();
            
            allStatusEffects.AddRange(targetHero.HeroStatusEffects.BuffEffects.StatusEffects);
            allStatusEffects.AddRange(targetHero.HeroStatusEffects.DebuffEffects.StatusEffects);
            allStatusEffects.AddRange(targetHero.HeroStatusEffects.UniqueStatusEffects.StatusEffects);

            return allStatusEffects;

        }




    }
}