using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Logic
{
    public class UpdateHeroTimers : MonoBehaviour, IUpdateHeroTimers
    {
        private ITurnController _turnController;
        
        private readonly List<IHero> _allLivingHeroes = new List<IHero>();
        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
        }

        //private int i = 0;
        
        /// <summary>
        /// Updates all living heroes hero timers
        /// </summary>
        public void StartAction()
        {
            var allyHeroes = _turnController.BattleSceneManager.MainPlayer.AliveHeroes;
            var enemyHeroes = _turnController.BattleSceneManager.EnemyPlayer.AliveHeroes;
            
            //ensure list is empty
            _allLivingHeroes.Clear();

            //add all ally heroes to all living heroes
            foreach (var hero in allyHeroes.Heroes)
            {
                _allLivingHeroes.Add(hero);
            }
            
            //add all enemy heroes to all living heroes
            foreach (var hero in enemyHeroes.Heroes)
            {
                _allLivingHeroes.Add(hero);
            }
            
            Debug.Log("All Living Heroes Count: " +_allLivingHeroes.Count);
            //update each hero's hero timer
            foreach (var hero in _allLivingHeroes)
            {
                hero.HeroLogic.HeroTimer.UpdateHeroTimer();
            }
        }

        
    }
}
