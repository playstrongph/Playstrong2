namespace Logic
{
    public interface IHeroTimer
    {
        float TimerValue { get; set; }
        float TimerValuePercent { get; set; }

        /// <summary>
        /// Resets the energy and hero timer values back to zero
        /// </summary>
        void ResetHeroTimer();

        /// <summary>
        /// Updates the hero's timer using the hero's speed and the
        /// turn controllers speed constant
        /// </summary>
        void UpdateHeroTimer();

        /// <summary>
        /// Sets the hero's timer to the converted energy value
        /// </summary>
        /// <param name="energyValue"></param>
        void SetHeroTimer(int energyValue);
    }
}