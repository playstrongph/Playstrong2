using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectCountersUpdateAssets
{
    [CreateAssetMenu(fileName = "EndTurnCounterUpdate", menuName = "Assets/StatusEffectCountersUpdateAsset/EndTurnCounterUpdate")]
    public class EndTurnCounterUpdateAsset : StatusEffectCountersUpdateAsset
    {
        
        public override void UpdateCountersEndTurn(IStatusEffect heroStatusEffect)
        {
           //TODO: Reduce status effect counters
        }
        
    }
}
