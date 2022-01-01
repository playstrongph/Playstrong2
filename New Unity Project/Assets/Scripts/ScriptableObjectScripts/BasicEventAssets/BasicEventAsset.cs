using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicEventAssets
{   
    /// <summary>
    /// Base class for basic event assets
    /// </summary>
    public abstract class BasicEventAsset : ScriptableObject, IBasicEventAsset
    {
        /// <summary>
        /// Subscribes the standard action to the HERO specific basic event - e.g. EventDragSkillTarget
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="standardAction"></param>
        public virtual void SubscribeStandardAction(IHero hero, IStandardActionAsset standardAction)
        {
            //TEST - no coroutine sub-method like the original
        }
        
        /// <summary>
        /// Unsubscribes the standard action to the HERO specific basic event - e.g. EventDragSkillTarget
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="standardAction"></param>
        public virtual void UnsubscribeStandardAction(IHero hero, IStandardActionAsset standardAction)
        {
            //TEST - no coroutine sub-method like the original
        }
        
        /// <summary>
        /// Subscribes the standard action to the SKILL specific basic event - e.g. EventDragSkillTarget
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="standardAction"></param>
        public virtual void SubscribeStandardAction(ISkill skill, IStandardActionAsset standardAction)
        {
            //TEST - no coroutine sub-method like the original
        }
        
        /// <summary>
        /// Subscribes the standard action to the SKILL specific basic event - e.g. EventDragSkillTarget
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="standardAction"></param>
        public virtual void UnsubscribeStandardAction(ISkill skill, IStandardActionAsset standardAction)
        {
            //TEST - no coroutine sub-method like the original
        }
        
        
        
    }
}
