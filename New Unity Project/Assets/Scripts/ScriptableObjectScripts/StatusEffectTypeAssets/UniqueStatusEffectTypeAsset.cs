using Logic;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectTypeAssets
{
    [CreateAssetMenu(fileName = "UniqueType", menuName = "Assets/StatusEffectType/UniqueType")]
    public class UniqueStatusEffectTypeAsset : StatusEffectTypeAsset
    {
        
        /// <summary>
        /// Add unique status effects to the specific status effect list
        /// </summary>
        /// <param name="heroStatusEffects"></param>
        /// <param name="heroStatusEffect"></param>
        public override void AddToStatusEffectsList(IHeroStatusEffects heroStatusEffects, IStatusEffect heroStatusEffect)
        {
            heroStatusEffects.UniqueStatusEffects.AddToList(heroStatusEffect);
        }
        
        /// <summary>
        /// Remove unique status effects from the specific status effect list.
        /// </summary>
        /// <param name="heroStatusEffects"></param>
        /// <param name="heroStatusEffect"></param>
        public override void RemoveFromStatusEffectsList(IHeroStatusEffects heroStatusEffects, IStatusEffect heroStatusEffect)
        {
            heroStatusEffects.UniqueStatusEffects.RemoveFromList(heroStatusEffect);
        }

        public override int AddStatusEffectNetChance(IHero casterHero,IHero targetHero, int defaultChance)
        {
            Debug.Log("Unique Status Effect Net Chance");

            return defaultChance;
        }
        
    }
}
