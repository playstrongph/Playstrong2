using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectTypeAssets
{
    [CreateAssetMenu(fileName = "BuffType", menuName = "Assets/StatusEffectType/BuffType")]
    public class BuffTypeAsset : StatusEffectTypeAsset
    {
        /// <summary>
        /// Add buffs to the specific status effect list
        /// </summary>
        /// <param name="heroStatusEffects"></param>
        /// <param name="heroStatusEffect"></param>
        public override void AddToStatusEffectsList(IHeroStatusEffects heroStatusEffects, IStatusEffect heroStatusEffect)
        {
            heroStatusEffects.BuffEffects.AddToList(heroStatusEffect);
        }
        
        /// <summary>
        /// Remove buffs from the specific status effect list.
        /// </summary>
        /// <param name="heroStatusEffects"></param>
        /// <param name="heroStatusEffect"></param>
        public override void RemoveFromStatusEffectsList(IHeroStatusEffects heroStatusEffects, IStatusEffect heroStatusEffect)
        {
            heroStatusEffects.BuffEffects.RemoveFromList(heroStatusEffect);
        }
    }
}
