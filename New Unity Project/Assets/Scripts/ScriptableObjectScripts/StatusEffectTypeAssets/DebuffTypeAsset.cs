using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectTypeAssets
{
    [CreateAssetMenu(fileName = "DebuffType", menuName = "Assets/StatusEffectType/DebuffType")]
    public class DebuffTypeAsset : StatusEffectTypeAsset
    {
        /// <summary>
        /// Add debuffs to the specific status effect list
        /// </summary>
        /// <param name="heroStatusEffects"></param>
        /// <param name="heroStatusEffect"></param>
        public override void AddToStatusEffectsList(IHeroStatusEffects heroStatusEffects, IStatusEffect heroStatusEffect)
        {
            heroStatusEffects.DebuffEffects.AddToList(heroStatusEffect);
        }
        
        /// <summary>
        /// Remove debuffs from the specific status effect list.
        /// </summary>
        /// <param name="heroStatusEffects"></param>
        /// <param name="heroStatusEffect"></param>
        public override void RemoveFromStatusEffectsList(IHeroStatusEffects heroStatusEffects, IStatusEffect heroStatusEffect)
        {
            heroStatusEffects.DebuffEffects.RemoveFromList(heroStatusEffect);
        }
    }
}
