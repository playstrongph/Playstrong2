using System;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Updates the individual status effect counter`
    /// </summary>
    public class UpdateStatusEffectCounters : MonoBehaviour
    {
        private IStatusEffect _statusEffect;

        private void Awake()
        {
            _statusEffect = GetComponent<IStatusEffect>();
        }

        public void DecreaseCounter(int counter)
        {
            //TODO: StatusEffect CounterType Decrease Counters 
        }
    }
}
