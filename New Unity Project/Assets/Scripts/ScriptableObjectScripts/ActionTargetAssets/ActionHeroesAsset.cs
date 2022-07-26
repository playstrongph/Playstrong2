using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.ActionTargetAssets
{
    
    /// <summary>
    /// Base class for action targets
    /// </summary>
    public abstract class ActionHeroesAsset : ScriptableObject, IActionHeroesAsset
    {

        /// <summary>
        /// Returns list of action or basic condition targets
        /// Used by Basic Conditions and Basic Actions
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="standardActionAsset"></param>
        /// <returns></returns>
        public virtual List<IHero> GetActionHeroes(IHero casterHero, IHero targetHero, IStandardActionAsset standardActionAsset)
        {
            var actionHeroes = new List<IHero>();
            
            Debug.Log("Base Class Action Heroes");
            
            return actionHeroes;
            
        }
        
        /// <summary>
        /// Returns a list of heroes subscribing to the basic event
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public virtual List<IHero> GetEventSubscribers(IHero hero)
        {
            var eventSubscribers = new List<IHero>();
            
            Debug.Log("Base Class Get Event Subscribers");
            
            return eventSubscribers;
            
        }
        
        /// <summary>
        /// Used by Set Hero Targets Basic Actions to ensure a consistent random heroes for the basic actions
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public virtual List<IHero> SetActionHeroes(IHero casterHero, IHero targetHero)
        {
            var actionHeroes = new List<IHero>();
            
            Debug.Log("Base Class Set Action Heroes");

            return actionHeroes;

        }

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
