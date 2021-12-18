using System.Collections;

namespace Logic
{
    public interface IStartBattle
    {
        /// <summary>
        /// Combat start for both players
        /// </summary>
        /// <returns></returns>
        IEnumerator StartAction();
    }
}