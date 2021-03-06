using System;
using ScriptableObjectScripts.StatusEffectAssets;
using ScriptableObjectScripts.StatusEffectCastingStatusAssets;
using ScriptableObjectScripts.StatusEffectCountersUpdateTypeAssets;
using ScriptableObjectScripts.StatusEffectCounterTypeAssets;
using ScriptableObjectScripts.StatusEffectInstanceTypeAssets;
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
        [SerializeField]
        private string statusEffectName;
        /// <summary>
        /// Status effect name 
        /// </summary>
        public string StatusEffectName
        {
            get => statusEffectName;
            set => statusEffectName = value;
        }
        
        [SerializeField]
        [TextArea(1,2)]
        private string statusEffectDescription;
        /// <summary>
        /// Status effect description
        /// </summary>
        public string StatusEffectDescription
        {
            get => statusEffectDescription;
            set => statusEffectDescription = value;
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
        
        [SerializeField] private Image icon;
        /// <summary>
        /// StatusEffect icon
        /// </summary>
        public Image Icon
        {
            get => icon;
            set => icon = value;
        }
        
        [SerializeField] private Image frame;
        /// <summary>
        /// StatusEffect frame
        /// </summary>
        public Image Frame
        {
            get => frame;
            set => frame = value;
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

        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffectAsset))]
        private Object statusEffectAsset;
        
        /// <summary>
        /// Status effect asset reference
        /// </summary>
        public IStatusEffectAsset StatusEffectAsset
        {
            get => statusEffectAsset as IStatusEffectAsset;
            set => statusEffectAsset = value as Object;
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

        [Header("STATUS EFFECT ATTRIBUTES")]
        [SerializeField]
        [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffectTypeAsset))]
        private Object statusEffectType;
        /// <summary>
        /// Status Effect Type Attribute - Buff, Debuff, Unique
        /// </summary>
        public IStatusEffectTypeAsset StatusEffectType
        {
            get => statusEffectType as IStatusEffectTypeAsset;
            set => statusEffectType = value as Object;
        }

        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffectCounterTypeAsset))]
        private Object statusEffectCounterType;
        
        /// <summary>
        /// Status effect counter type attribute - Normal or Immutable 
        /// </summary>
        public IStatusEffectCounterTypeAsset StatusEffectCounterType
        {
            get => statusEffectCounterType as IStatusEffectCounterTypeAsset;
            set => statusEffectCounterType = value as Object;
        }

        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffectCounterUpdateTypeAsset))]
        private Object statusEffectCounterUpdateType;
        
        /// <summary>
        /// Counter update types - start turn update, end turn update, and no update
        /// </summary>
        public IStatusEffectCounterUpdateTypeAsset StatusEffectCounterUpdateType
        {
            get => statusEffectCounterUpdateType as IStatusEffectCounterUpdateTypeAsset;
            set => statusEffectCounterUpdateType = value as Object;
        }

        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffectInstanceTypeAsset))]
        private Object statusEffectInstanceType;
        /// <summary>
        /// Status effect instance type - single, multiple
        /// </summary>
        public IStatusEffectInstanceTypeAsset StatusEffectInstanceType
        {
            get => statusEffectInstanceType as IStatusEffectInstanceTypeAsset;
            set => statusEffectInstanceType = value as Object;
        }

        [Header("STATUS EFFECT STATUSES")]
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffectCastingStatusAsset))]
        private Object statusEffectCastingStatus;
        
        public IStatusEffectCastingStatusAsset StatusEffectCastingStatus
        {
            get => statusEffectCastingStatus as IStatusEffectCastingStatusAsset;
            set => statusEffectCastingStatus = value as Object;
        }

        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHero))]
        private Object statusEffectTargetHero;
        
        /// <summary>
        /// The hero where the status effect is attached to
        /// </summary>
        public IHero StatusEffectTargetHero
        {
            get => statusEffectTargetHero as IHero;
            set => statusEffectTargetHero = value as Object;
        }
        
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHero))]
        private Object statusEffectCasterHero;
        
        /// <summary>
        /// The caster of the status effect
        /// </summary>
        public IHero StatusEffectCasterHero
        {
            get => statusEffectCasterHero as IHero;
            set => statusEffectCasterHero = value as Object;
        }


        /// <summary>
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;

        /// <summary>
        /// Update status effect counters component
        /// </summary>
        public IUpdateStatusEffectCounters UpdateStatusEffectCounters { get; private set; }
        
        /// <summary>
        /// Load the status effect asset values and create unique standard actions, and components
        /// </summary>
        public ILoadStatusEffectAsset LoadStatusEffectAsset { get; private set; }

        /// <summary>
        /// Removes the status effect and its game objects
        /// </summary>
        public IRemoveStatusEffect RemoveStatusEffect { get; private set; }
        
        /// <summary>
        /// Sets the status effect casting status to "fresh" or "old"
        /// </summary>
        public IUpdateStatusEffectCastingStatus UpdateStatusEffectCastingStatus { get; private set;}
        
        /// <summary>
        /// Shows or hides the status effect symbol
        /// </summary>
        public IStatusEffectSymbol StatusEffectSymbol { get; private set; }



        private void Awake()
        {
            UpdateStatusEffectCounters = GetComponent<UpdateStatusEffectCounters>();
            LoadStatusEffectAsset = GetComponent<ILoadStatusEffectAsset>();
            RemoveStatusEffect = GetComponent<IRemoveStatusEffect>();
            UpdateStatusEffectCastingStatus = GetComponent<IUpdateStatusEffectCastingStatus>();
            StatusEffectSymbol = GetComponent<IStatusEffectSymbol>();
        }
    }
}