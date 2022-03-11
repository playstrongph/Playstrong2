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
        /// Add "debuff" type status effect
        /// </summary>
        /// <param name="statusEffectAsset"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="defaultChance"></param>
        /// <param name="counters"></param>
        public override void AddTypeOfStatusEffect(IStatusEffectAsset statusEffectAsset, IHero casterHero,IHero targetHero, int defaultChance, int counters)
        {
            Debug.Log("Add Debuff Type");
            
            //Caster's total add buff chance. 
            //TODO: change to debuff chance
            var debuffChance = casterHero.HeroLogic.ChanceAttributes.DebuffChance + defaultChance;
                        
            //Target's buff resistance
            var debuffResistance = targetHero.HeroLogic.ResistanceAttributes.DebuffResistance;
                        
            //Effective add buff chance
            var netDebuffChance = debuffChance - debuffResistance;
                        
            //Random chance, 1 to 100.
            var randomChance = Random.Range(1, 101);
                       
            //Example - addBuffChance is 75% and random chance is 50.
            //TODO: Need to carve out animations here: StatusEffect action animations, update status effect counters, 
            //TODO: show status effect symbol
            if(randomChance <= netDebuffChance)
                statusEffectAsset.StatusEffectInstanceType.AddStatusEffect(targetHero,casterHero,statusEffectAsset,counters);
        }
    }
}
