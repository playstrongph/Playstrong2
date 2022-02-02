using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicEventAssets
{
    [CreateAssetMenu(fileName = "StartNowStatusEffectBasicEvent", menuName = "Assets/BasicEvents/StartNowStatusEffectBasicEvent")]
    public class StartNowStatusEffectBasicEventAsset : BasicEventAsset
    {
        /// <summary>
        /// Subscribes standard action to drag skill target event
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="standardAction"></param>
        public override void SubscribeStandardAction(IHero hero, IStandardActionAsset standardAction)
        {
            var statusEffectAction = standardAction as IStatusEffectActionAsset;

            statusEffectAction?.StatusEffectStartAction(hero);
        }
        
        /// <summary>
        /// Unsubscribes standard action to drag skill target event 
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="standardAction"></param>
        public override void UnsubscribeStandardAction(IHero hero, IStandardActionAsset standardAction)
        {
            var statusEffectAction = standardAction as IStatusEffectActionAsset;

            statusEffectAction?.UndoStatusEffectStartAction(hero);
        }
    }
}
