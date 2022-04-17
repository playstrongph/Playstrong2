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
        /// Note: TargetHero should always be used by the inheritors, since it is determined by GetValidTargets
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="standardAction"></param>
        public virtual void SubscribeStandardAction(IHero casterHero, IHero targetHero, IStandardActionAsset standardAction)
        {
            
        }
        
        /// <summary>
        /// Unsubscribes the standard action to the HERO specific basic event - e.g. EventDragSkillTarget
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="standardAction"></param>
        public virtual void UnsubscribeStandardAction(IHero casterHero, IHero targetHero, IStandardActionAsset standardAction)
        {
            
        }
        
        /// <summary>
        /// Subscribes the standard action to the SKILL specific basic event - e.g. EventDragSkillTarget
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="standardAction"></param>
        public virtual void SubscribeStandardAction(ISkill skill, IStandardActionAsset standardAction)
        {
            
        }
        
        /// <summary>
        /// Subscribes the standard action to the SKILL specific basic event - e.g. EventDragSkillTarget
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="standardAction"></param>
        public virtual void UnsubscribeStandardAction(ISkill skill, IStandardActionAsset standardAction)
        {
            
        }
        
        
        
    }
}
