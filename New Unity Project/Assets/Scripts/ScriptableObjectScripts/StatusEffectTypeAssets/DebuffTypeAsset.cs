using Logic;
using ScriptableObjectScripts.StatusEffectAssets;
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
        
        /// <summary>
        /// Net chance to add a debuff
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="defaultChance"></param>
        /// <returns></returns>
        public override int AddStatusEffectNetChance(IHero casterHero,IHero targetHero, int defaultChance)
        {
            //Caster's total add debuff chance. 
            var debuffChance = casterHero.HeroLogic.ChanceAttributes.DebuffChance + defaultChance;
                        
            //Target's debuff resistance
            var debuffResistance = targetHero.HeroLogic.ResistanceAttributes.DebuffResistance;
                        
            //Effective add debuff chance
            var netDebuffChance = debuffChance - debuffResistance;

            return netDebuffChance;
        }
    }
}
