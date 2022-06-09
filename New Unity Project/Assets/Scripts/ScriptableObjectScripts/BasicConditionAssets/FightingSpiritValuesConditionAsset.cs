using AssetsScriptableObjects;
using Logic;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicConditionAssets
{
    [CreateAssetMenu(fileName = "FightingSpiritValuesCondition", menuName = "Assets/BasicConditions/F/FightingSpiritValuesCondition")]
    public class FightingSpiritValuesConditionAsset : BasicConditionAsset
    {
        [Header("Negative value means limit is DISABLED")]
        [Header("Set Limit Value")]
        
        //Negative limit means it's disabled
        [SerializeField] private int lessThanLimit = -9999999;
        
        //Big limit value means it's disabled
        [SerializeField] private int greaterThanLimit = 9999999;
        
        //Negative limit means it's disabled
        [SerializeField] private int equalToLimit = -99999999;

        protected override int CheckConditionValue(IHero hero)
        {
            //Initialize to false
            var value = 0;

            var fightingSpirit = hero.HeroLogic.HeroAttributes.FightingSpirit;

            if (fightingSpirit < lessThanLimit)
            {
                value = 1;
            }

            if (fightingSpirit > greaterThanLimit)
            {
                value = 1;  //Condition is met
            }

            if (fightingSpirit == equalToLimit)
            {
                value = 1;  //Condition is met
            }

            return value;
        }
    }
}
