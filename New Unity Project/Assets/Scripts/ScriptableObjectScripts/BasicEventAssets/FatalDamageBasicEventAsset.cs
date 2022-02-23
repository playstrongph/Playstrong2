using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicEventAssets
{
    [CreateAssetMenu(fileName = "FatalDamageEvent", menuName = "Assets/BasicEvents/FatalDamageEvent")]
    public class FatalDamageBasicEventAsset : BasicEventAsset
    {
       
        public override void SubscribeStandardAction(IHero hero, IStandardActionAsset standardAction)
        {
            //hero.HeroLogic.HeroEvents.EHeroTakesFatalDamage += standardAction.StartAction;
        }
    }
}
