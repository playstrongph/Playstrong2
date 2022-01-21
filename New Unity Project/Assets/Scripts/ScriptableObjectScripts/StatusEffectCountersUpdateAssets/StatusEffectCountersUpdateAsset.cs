using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectCountersUpdateAssets
{
    public abstract class StatusEffectCountersUpdateAsset : ScriptableObject, IStatusEffectCountersUpdateAsset
    {
        
        /// <summary>
        /// Update the status effect counter at the start of the turn
        /// </summary>
        /// <param name="heroStatusEffect"></param>
        public virtual void UpdateCountersStartTurn(IStatusEffect heroStatusEffect)
        {
           
        }
        
        /// <summary>
        /// Update the status effect counter at the end of the turn
        /// </summary>
        /// <param name="heroStatusEffect"></param>
        public virtual void UpdateCountersEndTurn(IStatusEffect heroStatusEffect)
        {
           
        }
        
        
        
        
        
    }
}
