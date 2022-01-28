using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectCastingStatusAssets
{
    [CreateAssetMenu(fileName = "FreshCastStatus", menuName = "Assets/StatusEffectCastingStatus/FreshCastStatus")]
    public class FreshCastStatus : StatusEffectCastingStatusAsset
    {
        /// <summary>
        /// Set the status effect to old cast status
        /// </summary>
        /// <param name="statusEffect"></param>
        public override void StartAction(IStatusEffect statusEffect)
        {
            //No turn reduce counter and update the casting status
            statusEffect.UpdateStatusEffectCastingStatus.SetOldCastStatus();
        }
    }
}
