using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicEventAssets
{
    [CreateAssetMenu(fileName = "StatusEffectBasicEvent", menuName = "Assets/BasicEvents/StatusEffectBasicEvent")]
    public class StatusEffectBasicEventAsset : BasicEventAsset
    {
        /// <summary>
        /// Subscribes standard action to drag skill target event
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        /// <param name="standardAction"></param>
        public override void SubscribeStandardAction(IHero casterHero, IHero targetHero, IStandardActionAsset standardAction)
        {
            var statusEffectAction = standardAction as IStatusEffectActionAsset;

            statusEffectAction?.StatusEffectStartAction(casterHero,targetHero);
        }
        
        /// <summary>
        /// Unsubscribes standard action to drag skill target event 
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="standardAction"></param>
        public override void UnsubscribeStandardAction(IHero casterHero, IHero targetHero, IStandardActionAsset standardAction)
        {
            var statusEffectAction = standardAction as IStatusEffectActionAsset;

            statusEffectAction?.UndoStatusEffectStartAction(casterHero,targetHero);
        }
    }
}
