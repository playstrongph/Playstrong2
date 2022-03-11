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
        /// Used by AddStatusEffect asset to add status effects based on type
        /// </summary>
        public override void AddTypeOfStatusEffect(IStatusEffectAsset statusEffectAsset, IHero casterHero,IHero targetHero, int defaultChance, int counters)
        {
            Debug.Log("Add UniqueStatusEffectType");
            
            //unique status effects have no hero "chances" ar "resistances
            var netChance = defaultChance;
            
            //Random chance, 1 to 100.
            var randomChance = Random.Range(1, 101);
            
            if(randomChance <= netChance)
                statusEffectAsset.StatusEffectInstanceType.AddStatusEffect(targetHero,casterHero,statusEffectAsset,counters);
        }
        
    }
}
