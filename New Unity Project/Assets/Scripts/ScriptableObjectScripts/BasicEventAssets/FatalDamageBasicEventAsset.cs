using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicEventAssets
{
    [CreateAssetMenu(fileName = "FatalDamageEvent", menuName = "Assets/BasicEvents/FatalDamageEvent")]
    public class FatalDamageBasicEventAsset : BasicEventAsset
    {
       
        /// <summary>
        /// Subscribes the standard action to the the event
        /// Note that for single IHero argument events, the caster hero and the target hero are the same
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="standardAction"></param>
        public override void SubscribeStandardAction(IHero hero, IStandardActionAsset standardAction)
        {
            hero.HeroLogic.HeroEvents.EHeroTakesFatalDamage += standardAction.StartAction;
        }
        
        /// <summary>
        /// Unsubscribes the standard action to the the event
        /// Note that for single IHero argument events, the caster hero and the target hero are the same
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="standardAction"></param>
        public override void UnsubscribeStandardAction(IHero hero, IStandardActionAsset standardAction)
        {
            hero.HeroLogic.HeroEvents.EHeroTakesFatalDamage -= standardAction.StartAction;
        }
    }
}
