using AssetsScriptableObjects;
using Logic;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicConditionAssets
{
    [CreateAssetMenu(fileName = "HealthValueCondition", menuName = "Assets/BasicConditions/H/HealthValueCondition")]
    public class HealthValueConditionAsset : BasicConditionAsset
    {
        [Header("Negative value means limit is DISABLED")]
        [Header("Set Limit Value")]
        
        //Negative limit means it's disabled
        [SerializeField] private int lessThanFlatLimit = -9999999;
        
        //Big limit value means it's disabled
        [SerializeField] private int greaterThanFlatLimit = 9999999;
        
        //Negative limit means it's disabled
        [SerializeField] private int equalToFlatLimit = -99999999;
        
        
        [Header("Base Health Limits")]
        
        //Negative limit means it's disabled
        [SerializeField] private int percentBaseHealthLessThanLimit = -9999999;
        
        //Big limit value means it's disabled
        [SerializeField] private int percentBaseHealthGreaterThanLimit = 9999999;
        
        //Negative limit means it's disabled
        [SerializeField] private int percentBaseHealthEqualToLimit = -99999999;
        

        protected override int CheckConditionValue(IHero hero)
        {
            //Initialize to false
            var value = 0;

            var health = hero.HeroLogic.HeroAttributes.Health;

            if (health < lessThanFlatLimit)
            {
                value = 1;
            }

            if (health > greaterThanFlatLimit)
            {
                value = 1;  //Condition is met
            }

            if (health == equalToFlatLimit)
            {
                value = 1;  //Condition is met
            }


            var baseHealth = hero.HeroLogic.HeroAttributes.BaseHealth;

            if (health < Mathf.RoundToInt(baseHealth * percentBaseHealthLessThanLimit / 100f))
            {
                value = 1;  //Condition is met
            }

            if (health > Mathf.RoundToInt(baseHealth * percentBaseHealthGreaterThanLimit / 100f))
            {
                value = 1;  //Condition is met
            }

            if (health == Mathf.RoundToInt(baseHealth * percentBaseHealthEqualToLimit / 100f))
            {
                value = 1;  //Condition is met
            }

            return value;
        }
    }
}
