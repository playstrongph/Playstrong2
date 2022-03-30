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

        /// <summary>
        /// Sets the hero start turn visual delay in seconds
        /// </summary>
        /// <param name="value"></param>
        void SetVisualDelay(float value);
    }
}