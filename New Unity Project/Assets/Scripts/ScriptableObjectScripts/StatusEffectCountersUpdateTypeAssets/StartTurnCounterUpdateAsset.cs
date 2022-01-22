using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectCountersUpdateTypeAssets
{
    [CreateAssetMenu(fileName = "StartTurnCounterUpdate", menuName = "Assets/StatusEffectCountersUpdateAsset/StartTurnCounterUpdate")]
    public class StartTurnCounterUpdateAsset : StatusEffectCounterUpdateTypeAsset
    {
        /// <summary>
        /// Reduce the status effect counters by a fixed amount (1) at the start of the turn
        /// </summary>
        /// <param name="statusEffect"></param>
        public override void UpdateCountersStartTurn(IStatusEffect statusEffect)
        {
           statusEffect.UpdateStatusEffectCounters.TurnReduceCounters();
        }
        
        
        
    }
}
