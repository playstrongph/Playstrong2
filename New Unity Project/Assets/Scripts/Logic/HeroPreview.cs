using UnityEngine;
using UnityEngine.UI;


namespace Logic
{
    public class HeroPreview : MonoBehaviour, IHeroPreview
    {
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
        /// Preview text reference
        /// set in Inspector
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroPreviewText))]
        private Object heroPreviewText;
        public IHeroPreviewText HeroPreviewText
        {
            get => heroPreviewText as IHeroPreviewText;
            set => heroPreviewText = value as Object;
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
        /// Status Effects preview reference
        /// set in Inspector
        /// </summary>
        [SerializeField] 
        private Canvas previewStatusEffects;
        public Canvas PreviewStatusEffects
        {
            get => previewStatusEffects;
            set => previewStatusEffects = value;
        }


        
      
        
        
    }
}
