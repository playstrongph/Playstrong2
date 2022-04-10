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
        [SerializeField] private int lowerLimit = -99;
        [SerializeField] private int upperLimit = -99;

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
            
            //This means upper limit condition
            if(upperLimit >=0)
                if (statusEffectCounters <= upperLimit)
                    value = 1;  //Condition is met
            
            //This means lower limit condition
            if(lowerLimit >=0)
                if (statusEffectCounters >= lowerLimit)
                    value = 1;  //Condition is met
            
            
            
            return value;
        }
    }
}
