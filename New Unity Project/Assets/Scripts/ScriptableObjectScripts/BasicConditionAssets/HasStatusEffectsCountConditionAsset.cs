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
            var buffValue = 0;
            var debuffValue = 0;
            var uniqueEffectsValue = 0;

            var buffs = hero.HeroStatusEffects.BuffEffects.StatusEffects.Count;
            var debuffs = hero.HeroStatusEffects.DebuffEffects.StatusEffects.Count;
            var uniqueEffects = hero.HeroStatusEffects.UniqueStatusEffects.StatusEffects.Count;


            //Buff value logic
            var buffValue1 = buffs > buffsGreaterThan ? 1 : 0;
            var buffValue2 = buffs < buffsLessThan ? 1 : 0;
            var buffValue3 = buffs == buffsEqualTo ? 1 : 0;
            
            //if any of the above is true, value is 1
            buffValue = Mathf.Clamp(buffValue1 + buffValue2 + buffValue3, 0, 1);       
            
            //Debuff value logic
            var debuffValue1 = debuffs > debuffsGreaterThan ? 1 : 0;
            var debuffValue2 = debuffs < debuffsLessThan ? 1 : 0;
            var debuffValue3 = debuffs == debuffsEqualTo ? 1 : 0;
            
            //if any of the above is true, value is 1
            debuffValue = Mathf.Clamp(debuffValue1 + debuffValue2 + debuffValue3,0,1);
            
            //Unique effect value logic
            var uniqueEffectsValue1 = uniqueEffects > uniqueEffectsGreaterThan ? 1 : 0;
            var uniqueEffectsValue2 = uniqueEffects < uniqueEffectsLessThan ? 1 : 0;
            var uniqueEffectsValue3 = uniqueEffects == uniqueEffectsEqualTo ? 1 : 0;

            uniqueEffectsValue = Mathf.Clamp(uniqueEffectsValue1 + uniqueEffectsValue2 + uniqueEffectsValue3, 0, 1);
            
            
            //Set to 1 if any of the conditions above is met
            value = Mathf.Clamp(buffValue + debuffValue + uniqueEffectsValue,0,1);

            return value;
        }
    }
}
