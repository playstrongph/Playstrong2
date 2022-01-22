using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectCountersUpdateTypeAssets
{
    public abstract class StatusEffectCounterUpdateTypeAsset : ScriptableObject, IStatusEffectCounterUpdateTypeAsset
    {
        
        /// <summary>
        /// Update the status effect counter at the start of the turn
        /// </summary>
        /// <param name="statusEffect"></param>
        public virtual void UpdateCountersStartTurn(IStatusEffect statusEffect)
        {
           
        }
        
        /// <summary>
        /// Update the status effect counter at the end of the turn
        /// </summary>
        /// <param name="statusEffect"></param>
        public virtual void UpdateCountersEndTurn(IStatusEffect statusEffect)
        {
           
        }
        
        
        
        
        
    }
}
