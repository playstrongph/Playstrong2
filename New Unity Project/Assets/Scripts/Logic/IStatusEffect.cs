using ScriptableObjectScripts.StatusEffectCountersUpdateTypeAssets;
using ScriptableObjectScripts.StatusEffectCounterTypeAssets;
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
        /// Interface access to status effect counters duration
        /// </summary>
        int CountersValue { get; set; }
        
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
        /// Update status effect counters component
        /// </summary>
        IUpdateStatusEffectCounters UpdateStatusEffectCounters { get; set; }
    }
}