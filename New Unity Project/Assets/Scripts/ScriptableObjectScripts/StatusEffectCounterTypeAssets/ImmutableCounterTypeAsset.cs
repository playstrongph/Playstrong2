using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectCounterTypeAssets
{
    [CreateAssetMenu(fileName = "ImmutableCounterType", menuName = "Assets/StatusEffectCounterType/ImmutableCounterType")]
    public class ImmutableCounterTypeAsset : StatusEffectCounterTypeAsset
    {
        /// <summary>
        /// Increase the status effect counters by the specified amount
        /// </summary>
        /// <param name="statusEffect"></param>
        /// <param name="counters"></param>
        public override void IncreaseCounters(IStatusEffect statusEffect, int counters)
        {
            //Do Nothing
        }
        
        /// <summary>
        ///  Decrease the status effect counters by the specified amount
        /// </summary>
        /// <param name="statusEffect"></param>
        /// <param name="counters"></param>
        public override void DecreaseCounters(IStatusEffect statusEffect, int counters)
        { 
            //Do Nothing
        }
        
        /// <summary>
        ///  Set the status effect counters to the specified amount
        /// </summary>
        /// <param name="statusEffect"></param>
        /// <param name="counters"></param>
        public override void SetCountersToValue(IStatusEffect statusEffect, int counters)
        {
            //Do Nothing
        }
        
        /// <summary>
        /// Reduce the status effect counters by a fixed amount (1)
        /// </summary>
        /// <param name="statusEffect"></param>
        public override void TurnReduceCounters(IStatusEffect statusEffect)
        {
            //Do Nothing
        }

        
    }
}
