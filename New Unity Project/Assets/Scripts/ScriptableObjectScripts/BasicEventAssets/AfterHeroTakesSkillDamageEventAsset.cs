using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicEventAssets
{
    [CreateAssetMenu(fileName = "AfterHeroTakesSkillDamageEvent", menuName = "Assets/BasicEvents/AfterHeroTakesSkillDamageEvents")]

    public class AfterHeroTakesSkillDamageEventAsset : BasicEventAsset
    {
        /// <summary>
        /// Subscribes the standard action to the single IHero argument event
        /// Note that for single IHero argument events, this hero and target hero are the same
        /// </summary>
        /// <param name="thisHero"></param>
        /// /// <param name="targetHero"></param>
        /// <param name="standardAction"></param>
        public override void SubscribeStandardAction(IHero thisHero, IHero targetHero, IStandardActionAsset standardAction)
        {
            //This is a single IHero arg event 
            thisHero.HeroLogic.HeroEvents.EAfterHeroTakesSkillDamage += standardAction.StartAction;
        }
        
        
        /// <summary>
        /// Unsubscribes the standard action to the single IHero argument event
        /// Note that for single IHero argument events, this hero and target hero are the same
        /// </summary>
        /// <param name="thisHero"></param>
        /// /// <param name="targetHero"></param>
        /// <param name="standardAction"></param>
        public override void UnsubscribeStandardAction(IHero thisHero, IHero targetHero, IStandardActionAsset standardAction)
        {
            Debug.Log("Unsubscribe after hero takes skill damage");
            
            //This is a single IHero arg event
            thisHero.HeroLogic.HeroEvents.EAfterHeroTakesSkillDamage -= standardAction.StartAction;
        }
        
       
    }
}
