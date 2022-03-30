using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class UpdateHeroTimers : MonoBehaviour, IUpdateHeroTimers
    {
        private ITurnController _turnController;
        
        //TEST
        /// <summary>
        /// Delays the start of update timers
        /// </summary>
        public float DelayUpdateTimer { get; set; }

        private readonly List<IHero> _allLivingHeroes = new List<IHero>();
        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
            
           
        }

        /// <summary>
        /// Updates all living heroes hero timers
        /// </summary>
        public void StartAction()
        {
            AllLivingHeroes();
            
            UpdateTimers();
        }

        private void UpdateTimers()
        {
            foreach (var hero in _allLivingHeroes)
            {
                hero.HeroLogic.HeroTimer.UpdateHeroTimer();
                
                var energy = (int) hero.HeroVisual.Hero.HeroLogic.HeroTimer.TimerValuePercent;
                hero.HeroVisual.SetEnergyVisual.StartAction(energy);
            }
        }

        private void AllLivingHeroes()
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
        }


    }
}