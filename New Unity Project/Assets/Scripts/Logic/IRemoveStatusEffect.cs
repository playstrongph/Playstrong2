using System.Collections;

namespace Logic
{
    public interface IRemoveStatusEffect
    {
        /// <summary>
        /// Removes and destroys the status effect
        /// </summary>
        /// <param name="hero"></param>
        void StartAction(IHero hero);

        /// <summary>
        /// Remove status effects not part of the exemption list when the hero dies
        /// </summary>
        /// <param name="hero"></param>
        void RemoveAtDeath(IHero hero);
        
    }
}