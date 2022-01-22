using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectCountersUpdateTypeAssets
{
    [CreateAssetMenu(fileName = "NoCounterUpdate", menuName = "Assets/StatusEffectCountersUpdateAsset/NoCounterUpdate")]
    public class NoCounterUpdateAsset : StatusEffectCounterUpdateTypeAsset
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
