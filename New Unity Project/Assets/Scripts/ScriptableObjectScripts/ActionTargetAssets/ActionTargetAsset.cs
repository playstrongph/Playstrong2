using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.ActionTargetAssets
{
    
    /// <summary>
    /// Base class for action targets
    /// </summary>
    public abstract class ActionTargetAsset : ScriptableObject, IActionTargetAsset
    {
        /// <summary>
        /// Reference to the hero who casts the skill
        /// </summary>
        protected IHero SkillCasterHero;
        
        /// <summary>
        /// Reference to the hero who created the status effect
        /// </summary>
        protected IHero StatusEffectCasterHero;
        
        /// <summary>
        /// Returns list of action or basic condition targets
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public virtual List<IHero> ActionTargets(IHero hero)
        {
            var actionTargets = new List<IHero>();
            
            Debug.Log("Base Class Action Targets");
            
            return actionTargets;
        }
        
        /// <summary>
        /// Initializes the skill's caster hero used by SkillCasterHero action target
        /// </summary>
        /// <param name="skill"></param>
        public virtual void InitializeSkillCasterHero(ISkill skill)
        {
            SkillCasterHero = skill.CasterHero;
        }
        
        //TODO - public virtual void InitializeStatusEffectCasterHero(IStatusEffect statusEffect)
        
        
        /// <summary>
        /// Returns a randomized hero list.
        /// Used in multiple action targets.
        /// </summary>
        /// <param name="heroList"></param>
        /// <returns></returns>
        protected List<IHero> ShuffleList(List<IHero> heroList)
        {
            //Randomize the List
            for (var i = 0; i < heroList.Count; i++) 
            {
                var temp = heroList[i];
                var randomIndex = Random.Range(i, heroList.Count);
                heroList[i] = heroList[randomIndex];
                heroList[randomIndex] = temp;
            }

            return heroList;
        }






    }
}
