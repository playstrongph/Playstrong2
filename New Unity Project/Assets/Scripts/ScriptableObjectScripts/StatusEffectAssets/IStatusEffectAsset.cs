using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.BasicActionAssets;
using ScriptableObjectScripts.StandardActionAssets;
using ScriptableObjectScripts.StatusEffectCountersUpdateTypeAssets;
using ScriptableObjectScripts.StatusEffectCounterTypeAssets;
using ScriptableObjectScripts.StatusEffectInstanceTypeAssets;
using ScriptableObjectScripts.StatusEffectTypeAssets;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectAssets
{
    public interface IStatusEffectAsset
    {   
        /// <summary>
        /// Name of the status effect - SLOW, STUN, etc
        /// </summary>
        string StatusEffectName { get; }

        /// <summary>
        /// What the status effect does - increase attack by 50%
        /// </summary>
        string Description { get; }
        
        /// <summary>
        /// The status effect image icon
        /// </summary>
        Sprite Icon { get; }
        
        /*/// <summary>
        /// Status effect counters duration
        /// </summary>
        int CountersValue { get; }*/
        
        /// <summary>
        /// Status Effect Type Attribute - Buff, Debuff, Unique
        /// </summary>
        IStatusEffectTypeAsset StatusEffectType { get; }

        /// <summary>
        /// When shall the counters be updated - Start turn or End turn
        /// </summary>
        IStatusEffectCounterUpdateTypeAsset StatusEffectCounterUpdateType { get; }
        
        /// <summary>
        /// How many instances of the status effect are allowed - single, multiple
        /// </summary>
        IStatusEffectInstanceTypeAsset StatusEffectInstanceType { get; }
        
        /// <summary>
        /// What are the counter type updates - immutable, no change, normal
        /// </summary>
        IStatusEffectCounterTypeAsset StatusEffectCounterType { get; }

        /// <summary>
        /// Returns a list of IStatusEffectActionAsset
        /// </summary>
        List<IStatusEffectActionAsset> StatusEffectActions { get; }
        
        /// <summary>
        /// Returns status effect actions as scriptable objects
        /// </summary>
        List<ScriptableObject> StatusEffectActionObjects { get; }
        
        /// <summary>
        /// Status effect asset basic actions
        /// </summary>
        List<IBasicActionAsset> BasicActions { get; }
        
        /// <summary>
        /// Status effect asset basic action objects
        /// </summary>
        List<ScriptableObject> BasicActionObjects { get; }
        
        /// <summary>
        /// Apply status effect action
        /// </summary>
        /// <param name="hero"></param>
        void SubscribeAction(IHero hero);
        
        /// <summary>
        /// Unapply status effect action
        /// </summary>
        /// <param name="hero"></param>
        void UnsubscribeAction(IHero hero);
        
        /// <summary>
        /// Apply status effect basic action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void ApplyAction(IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// Unapply status effect basic action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void UndoApplyAction(IHero casterHero, IHero targetHero);


    }
}