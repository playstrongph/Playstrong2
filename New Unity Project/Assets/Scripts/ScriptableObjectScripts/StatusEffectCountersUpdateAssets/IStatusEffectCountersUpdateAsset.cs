using Logic;

namespace ScriptableObjectScripts.StatusEffectCountersUpdateAssets
{
    public interface IStatusEffectCountersUpdateAsset
    {
        /// <summary>
        /// Update the status effect counter at the start of the turn
        /// </summary>
        /// <param name="statusEffect"></param>
        void UpdateCountersStartTurn(IStatusEffect statusEffect);

        /// <summary>
        /// Update the status effect counter at the end of the turn
        /// </summary>
        /// <param name="statusEffect"></param>
        void UpdateCountersEndTurn(IStatusEffect statusEffect);
    }
}