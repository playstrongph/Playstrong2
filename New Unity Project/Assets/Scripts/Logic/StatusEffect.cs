using ScriptableObjectScripts.StatusEffectTypeAssets;
using TMPro;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Logic
{
    public class StatusEffect : MonoBehaviour, IStatusEffect
    {
       
        [SerializeField] private Image icon;
        /// <summary>
        /// StatusEffect icon
        /// </summary>
        public Image Icon
        {
            get => icon;
            set => icon = value;
        }
        
       
        [SerializeField] private TextMeshProUGUI countersText;
        /// <summary>
        /// StatusEffect visual text counters 
        /// </summary>
        public TextMeshProUGUI CountersText
        {
            get => countersText;
            set => countersText = value;
        }

       
        [Header("SET IN RUNTIME")] [SerializeField]
        
        private string statusEffectName;
        /// <summary>
        /// Status effect name 
        /// </summary>
        public string StatusEffectName
        {
            get => statusEffectName;
            set => statusEffectName = value;
        }
        
        
        [SerializeField] private int countersValue;
        
        /// <summary>
        /// Status effect counters duration
        /// </summary>
        public int CountersValue
        {
            get => countersValue;
            set => countersValue = value;
        }
        
        
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IPreviewStatusEffect))]
        private Object previewStatusEffect;
        /// <summary>
        /// Status effect preview reference
        /// </summary>
        public IPreviewStatusEffect PreviewStatusEffect
        {
            get => previewStatusEffect as IPreviewStatusEffect;
            set => previewStatusEffect = value as Object;
        }
        
        /// <summary>
        /// Reference to Hero Status Effects
        /// </summary>
        public IHeroStatusEffects HeroStatusEffects { get; set; }

        [Header("STATUS EFFECT ATTRIBUTES")]
        [SerializeField]
        [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffectTypeAsset))]
        private Object statusEffectType;
        /// <summary>
        /// Status Effect Type Attribute
        /// </summary>
        public IStatusEffectTypeAsset StatusEffectType
        {
            get => statusEffectType as IStatusEffectTypeAsset;
            set => statusEffectType = value as Object;
        }


        
        /// <summary>
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;

    }
}