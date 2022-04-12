using Logic;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicConditionAssets
{
    [CreateAssetMenu(fileName = "StatusEffectCountersCondition", menuName = "Assets/BasicConditions/S/StatusEffectCountersCondition")]
    public class StatusEffectCountersConditionAsset : BasicConditionAsset
    {
        [SerializeField] private ScriptableObject statusEffectAsset;

        private IStatusEffectAsset StatusEffectAsset
        {
            get => statusEffectAsset as IStatusEffectAsset;
            set => statusEffectAsset = value as ScriptableObject;
        }
        
        [Header("Set Limit Value")]
        [SerializeField] private int lessThanLimit = -99;
        [SerializeField] private int greaterThanLimit = -99;

        protected override int CheckConditionValue(IHero hero)
        {
            //Initialize to false
            var value = 0;
            
            var statusEffects = hero.HeroStatusEffects.GetAllStatusEffects(hero);
            
            //initialize 
            var statusEffectCounters = 0;
            

            foreach (var statusEffect in statusEffects)
            {
                if (statusEffect.StatusEffectName == StatusEffectAsset.StatusEffectName)
                    statusEffectCounters = statusEffect.CountersValue;
            }

            //Value greater than zero means less than limit is enforced
            if(lessThanLimit >=0)
                //This means lower limit condition
                if (statusEffectCounters <= lessThanLimit)
                    value = 1;  //Condition is met
            
           
            if(greaterThanLimit >=0)
                //This means upper limit condition
                if (statusEffectCounters >= greaterThanLimit)
                    value = 1;  //Condition is met
            
            
            
            return value;
        }
    }
}
