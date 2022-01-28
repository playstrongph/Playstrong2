using System;
using ScriptableObjectScripts.StatusEffectCastingStatusAssets;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Logic
{
    public class UpdateStatusEffectCastingStatus : MonoBehaviour, IUpdateStatusEffectCastingStatus
    {

        private IStatusEffect _statusEffect;

        private void Awake()
        {
            _statusEffect = GetComponent<IStatusEffect>();
        }


        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffectCastingStatusAsset))]
        private Object freshCastAsset;
        
        /// <summary>
        /// When the target hero and caster hero of the status effect is the same this turn
        /// Example circumstances - Buff all allies (the caster hero is also a target). 
        /// </summary>
        private IStatusEffectCastingStatusAsset FreshCastAsset
        {
            get => freshCastAsset as IStatusEffectCastingStatusAsset;
            set => freshCastAsset = value as Object;
        }
        
        /// <summary>
        /// When the target hero and caster hero of the status effect are not the same this turn
        /// All status effects become old cast status at the end of the hero's turn, during turn reduce counters 
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffectCastingStatusAsset))]
        private Object oldCastAsset;

        private IStatusEffectCastingStatusAsset OldCastAsset
        {
            get => oldCastAsset as IStatusEffectCastingStatusAsset;
            set => oldCastAsset = value as Object;
        }
        
        /// <summary>
        /// Set to fresh cast status
        /// </summary>
        public void SetFreshCastStatus()
        {
            _statusEffect.StatusEffectCastingStatus = FreshCastAsset;
        }
        
        /// <summary>
        /// Set to old cast status
        /// </summary>
        public void SetOldCastStatus()
        {
            _statusEffect.StatusEffectCastingStatus = OldCastAsset;
        }




    }
}
