using System;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class UpdateHeroTimers : MonoBehaviour, IUpdateHeroTimers
    {
        private ITurnController _turnController;
        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
        }
        
        /// <summary>
        /// Updates all living heroes hero timers
        /// </summary>
        public void StartAction()
        {
            var allLivingHeroes = new List<IHero>();
            var allyHeroes = _turnController.BattleSceneManager.MainPlayer.AliveHeroes.LivingHeroes;
            var enemyHeroes = _turnController.BattleSceneManager.EnemyPlayer.AliveHeroes.LivingHeroes;
            
            //ensure list is empty
            allLivingHeroes.Clear();
            
            //add all ally heroes to all living heroes
            foreach (var hero in allyHeroes)
            {
                 allLivingHeroes.Add(hero);
            }
            
            //add all enemy heroes to all living heroes
            foreach (var hero in enemyHeroes)
            {
                allLivingHeroes.Add(hero);
            }
            
            //update each hero's hero timer
            foreach (var hero in allLivingHeroes)
            {
                hero.HeroLogic.HeroTimer.UpdateHeroTimer(_turnController);
            }

        }
    }
}
