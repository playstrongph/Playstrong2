using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Logic
{
    public class StatusEffect : MonoBehaviour, IStatusEffect
    {
        /// <summary>
        /// StatusEffect icon
        /// </summary>
        [SerializeField] private Image icon;

        public Image Icon
        {
            get => icon;
            set => icon = value;
        }
        
        /// <summary>
        /// StatusEffect visual text counters 
        /// </summary>
        [SerializeField] private TextMeshProUGUI countersText;

        public TextMeshProUGUI CountersText
        {
            get => countersText;
            set => countersText = value;
        }

        
        
        
        /// <summary>
        /// Status effect name 
        /// </summary>
        ///
        [Header("SET IN RUNTIME")] [SerializeField]
        private string statusEffectName;

        public string StatusEffectName
        {
            get => statusEffectName;
            set => statusEffectName = value;
        }
        
        /// <summary>
        /// Status effect counters duration
        /// </summary>
        [SerializeField] private int countersValue;
        public int CountersValue
        {
            get => countersValue;
            set => countersValue = value;
        }
        
        /// <summary>
        /// Status effect preview reference
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IPreviewStatusEffect))]
        private Object previewStatusEffect;

        public IPreviewStatusEffect PreviewStatusEffect
        {
            get => previewStatusEffect as IPreviewStatusEffect;
            set => previewStatusEffect = value as Object;
        }

    }
}
