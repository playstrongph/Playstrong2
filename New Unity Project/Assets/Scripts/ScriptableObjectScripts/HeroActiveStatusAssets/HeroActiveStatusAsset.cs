using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.HeroActiveStatusAssets
{
    /// <summary>
    /// Base class for ActiveHero and InactiveHero
    /// Generic Asset
    /// </summary>
    public abstract class HeroActiveStatusAsset : ScriptableObject, IHeroActiveStatusAsset
    {
        public virtual void StatusAction(IHero hero)
        {
            
        }


    }
}
