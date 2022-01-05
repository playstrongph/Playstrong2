using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.SkillEffectAssets
{
    public interface ISkillEffectAsset
    {
        List<IStandardActionAsset> StandardActions { get; }
        
        /// <summary>
        /// Public access to standardActions - used in unique asset creation at  LoadSkillEffect
        /// </summary>
        List<ScriptableObject> StandardActionsScriptableObjects { get; }

        /// <summary>
        /// Subscribe all standard actions to their respective skill basic events
        /// </summary>
        /// <param name="skill"></param>
        void SubscribeSkillEffect(ISkill skill);

        /// <summary>
        /// Subscribe all standard actions to their respective hero basic events
        /// </summary>
        /// <param name="hero"></param>
        void SubscribeSkillEffect(IHero hero);

        /// <summary>
        /// Subscribe all standard actions to their respective skill basic events
        /// </summary>
        /// <param name="skill"></param>
        void UnsubscribeSkillEffect(ISkill skill);

        /// <summary>
        /// Unsubscribe all standard actions to their respective hero basic events
        /// </summary>
        /// <param name="hero"></param>
        void UnsubscribeSkillEffect(IHero hero);
    }
}