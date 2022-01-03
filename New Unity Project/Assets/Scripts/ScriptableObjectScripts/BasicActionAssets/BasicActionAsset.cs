using System.Collections;
using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    public abstract class BasicActionAsset : ScriptableObject, IBasicActionAsset
    {
        /// <summary>
        /// Checks if the targeted and targeting hero are both alive before
        /// executing the basic action.  Can be overriden to bypass these checks
        /// as required - e.g. resurrect, base stats change
        /// </summary>
        /// <param name="hero"></param>
        public virtual IEnumerator StartAction(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        /// <summary>
        /// Executes the basic action logic
        /// Exclusively used by hero life status
        /// </summary>
        /// <param name="hero"></param>
        public virtual IEnumerator ExecuteAction(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Undoes the effect of execute action, mostly
        /// used in status effects
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public virtual IEnumerator UndoExecuteAction(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Returns a random list of heroes
        /// </summary>
        /// <param name="heroList"></param>
        /// <returns></returns>
        protected List<IHero> ShuffleList(List<IHero> heroList)
        {
            var randomList = heroList;
            
            //Randomize the List
            for (int i = 0; i < randomList.Count; i++) 
            {
                var temp = randomList[i];
                int randomIndex = Random.Range(i, randomList.Count);
                randomList[i] = randomList[randomIndex];
                randomList[randomIndex] = temp;
            }

            return randomList;
        }
        
        /// <summary>
        /// Returns a random list of status effects
        /// </summary>
        /// <param name="statusEffectsList"></param>
        /// <returns></returns>
        protected List<IStatusEffect> ShuffleList(List<IStatusEffect> statusEffectsList)
        {
            //Randomize the List
            for (int i = 0; i < statusEffectsList.Count; i++) 
            {
                var temp = statusEffectsList[i];
                int randomIndex = Random.Range(i, statusEffectsList.Count);
                statusEffectsList[i] = statusEffectsList[randomIndex];
                statusEffectsList[randomIndex] = temp;
            }

            return statusEffectsList;
        }

    }
}
