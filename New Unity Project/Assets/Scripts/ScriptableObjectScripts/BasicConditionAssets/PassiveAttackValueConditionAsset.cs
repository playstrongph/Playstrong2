using AssetsScriptableObjects;
using Logic;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicConditionAssets
{
    [CreateAssetMenu(fileName = "PassiveAttackValueCondition", menuName = "Assets/BasicConditions/P/PassiveAttackValueCondition")]
    public class PassiveAttackValueConditionAsset : BasicConditionAsset
    {
        [Header("Negative value means limit is DISABLED")]
        [Header("Set Limit Value")]
        
        //Negative limit means it's disabled
        [SerializeField] private int lessThanFlatLimit = -9999999;
        
        //Big limit value means it's disabled
        [SerializeField] private int greaterThanFlatLimit = 9999999;
        
        //Negative limit means it's disabled
        [SerializeField] private int equalToFlatLimit = -99999999;
        
        
        [Header("Base Attack Limits")]
        
        //Negative limit means it's disabled
        [SerializeField] private int percentBaseAttackLessThanLimit = -9999999;
        
        //Big limit value means it's disabled
        [SerializeField] private int percentBaseAttackGreaterThanLimit = 9999999;
        
        //Negative limit means it's disabled
        [SerializeField] private int percentBaseAttackEqualToLimit = -99999999;
        

        protected override int CheckConditionValue(IHero hero)
        {
            //Initialize to false
            var value = 0;

            var passiveAttack = hero.HeroLogic.HeroAttributes.PassiveAttack;

            if (passiveAttack < lessThanFlatLimit)
            {
                value = 1;
                Debug.Log("Less than flat limit true: " +hero.HeroName);
            }

            if (passiveAttack > greaterThanFlatLimit)
            {
                value = 1;  //Condition is met
                Debug.Log("Greater than flat limit true: " +hero.HeroName);
            }

            if (passiveAttack == equalToFlatLimit)
            {
                value = 1;  //Condition is met
                Debug.Log("Equal to flat limit true: " +hero.HeroName);
            }


            var baseAttack = hero.HeroLogic.HeroAttributes.BaseAttack;

            if (passiveAttack < Mathf.RoundToInt(baseAttack * percentBaseAttackLessThanLimit / 100f))
            {
                value = 1;  //Condition is met
                Debug.Log("percentBaseAttackLessThanLimit true: " +hero.HeroName);
            }

            if (passiveAttack > Mathf.RoundToInt(baseAttack * percentBaseAttackGreaterThanLimit / 100f))
            {
                value = 1;  //Condition is met
                Debug.Log("percentBaseAttackGreaterThanLimit true: " +hero.HeroName);
            }

            if (passiveAttack == Mathf.RoundToInt(baseAttack * percentBaseAttackEqualToLimit / 100f))
            {
                value = 1;  //Condition is met
                Debug.Log("percentBaseAttackEqualToLimit true " +hero.HeroName);
            }
            
            Debug.Log("Value: " +value);

            return value;
        }
    }
}
