using System.Collections;

namespace Logic
{
    public interface IStartNextHeroTurn
    {
        /// <summary>
        /// Determines the next active hero from the active heroes list 
        /// </summary>
        /// <returns></returns>
        IEnumerator StartAction();
        
        
        /// <summary>
        /// Delays the visual start of the hero timers
        /// </summary>
        float NextTurnVisualDelay { get; set; }
    }
}