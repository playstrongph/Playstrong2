using UnityEngine;

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



    }
}