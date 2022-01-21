using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectCountersUpdateAssets
{
    [CreateAssetMenu(fileName = "StartTurnCounterUpdate", menuName = "Assets/StatusEffectCountersUpdateAsset/StartTurnCounterUpdate")]
    public class StartTurnCounterUpdateAsset : StatusEffectCountersUpdateAsset
    {
        
        public override void UpdateCountersStartTurn(IStatusEffect heroStatusEffect)
        {
           //TODO: Reduce status effect counters
        }
        
    }
}
