using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.HeroActiveStatusAssets
{
    /// <summary>
    /// Hero Inactive Status
    /// </summary>
    [CreateAssetMenu(fileName = "InactiveHero", menuName = "Assets/HeroActiveStatus/InactiveHero")]
    public class InactiveHeroAsset : HeroActiveStatusAsset
    {
        public override void StatusAction(IHero hero)
        {
            
        }
    }
}
