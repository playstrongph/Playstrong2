using Logic;

namespace ScriptableObjectScripts.StatusEffectCounterTypeAssets
{
    public interface IStatusEffectCounterTypeAsset
    {
        /// <summary>
        /// Increase the status effect counters by the specified amount
        /// </summary>
        /// <param name="statusEffect"></param>
        /// <param name="counters"></param>
        void IncreaseCounters(IStatusEffect statusEffect, int counters);

        /// <summary>
        ///  Decrease the status effect counters by the specified amount
        /// </summary>
        /// <param name="statusEffect"></param>
        /// <param name="counters"></param>
        void DecreaseCounters(IStatusEffect statusEffect, int counters);

        /// <summary>
        ///  Set the status effect counters to the specified amount
        /// </summary>
        /// <param name="statusEffect"></param>
        /// <param name="counters"></param>
        void SetCountersToValue(IStatusEffect statusEffect, int counters);

        /// <summary>
        /// Reduce the status effect counters by a fixed amount (1)
        /// </summary>
        /// <param name="statusEffect"></param>
        void TurnReduceCounters(IStatusEffect statusEffect);
    }
}