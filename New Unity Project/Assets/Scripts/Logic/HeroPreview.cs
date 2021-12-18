using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Logic
{
    public class HeroPreview : MonoBehaviour, IHeroPreview
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
        /// Reference to preview canvas
        /// </summary>
        [SerializeField] private Canvas previewCanvas;
        public Canvas PreviewCanvas
        {
            get => previewCanvas;
            set => previewCanvas = value;
        }


        /// <summary>
        /// Preview frame reference
        /// set in Inspector
        /// </summary>
        [SerializeField] 
        private Image frame;
        public Image Frame
        {
            get => frame;
            set => frame = value;
        }
        
        /// <summary>
        /// Preview graphic reference
        /// set in Inspector
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroPreviewGraphic))]
        private Object heroPreviewGraphic;
        public IHeroPreviewGraphic HeroPreviewGraphic
        {
            get => heroPreviewGraphic as IHeroPreviewGraphic;
            set => heroPreviewGraphic = value as Object;
        }
        
        /// <summary>
        /// Preview name reference
        /// set in Inspector
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroPreviewName))]
        private Object heroPreviewName;
        public IHeroPreviewName HeroPreviewName
        {
            get => heroPreviewName as IHeroPreviewName;
            set => heroPreviewName = value as Object;
        }
        
        /// <summary>
        /// Preview attack text reference
        /// set in Inspector
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroPreviewAttack))]
        private Object heroPreviewAttack;
        public IHeroPreviewAttack HeroPreviewAttack
        {
            get => heroPreviewAttack as IHeroPreviewAttack;
            set => heroPreviewAttack = value as Object;
        }
        
        /// <summary>
        /// Preview health text reference
        /// set in Inspector
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroPreviewHealth))]
        private Object heroPreviewHealth;
        public IHeroPreviewHealth HeroPreviewHealth
        {
            get => heroPreviewHealth as IHeroPreviewHealth;
            set => heroPreviewHealth = value as Object;
        }
        
        /// <summary>
        /// Preview speed text reference
        /// set in Inspector
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroPreviewSpeed))]
        private Object heroPreviewSpeed;
        public IHeroPreviewSpeed HeroPreviewSpeed
        {
            get => heroPreviewSpeed as IHeroPreviewSpeed;
            set => heroPreviewSpeed = value as Object;
        }
        
        /// <summary>
        /// Preview speed text reference
        /// set in Inspector
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroPreviewChance))]
        private Object heroPreviewChance;
        public IHeroPreviewChance HeroPreviewChance
        {
            get => heroPreviewChance as IHeroPreviewChance;
            set => heroPreviewChance = value as Object;
        } 
        
        /// <summary>
        /// Reference to preview status effects transform
        /// set in Inspector
        /// </summary>
        [SerializeField] 
        private Transform previewStatusEffects;
        public Transform PreviewStatusEffects
        {
            get => previewStatusEffects;
            set => previewStatusEffects = value;
        }
        
        /// <summary>
        /// Hero preview gameObject
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;

        /// <summary>
        /// Loads the hero preview visuals attributes from the hero asset
        /// </summary>
        public ILoadHeroPreviewVisuals LoadHeroPreviewVisuals { get; private set; }
        
        /// <summary>
        /// Updates the hero preview's basic attributes with the latest
        /// base values
        /// </summary>
        public IUpdateHeroPreview UpdateHeroPreview { get; private set; }

        
        private void Awake()
        {
            LoadHeroPreviewVisuals = GetComponent<ILoadHeroPreviewVisuals>();
            UpdateHeroPreview = GetComponent<IUpdateHeroPreview>();
        }
        
        
    }
}