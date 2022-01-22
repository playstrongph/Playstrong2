using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectCounterTypeAssets
{
    /// <summary>
    /// Base class for normal and immutable status effect counter types
    /// </summary>
    public abstract class StatusEffectCounterTypeAsset : MonoBehaviour
    {
        /// <summary>
        /// Increase the status effect counters by the specified amount
        /// </summary>
        /// <param name="statusEffect"></param>
        /// <param name="counters"></param>
        public virtual void IncreaseCounters(IStatusEffect statusEffect, int counters)
        { }
        
        /// <summary>
        ///  Decrease the status effect counters by the specified amount
        /// </summary>
        /// <param name="statusEffect"></param>
        /// <param name="counters"></param>
        public virtual void DecreaseCounters(IStatusEffect statusEffect, int counters)
        { }
        
        /// <summary>
        ///  Set the status effect counters to the specified amount
        /// </summary>
        /// <param name="statusEffect"></param>
        /// <param name="counters"></param>
        public virtual void SetCountersToValue(IStatusEffect statusEffect, int counters)
        { }
        
        /// <summary>
        /// Reduce the status effect counters by a fixed amount (1)
        /// </summary>
        /// <param name="statusEffect"></param>
        public virtual void TurnReduceCounters(IStatusEffect statusEffect)
        { }


    }
}
