using System;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Updates all the status effect counters
    /// </summary>
    public class UpdateStatusEffectCounters : MonoBehaviour, IUpdateStatusEffectCounters
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
            //Update all buff counters
            foreach (var buffEffect in _heroStatusEffects.BuffEffects.StatusEffects)
            {
                //TODO: statusEffectUpdateType.UpdateCountersStartTurn
            }
            
            //Update all debuff counters
            foreach (var debuffEffect in _heroStatusEffects.DebuffEffects.StatusEffects)
            {
                //TODO: statusEffectUpdateType.UpdateCountersStartTurn
            }

            foreach (var uniqueStatusEffect in _heroStatusEffects.UniqueStatusEffects.StatusEffects)
            {
                //TODO: statusEffectUpdateType.UpdateCountersStartTurn
            }
        }
        
        /// <summary>
        /// Update all status effects with end turn update type 
        /// </summary>
        public void UpdateCountersEndTurn()
        {
            //Update all buff counters
            foreach (var buffEffect in _heroStatusEffects.BuffEffects.StatusEffects)
            {
                //TODO: statusEffectUpdateType.UpdateCountersEndTurn
            }
            
            //Update all debuff counters
            foreach (var debuffEffect in _heroStatusEffects.DebuffEffects.StatusEffects)
            {
                //TODO: statusEffectUpdateType.UpdateCountersEndTurn
            }

            foreach (var uniqueStatusEffect in _heroStatusEffects.UniqueStatusEffects.StatusEffects)
            {
                //TODO: statusEffectUpdateType.UpdateCountersEndTurn
            }
        }
    }
}
