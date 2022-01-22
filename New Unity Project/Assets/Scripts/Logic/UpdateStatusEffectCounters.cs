using System;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Updates the individual status effect counter`
    /// </summary>
    public class UpdateStatusEffectCounters : MonoBehaviour, IUpdateStatusEffectCounters
    {
        private IStatusEffect _statusEffect;

        private void Awake()
        {
            _statusEffect = GetComponent<IStatusEffect>();
        }
        
        /// <summary>
        /// Increase the status effect counters by the specified amount
        /// based on counter type
        /// </summary>
        /// <param name="counters"></param>
        public void IncreaseCounters(int counters)
        {
            _statusEffect.StatusEffectCounterType.IncreaseCounters(_statusEffect, counters);
        }
        
        /// <summary>
        ///  Decrease the status effect counters by the specified amount
        /// based on counter type
        /// </summary>
        /// <param name="counters"></param>
        public void DecreaseCounters(int counters)
        {
            _statusEffect.StatusEffectCounterType.DecreaseCounters(_statusEffect, counters);
        }
        
        /// <summary>
        /// Set the status effect counters to the specified amount
        /// based on counter type
        /// </summary>
        /// <param name="counters"></param>
        public void SetCountersToValue(int counters)
        {
            _statusEffect.StatusEffectCounterType.SetCountersToValue(_statusEffect, counters);
        }
        
        /// <summary>
        /// Reduce the status effect counters by a fixed amount (1)
        /// based on counter type
        /// </summary>
        public void TurnReduceCounters()
        {
            _statusEffect.StatusEffectCounterType.TurnReduceCounters(_statusEffect);
        }
        
        
        
        
    }
}
