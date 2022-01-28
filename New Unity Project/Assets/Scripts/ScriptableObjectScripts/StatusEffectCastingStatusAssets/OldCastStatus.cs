using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectCastingStatusAssets
{
    
    [CreateAssetMenu(fileName = "OldCastStatus", menuName = "Assets/StatusEffectCastingStatus/OldCastStatus")]
    public class OldCastStatus : StatusEffectCastingStatusAsset
    {
        /// <summary>
        /// Call turn reduce counters
        /// </summary>
        /// <param name="statusEffect"></param>
        public override void StartAction(IStatusEffect statusEffect)
        {
            statusEffect.StatusEffectCounterType.TurnReduceCounters(statusEffect);
        }
    }
}
