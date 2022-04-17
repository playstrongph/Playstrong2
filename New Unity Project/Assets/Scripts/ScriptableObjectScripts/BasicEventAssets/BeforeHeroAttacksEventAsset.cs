using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicEventAssets
{
    [CreateAssetMenu(fileName = "BeforeHeroAttacksEvent", menuName = "Assets/BasicEvents/BeforeHeroAttacksEvent")]

    public class BeforeHeroAttacksEventAsset : BasicEventAsset
    {
        /// <summary>
        /// Subscribes the standard action to the single IHero argument event
        /// Note that for single IHero argument events, this hero and target hero are the same
        /// </summary>
        /// <param name="casterHero"></param>
        /// /// <param name="targetHero"></param>
        /// <param name="standardAction"></param>
        public override void SubscribeStandardAction(IHero casterHero, IHero targetHero, IStandardActionAsset standardAction)
        {
            targetHero.HeroLogic.HeroEvents.EBeforeHeroAttacks += standardAction.StartAction;
        }
        
        
        /// <summary>
        /// Unsubscribes the standard action to the single IHero argument event
        /// Note that for single IHero argument events, this hero and target hero are the same
        /// </summary>
        /// <param name="casterHero"></param>
        /// /// <param name="targetHero"></param>
        /// <param name="standardAction"></param>
        public override void UnsubscribeStandardAction(IHero casterHero, IHero targetHero, IStandardActionAsset standardAction)
        {
            targetHero.HeroLogic.HeroEvents.EBeforeHeroAttacks -= standardAction.StartAction;
        }
        
       
    }
}
