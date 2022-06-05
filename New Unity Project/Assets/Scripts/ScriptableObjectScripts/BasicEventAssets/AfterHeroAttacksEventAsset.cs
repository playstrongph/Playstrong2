using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicEventAssets
{
    [CreateAssetMenu(fileName = "AfterHeroAttacksEvent", menuName = "Assets/BasicEvents/AfterHeroAttacksEvent")]

    public class AfterHeroAttacksEventAsset : BasicEventAsset
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
            targetHero.HeroLogic.HeroEvents.EAfterHeroAttacks += standardAction.StartAction;
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
            targetHero.HeroLogic.HeroEvents.EAfterHeroAttacks -= standardAction.StartAction;
        }
        
       
    }
}
