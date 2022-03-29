using System.Collections;

namespace Logic
{
    public interface IHeroStartTurn
    {
        /// <summary>
        /// Update all skills readiness status, calls start hero turn event subscribers, and
        /// executes the action of the hero's current active status
        /// </summary>
        /// <returns></returns>
        IEnumerator StartAction();
        
        
        //TODO:TEST
        float VisualDelay { get; set; }
    }
}