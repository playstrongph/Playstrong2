using ScriptableObjectScripts.StatusEffectAssets;
using ScriptableObjectScripts.StatusEffectCastingStatusAssets;
using ScriptableObjectScripts.StatusEffectCountersUpdateTypeAssets;
using ScriptableObjectScripts.StatusEffectCounterTypeAssets;
using ScriptableObjectScripts.StatusEffectInstanceTypeAssets;
using ScriptableObjectScripts.StatusEffectTypeAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public interface IStatusEffect
    {
        /// <summary>
        /// Interface access to status effect icon
        /// </summary>
        Image Icon { get; set; }
        
        /// <summary>
        /// Interface access to status effect visual counters text
        /// </summary>
        TextMeshProUGUI CountersText { get; set; }

        //SET IN RUN TIME
        
        /// <summary>
        /// Interface access to status effect name
        /// </summary>
        string StatusEffectName { get; set; }
        
        /// <summary>
        /// Status effect description
        /// </summary>
        string StatusEffectDescription { get; set; }

        /// <summary>
        /// Interface access to status effect counters duration
        /// </summary>
        int CountersValue { get; set; }
        
        /// <summary>
        /// Status effect asset reference
        /// </summary>
        IStatusEffectAsset StatusEffectAsset { get; set; }

        /// <summary>
        /// Interface access to status effect preview reference 
        /// </summary>
        IPreviewStatusEffect PreviewStatusEffect { get; set; }
        
        /// <summary>
        /// Reference to Hero Status Effects
        /// </summary>
        IHeroStatusEffects HeroStatusEffects { get; set; }

        /// <summary>
        /// Returns the inheriting class as a game object
        /// </summary>
        GameObject ThisGameObject { get; }
        
        //ATTRIBUTES
        
        /// <summary>
        /// Status Effect Type Attribute - Buff, Debuff, Unique
        /// </summary>
        IStatusEffectTypeAsset StatusEffectType { get; set; }
        
        /// <summary>
        /// Status effect counter type attribute - Normal or Immutable 
        /// </summary>
        IStatusEffectCounterTypeAsset StatusEffectCounterType { get; set; }
        
        /// <summary>
        /// Counter update types - start turn update, end turn update, and no update
        /// </summary>
        IStatusEffectCounterUpdateTypeAsset StatusEffectCounterUpdateType { get; set; }
        
        /// <summary>
        /// Status effect instance type - single, multiple
        /// </summary>
        IStatusEffectInstanceTypeAsset StatusEffectInstanceType { get; set; }
        
        /// <summary>
        /// "Fresh" or "Old" status effect casting status 
        /// </summary>
        IStatusEffectCastingStatusAsset StatusEffectCastingStatus { get; set; }

        /// <summary>
        /// Update status effect counters component
        /// </summary>
        IUpdateStatusEffectCounters UpdateStatusEffectCounters { get; }
        
        /// <summary>
        /// Load the status effect asset values and create unique standard actions, and components
        /// </summary>
        ILoadStatusEffectAsset LoadStatusEffectAsset { get; }
        
        /// <summary>
        /// Removes and destroys the status effect
        /// </summary>
        IRemoveStatusEffect RemoveStatusEffect { get; }
        
        /// <summary>
        /// Sets the status effect casting status to "fresh" or "old"
        /// </summary>
        IUpdateStatusEffectCastingStatus UpdateStatusEffectCastingStatus { get; }

        /// <summary>
        /// Caster of the status effect
        /// </summary>
        IHero StatusEffectCasterHero { get; set; }
        
        /// <summary>
        /// Target of the status effect
        /// </summary>
        IHero StatusEffectTargetHero { get; set; }
    }
}