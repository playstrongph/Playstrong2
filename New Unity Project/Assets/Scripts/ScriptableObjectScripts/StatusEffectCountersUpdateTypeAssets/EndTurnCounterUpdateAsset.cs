using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectCountersUpdateTypeAssets
{
    [CreateAssetMenu(fileName = "EndTurnCounterUpdate", menuName = "Assets/StatusEffectCountersUpdateAsset/EndTurnCounterUpdate")]
    public class EndTurnCounterUpdateAsset : StatusEffectCounterUpdateTypeAsset
    {
        /// <summary>
        /// Update the status effect counters at the end of turn
        /// </summary>
        /// <param name="statusEffect"></param>
        public override void UpdateCountersEndTurn(IStatusEffect statusEffect)
        {
            statusEffect.UpdateStatusEffectCounters.TurnReduceCounters();
        }
        
    }
}
