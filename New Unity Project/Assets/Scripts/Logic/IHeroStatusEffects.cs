using System.Collections.Generic;
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
        /// Returns status effect prefab as interface object
        /// </summary>
        IStatusEffect StatusEffectPrefab { get; }

        /// <summary>
        /// Returns preview status effect prefab as an interface object
        /// </summary>
        IPreviewStatusEffect PreviewStatusEffectPrefab { get; }
        
        

        /// <summary>
        /// All hero buff effects
        /// </summary>
        IBuffEffects BuffEffects { get; }
        
        /// <summary>
        /// All herod debuff effects
        /// </summary>
        IDebuffEffects DebuffEffects { get; }

        List<IStatusEffect> GetAllStatusEffects(IHero targetHero);
        
        /// <summary>
        /// All hero unique status effects
        /// </summary>
        IUniqueStatusEffects UniqueStatusEffects { get; }
        
        /// <summary>
        /// Updates all the status effect counters
        /// </summary>
        IUpdateAllStatusEffectCounters UpdateStatusEffectCounters { get; }
    }
}