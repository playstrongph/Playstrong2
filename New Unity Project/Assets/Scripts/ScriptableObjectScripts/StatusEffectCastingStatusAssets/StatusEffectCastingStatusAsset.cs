using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectCastingStatusAssets
{
    public abstract class StatusEffectCastingStatusAsset : ScriptableObject, IStatusEffectCastingStatusAsset
    {
        /// <summary>
        /// Call action based on casting status
        /// </summary>
        /// <param name="statusEffect"></param>
        public virtual void StartAction(IStatusEffect statusEffect)
        {
            //Fresh Cast - Set to Old Cast Status
            
            //Old Cast - Turn Reduce counters
        }


    }
}
