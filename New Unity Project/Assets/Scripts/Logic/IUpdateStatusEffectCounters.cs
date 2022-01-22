namespace Logic
{
    public interface IUpdateStatusEffectCounters
    {
        /// <summary>
        /// Increase the status effect counters by the specified amount
        /// based on counter type
        /// </summary>
        /// <param name="counters"></param>
        void IncreaseCounters(int counters);

        /// <summary>
        ///  Decrease the status effect counters by the specified amount
        /// based on counter type
        /// </summary>
        /// <param name="counters"></param>
        void DecreaseCounters(int counters);

        /// <summary>
        /// Set the status effect counters to the specified amount
        /// based on counter type
        /// </summary>
        /// <param name="counters"></param>
        void SetCountersToValue(int counters);

        /// <summary>
        /// Reduce the status effect counters by a fixed amount (1)
        /// based on counter type
        /// </summary>
        void TurnReduceCounters();
    }
}