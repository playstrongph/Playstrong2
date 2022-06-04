using Logic;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicConditionAssets
{
    [CreateAssetMenu(fileName = "HasStatusEffectsCountCondition", menuName = "Assets/BasicConditions/H/HasStatusEffectsCountCondition")]
    public class HasStatusEffectsCountConditionAsset : BasicConditionAsset
    {
        
        /// <summary>
        /// Default values set to result to a false condition
        /// </summary>
        [Header("Buffs Count")] [SerializeField]
        private int buffsGreaterThan = 9999;

        [SerializeField] private int buffsLessThan = -9999;

        [SerializeField] private int buffsEqualTo = -9999;
        
        [Header("Debuffs Count")] [SerializeField]
        private int debuffsGreaterThan = 9999;

        [SerializeField] private int debuffsLessThan = -9999;

        [SerializeField] private int debuffsEqualTo = -9999;
        
        
        [Header("Unique StatusEffects Count")] [SerializeField]
        private int uniqueEffectsGreaterThan = 9999;

        [SerializeField] private int uniqueEffectsLessThan = -9999;

        [SerializeField] private int uniqueEffectsEqualTo = -9999;

        
        
        

        protected override int CheckConditionValue(IHero hero)
        {
            //Default is False
            var value = 0;

            var buffs = hero.HeroStatusEffects.BuffEffects.StatusEffects.Count;
            var debuffs = hero.HeroStatusEffects.DebuffEffects.StatusEffects.Count;
            var uniqueEffects = hero.HeroStatusEffects.UniqueStatusEffects.StatusEffects.Count;

            var buffValue = 0;
            var debuffValue = 0;
            var uniqueEffectsValue = 0;
            
            //Buff value logic
            buffValue = buffs > buffsGreaterThan ? 1 : 0;
            buffValue = buffs < buffsLessThan ? 1 : 0;
            buffValue = buffs == buffsEqualTo ? 1 : 0;
            
            //Debuff value logic
            debuffValue = debuffs > debuffsGreaterThan ? 1 : 0;
            debuffValue = debuffs < debuffsLessThan ? 1 : 0;
            debuffValue = debuffs == debuffsEqualTo ? 1 : 0;
            
            //Unique effect value logic
            uniqueEffectsValue = uniqueEffects > uniqueEffectsGreaterThan ? 1 : 0;
            uniqueEffectsValue = uniqueEffects < uniqueEffectsLessThan ? 1 : 0;
            uniqueEffectsValue = uniqueEffects == uniqueEffectsEqualTo ? 1 : 0;
            
            
            //Set to 1 if any of the conditions above is met
            value = buffValue + debuffValue + uniqueEffectsValue;
        
            
            return value;
        }
    }
}
