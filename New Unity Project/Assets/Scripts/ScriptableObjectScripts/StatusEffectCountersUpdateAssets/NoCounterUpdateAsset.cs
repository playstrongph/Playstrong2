using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectCountersUpdateAssets
{
    [CreateAssetMenu(fileName = "NoCounterUpdate", menuName = "Assets/StatusEffectCountersUpdateAsset/NoCounterUpdate")]
    public class NoCounterUpdateAsset : StatusEffectCountersUpdateAsset
    {
        
        public override void UpdateCountersStartTurn(IStatusEffect heroStatusEffect)
        {
            //Do Noting
        }
        
        public override void UpdateCountersEndTurn(IStatusEffect heroStatusEffect)
        {
           //Do Noting
        }
        
    }
}
