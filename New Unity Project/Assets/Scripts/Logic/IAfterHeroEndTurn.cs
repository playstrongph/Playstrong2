using System.Collections;

namespace Logic
{
    public interface IAfterHeroEndTurn
    {
        /// <summary>
        /// Update all skills cooldown, call after hero end turn event, call after combat event, update status effects,
        /// and call next phase - start next active hero 
        /// </summary>
        /// <returns></returns>
        IEnumerator StartAction();
    }
}