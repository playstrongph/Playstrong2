using System.Collections;

namespace Logic
{
    public interface IInitializeTurnController
    {
        /// <summary>
        /// Instantiates and initializes the turn controller
        /// </summary>
        /// <returns></returns>
        IEnumerator StartAction();
    }
}