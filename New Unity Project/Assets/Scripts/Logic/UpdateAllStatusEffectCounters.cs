using System;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Updates all the status effect counters
    /// </summary>
    public class UpdateAllStatusEffectCounters : MonoBehaviour, IUpdateAllStatusEffectCounters
    {

        private IHeroStatusEffects _heroStatusEffects;

        private void Awake()
        {
            _heroStatusEffects = GetComponent<IHeroStatusEffects>();
        }
        
        /// <summary>
        /// Update all status effects with start turn update type 
        /// </summary>
        public void UpdateCountersStartTurn()
        {
            //Update all buff counters (reduce their counters)
            foreach (var buffEffect in _heroStatusEffects.BuffEffects.StatusEffects)
            {
                buffEffect.StatusEffectCounterUpdateType.UpdateCountersStartTurn(buffEffect);
            }
            
            //Update all debuff counters (reduce their counters)
            foreach (var debuffEffect in _heroStatusEffects.DebuffEffects.StatusEffects)
            {
                debuffEffect.StatusEffectCounterUpdateType.UpdateCountersStartTurn(debuffEffect);
            }
            
            //Update all unique status effect counters (reduce their counters)
            foreach (var uniqueStatusEffect in _heroStatusEffects.UniqueStatusEffects.StatusEffects)
            {
                uniqueStatusEffect.StatusEffectCounterUpdateType.UpdateCountersStartTurn(uniqueStatusEffect);
            }
        }
        
        /// <summary>
        /// Update all status effects with end turn update type 
        /// </summary>
        public void UpdateCountersEndTurn()
        {
            //Update all buff counters (reduce their counters)
            foreach (var buffEffect in _heroStatusEffects.BuffEffects.StatusEffects)
            {
                buffEffect.StatusEffectCounterUpdateType.UpdateCountersEndTurn(buffEffect);
            }
            
            //Update all debuff counters (reduce their counters)
            foreach (var debuffEffect in _heroStatusEffects.DebuffEffects.StatusEffects)
            {
                debuffEffect.StatusEffectCounterUpdateType.UpdateCountersEndTurn(debuffEffect);
            }
            
            //Update all unique status effect counters (reduce their counters)
            foreach (var uniqueStatusEffect in _heroStatusEffects.UniqueStatusEffects.StatusEffects)
            {
                uniqueStatusEffect.StatusEffectCounterUpdateType.UpdateCountersEndTurn(uniqueStatusEffect);
            }
        }
    }
}
