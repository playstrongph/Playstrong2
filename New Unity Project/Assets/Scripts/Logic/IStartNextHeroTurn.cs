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
    }
}