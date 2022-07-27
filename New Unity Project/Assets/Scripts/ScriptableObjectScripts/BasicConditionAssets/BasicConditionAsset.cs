using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.BasicConditionAssets
{
    public abstract class BasicConditionAsset : ScriptableObject, IBasicConditionAsset
    {      
        /// <summary>
        /// The skill originator of the basic condition
        /// </summary>
        protected ISkill skillParent;
        
        /// <summary>
        /// Set the skill parent during initialization
        /// 
        /// </summary>
        /// <param name="skill"></param>
        public void InitializeSkillParent(ISkill skill)
        {
            skillParent = skill;
        }

        /// <summary>
        /// If Check condition logic is met, returns 1
        /// If Check condition logic is not met, returns 0
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public int ConditionValue(IHero hero)
        {
            return CheckConditionValue(hero);
        }
        
        /// <summary>
        /// Overriden by the deriving classes that implements their logic
        /// E.g. ConditionUsingSpecificSkill
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        protected virtual int CheckConditionValue(IHero hero)
        {
            return 0;
        }

       






    }
}
