using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Logic
{
    public class SetActiveHeroes : MonoBehaviour, ISetActiveHeroes
    {
        private ITurnController _turnController;

        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
        }

        /// <summary>
        /// Add hero to the turn controller's active heroes list
        /// </summary>
        /// <param name="hero"></param>
        public void AddHero(IHero hero)
        {
            var activeHeroes = _turnController.ActiveHeroes;
            var activeHeroesList = _turnController.HeroesTurnQueue;

            if(!activeHeroes.Contains(hero)) 
                activeHeroesList.Add(hero as Object); 
        }
        
        /// <summary>
        /// Remove hero from the turn controller's active heroes list
        /// </summary>
        /// <param name="hero"></param>
        public void RemoveHero(IHero hero)
        {
            var activeHeroes = _turnController.ActiveHeroes;
            var activeHeroesList = _turnController.HeroesTurnQueue;

            if(!activeHeroes.Contains(hero)) 
                activeHeroesList.Remove(hero as Object); 
        }


    }
}
