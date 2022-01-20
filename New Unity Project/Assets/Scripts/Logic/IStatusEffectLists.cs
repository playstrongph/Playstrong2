using System.Collections.Generic;

namespace Logic
{
    public interface IStatusEffectLists
    {
        /// <summary>
        /// Returns the list of status effect objects as a list of IStatusEffect
        /// </summary>
        List<IStatusEffect> StatusEffects { get; }

        /// <summary>
        /// Add status effect to interface and object list
        /// </summary>
        /// <param name="statusEffect"></param>
        void AddToList(IStatusEffect statusEffect);

        /// <summary>
        /// Remove status effect to interface and object list
        /// </summary>
        /// <param name="statusEffect"></param>
        void RemoveFromList(IStatusEffect statusEffect);
    }
}