using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Sorts the active heroes in turn controller from highest to lowest energy
    /// </summary>
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class SortHeroesByEnergy : MonoBehaviour, ISortHeroesByEnergy
    {
        
        private ITurnController _turnController;

        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
        }

        /// <summary>
        /// Sorts the heroes in the active heroes from highest to lowest energy
        /// Originally, this was a Coroutine 
        /// </summary>
        /// <returns></returns>
        public void StartAction()
        {
            var activeHeroesList = _turnController.HeroesTurnQueue;
            
            ShuffleList(activeHeroesList).Sort(CompareListByEnergy);
        }
        
        
        //AUXILIARY METHODS
        
        
        /// <summary>
        /// Compares each element of the list to sort from
        /// highest to lowest value
        /// </summary>
        /// <param name="i1"></param>
        /// <param name="i2"></param>
        /// <returns></returns>
        private int CompareListByEnergy(Object i1, Object i2)
        {
            //Cast objects as Hero
            var x1 = i1 as IHero;
            var x2 = i2 as IHero;
            
            //get hero timer components
            var ix1 = x1.HeroLogic.HeroTimer;
            var ix2 = x2.HeroLogic.HeroTimer;
            
            var x = ix1.TimerValue.CompareTo(ix2.TimerValue);
            
            return x;
        }
        
        /// <summary>
        /// Randomize the list
        /// </summary>
        /// <param name="heroList"></param>
        /// <returns></returns>
        private List<Object> ShuffleList(List<Object> heroList)
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

    }
}