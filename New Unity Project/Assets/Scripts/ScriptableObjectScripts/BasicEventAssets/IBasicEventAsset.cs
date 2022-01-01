using Logic;
using ScriptableObjectScripts.StandardActionAssets;

namespace ScriptableObjectScripts.BasicEventAssets
{
    public interface IBasicEventAsset
    {
        /// <summary>
        /// Subscribes the standard action to the HERO specific basic event - e.g. EventDragSkillTarget
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="standardAction"></param>
        void SubscribeStandardAction(IHero hero, IStandardActionAsset standardAction);

        /// <summary>
        /// Subscribes the standard action to the SKILL specific basic event - e.g. EventDragSkillTarget
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="standardAction"></param>
        void SubscribeStandardAction(ISkill skill, IStandardActionAsset standardAction);

        /// <summary>
        /// Unsubscribes the standard action to the HERO specific basic event - e.g. EventDragSkillTarget
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="standardAction"></param>
        void UnsubscribeStandardAction(IHero hero, IStandardActionAsset standardAction);

        /// <summary>
        /// Subscribes the standard action to the SKILL specific basic event - e.g. EventDragSkillTarget
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="standardAction"></param>
        void UnsubscribeStandardAction(ISkill skill, IStandardActionAsset standardAction);
    }
}