namespace Logic
{
    public interface IUpdateHeroTimers
    {
        /// <summary>
        /// Updates all living heroes hero timers
        /// </summary>
        void StartAction();
        
        /// <summary>
        /// Delays the start of update timers
        /// </summary>
        float DelayUpdateTimer { get; set; }
    }
}