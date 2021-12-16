using System.Collections;

namespace Logic
{
    public interface ISortHeroesByEnergy
    {
        /// <summary>
        /// Sorts the heroes in the active heroes from highest
        /// to lowest energy 
        /// </summary>
        /// <returns></returns>
        IEnumerator StartAction();
    }
}