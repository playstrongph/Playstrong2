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
        
        /// <summary>
        /// Net chance to add a unique status effect
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="defaultChance"></param>
        /// <returns></returns>
        public override int AddStatusEffectNetChance(IHero casterHero,IHero targetHero, int defaultChance)
        {
            return defaultChance;
        }
        
    }
}
