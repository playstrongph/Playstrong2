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
        /*/// <summary>
        /// Reference to the hero who casts the skill
        /// </summary>
        ///TODO: Try to clean this up
        protected IHero SkillCasterHero;
        
        /// <summary>
        /// Reference to the hero who created the status effect
        /// </summary>
        ///TODO: Try to clean this up
        protected IHero StatusEffectCasterHero;*/
        
        /// <summary>
        /// Returns list of action or basic condition targets
        /// Used by Basic Conditions and Basic Actions
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public virtual List<IHero> GetActionTargets(IHero casterHero, IHero targetHero)
        {
            var actionTargets = new List<IHero>();
            
            Debug.Log("Base Class Action Targets");
            
            return actionTargets;
            
        }
        
        /// <summary>
        /// Returns a list of heroes subscribing to the basic event
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public virtual List<IHero> GetEventSubscribers(IHero hero)
        {
            var actionTargets = new List<IHero>();
            
            Debug.Log("Base Class Get Event Subscribers");
            
            return actionTargets;
            
        }
        
        
        
        /*/// <summary>
        /// Initializes the skill's caster hero used by SkillCasterHero action target
        /// </summary>
        /// <param name="skill"></param>
        public virtual void InitializeSkillCasterHero(ISkill skill)
        {
            SkillCasterHero = skill.CasterHero;
        }*/
        
        /*/// <summary>
        /// Sets the reference to the status effect's caster hero
        /// </summary>
        /// <param name="statusEffect"></param>
        public virtual void InitializeStatusEffectCasterHero(IStatusEffect statusEffect)
        {
            StatusEffectCasterHero = statusEffect.StatusEffectCasterHero;
        }*/
        
        
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
