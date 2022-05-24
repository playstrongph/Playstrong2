using AssetsScriptableObjects;
using Logic;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicConditionAssets
{
    [CreateAssetMenu(fileName = "SkillCountersCondition", menuName = "Assets/BasicConditions/S/SkillCountersCondition")]
    public class SkillCountersConditionAsset : BasicConditionAsset
    {
        [SerializeField] private ScriptableObject skillAsset;

        private ISkillAsset SkillAsset
        {
            get => skillAsset as ISkillAsset;
            set => skillAsset = value as ScriptableObject;
        }
        
        [Header("Set Limit Value")]
        [SerializeField] private int lessThanLimit = -99;
        [SerializeField] private int greaterThanLimit = -99;

        protected override int CheckConditionValue(IHero hero)
        {
            //Initialize to false
            var value = 0;

            var skills = hero.HeroSkills.AllSkills;
            
            //initialize 
            var skillCounters = 0;
            

            foreach (var skill in skills)
            {
                if (skill.SkillName == SkillAsset.SkillName)
                    skillCounters = skill.SkillLogic.OtherSkillAttributes.SkillCounters;
            }
            
            
            
            //Value greater than zero means greater than limit is enforced
            if(lessThanLimit >=0)
                //Counters are less than or equal to upper limit
                if (skillCounters < lessThanLimit)
                {
                    Debug.Log("skill Counters: " +skillCounters +" less than limit: " +lessThanLimit);
                    value = 1;
                }

              
            
            //Value greater than zero means less than limit is enforced
            if(greaterThanLimit >=0)
                //Counters are greater than lower limit
                if (skillCounters > greaterThanLimit)
                {
                    Debug.Log("skill Counters: " +skillCounters +" greater than limit: " +lessThanLimit);
                    value = 1;  //Condition is met
                }
            
            Debug.Log("Return Value:" +value);
            
            return value;
        }
    }
}
