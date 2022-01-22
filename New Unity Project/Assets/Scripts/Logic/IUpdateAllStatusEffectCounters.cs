namespace Logic
{
    public interface IUpdateAllStatusEffectCounters
    {
        /// <summary>
        /// Update all status effects with start turn update type 
        /// </summary>
        void UpdateCountersStartTurn();

        /// <summary>
        /// Update all status effects with end turn update type 
        /// </summary>
        void UpdateCountersEndTurn();
    }
}