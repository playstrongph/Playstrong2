using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.StandardActionAssets
{
    /// <summary>
    /// Base class for SkillActionAsset and StatusEffectActionAsset
    /// </summary>
    public abstract class StandardActionAsset : ScriptableObject, IStandardActionAsset
    {
        /// <summary>
        /// Base method for actions execution
        /// </summary>
        /// <param name="hero"></param>
        public virtual void StartAction(IHero hero)
        {
            
        }
    }
}
