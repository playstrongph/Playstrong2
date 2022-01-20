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
        
        /// <summary>
        /// All hero buff effects
        /// </summary>
        IBuffEffects BuffEffects { get; }
        
        /// <summary>
        /// All herod debuff effects
        /// </summary>
        IDebuffEffects DebuffEffects { get; }
        
        /// <summary>
        /// All hero unique status effects
        /// </summary>
        IUniqueStatusEffects UniqueStatusEffects { get; }
    }
}