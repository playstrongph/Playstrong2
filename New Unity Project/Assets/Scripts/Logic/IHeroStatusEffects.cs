using UnityEngine;

namespace Logic
{
    public interface IHeroStatusEffects
    {
        /// <summary>
        /// Interface reference to Hero
        /// </summary>
        IHero Hero { get; }
        
        /// <summary>
        /// Interface to status effects canvas
        /// </summary>
        Canvas StatusEffectsCanvas { get; }
    }
}