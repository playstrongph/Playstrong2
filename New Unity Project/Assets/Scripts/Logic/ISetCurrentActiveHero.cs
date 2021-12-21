using System.Collections;

namespace Logic
{
    public interface ISetCurrentActiveHero
    {
        /// <summary>
        /// Sets the current active heroes from the active heroes list, resets energy to zero, and
        /// calls combat start turn event
        /// </summary>
        /// <returns></returns>
        IEnumerator StartAction();
    }
}