using Logic;
using ScriptableObjectScripts.StatusEffectAssets;
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
        
        /// <summary>
        /// Add "buff" type status effect
        /// </summary>
        /// <param name="statusEffectAsset"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="defaultChance"></param>
        /// <param name="counters"></param>
        public override void AddTypeOfStatusEffect(IStatusEffectAsset statusEffectAsset, IHero casterHero,IHero targetHero, int defaultChance, int counters)
        {
            
            Debug.Log("Add Buff Type");
            
             //Caster's total add buff chance. 
             var buffChance = casterHero.HeroLogic.ChanceAttributes.BuffChance + defaultChance;
                        
             //Target's buff resistance
             var buffResistance = targetHero.HeroLogic.ResistanceAttributes.BuffResistance;
                        
             //Effective add buff chance
             var netBuffChance = buffChance - buffResistance;
                        
             //Random chance, 1 to 100.
             var randomChance = Random.Range(1, 101);
                       
             //Example - addBuffChance is 75% and random chance is 50.
             //TODO: Need to carve out animations here: StatusEffect action animations, update status effect counters, 
             //TODO: show status effect symbol
             if(randomChance <= netBuffChance)
                            statusEffectAsset.StatusEffectInstanceType.AddStatusEffect(targetHero,casterHero,statusEffectAsset,counters);
        }

        
        
    }
}
