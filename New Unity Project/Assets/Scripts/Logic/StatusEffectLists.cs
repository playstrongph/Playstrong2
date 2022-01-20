using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Base class for the different status effects lists - buff effects, debuff effects, unique status effects
    /// </summary>
    public abstract class StatusEffectLists : MonoBehaviour, IStatusEffectLists
    {
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffect))]
        protected List<Object> statusEffects = new List<Object>();
        
        /// <summary>
        /// Returns the list of status effect objects as a list of IStatusEffect
        /// </summary>
        public virtual List<IStatusEffect> StatusEffects
        {
            get
            {
                var heroStatusEffects = new List<IStatusEffect>();
                foreach (var statusEffectObject in statusEffects)
                {
                    heroStatusEffects.Add(statusEffectObject as IStatusEffect);
                }
                return heroStatusEffects;
            }

            private set => value = new List<IStatusEffect>();
        }
        
        /// <summary>
        /// Add status effect to interface and object list
        /// </summary>
        /// <param name="statusEffect"></param>
        public virtual void AddToList(IStatusEffect statusEffect)
        {
            //Add to IStatusEffect list
            StatusEffects.Add(statusEffect);
            
            //Add to object list
            statusEffects.Add(statusEffect as Object);
        }
        
        /// <summary>
        /// Remove status effect to interface and object list
        /// </summary>
        /// <param name="statusEffect"></param>
        public virtual void RemoveFromList(IStatusEffect statusEffect)
        {
            //Remove from IStatusEffect list
            StatusEffects.Remove(statusEffect);
            
            //Remove from object list
            statusEffects.Remove(statusEffect as Object);
        }







    }
}
