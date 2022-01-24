using ScriptableObjectScripts.StatusEffectCountersUpdateTypeAssets;
using ScriptableObjectScripts.StatusEffectCounterTypeAssets;
using ScriptableObjectScripts.StatusEffectInstanceTypeAssets;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectAssets
{
    public class StatusEffectAsset : ScriptableObject, IStatusEffectAsset
    {
        [SerializeField] private string statusEffectName = "";
        
        /// <summary>
        /// Status effect name - SLOW, HASTE, etc.
        /// </summary>
        public string StatusEffectName
        {
            get => statusEffectName;
            private set => value = "";
        }
        
        [TextArea(1,2)]
        [SerializeField] private string description = "";
        /// <summary>
        /// What the status effect does - increase attack by 50%
        /// </summary>
        public string Description
        {
            get => description;
            private set => value = "";
        }

        [SerializeField] private Sprite icon;
        
        /// <summary>
        /// The status effect image icon
        /// </summary>
        public Sprite Icon
        {
            get => icon;
            private set => icon = value;
        }

        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffectCounterUpdateTypeAsset))]
        private Object statusEffectCounterUpdateType;
        /// <summary>
        /// When shall the counters be update - Start turn or End turn
        /// </summary>
        public IStatusEffectCounterUpdateTypeAsset StatusEffectCounterUpdateType
        {
            get => statusEffectCounterUpdateType as IStatusEffectCounterUpdateTypeAsset;
            private set => statusEffectCounterUpdateType = value as Object;
        }

        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffectInstanceTypeAsset))]
        private Object statusEffectInstanceType;
        /// <summary>
        /// How many instances of the status effect are allowed - single, multiple
        /// </summary>
        public IStatusEffectInstanceTypeAsset StatusEffectInstanceType
        {
            get => statusEffectInstanceType as IStatusEffectInstanceTypeAsset;
            private set => statusEffectInstanceType = value as Object;
        }

        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffectCounterTypeAsset))]
        private Object statusEffectCounterType;
        /// <summary>
        /// What are the counter type updates - immutable, no change, normal
        /// </summary>
        public IStatusEffectCounterTypeAsset StatusEffectCounterType
        {
            get => statusEffectCounterType as IStatusEffectCounterTypeAsset;
            private set => statusEffectCounterType = value as Object;
        }
        
        










    }
}
