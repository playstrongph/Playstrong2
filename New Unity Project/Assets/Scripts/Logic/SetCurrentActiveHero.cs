using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Logic
{
    public class SetCurrentActiveHero : MonoBehaviour, ISetCurrentActiveHero
    {
        private ITurnController _turnController;

        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
        }
        
        /// <summary>
        /// Sets the current active heroes from the active heroes list, resets energy to zero, and
        /// calls combat start turn event
        /// </summary>
        /// <returns></returns>
        public IEnumerator StartAction()
        {
            var logicTree = _turnController.CoroutineTrees.MainLogicTree;
            var visualTree = _turnController.CoroutineTrees.MainVisualTree;
            
            //Sort the heroes (random sort for heroes with equal energy)
            _turnController.SortHeroesByEnergy.StartAction();
            
            //Set the current active hero
            _turnController.CurrentActiveHero = _turnController.ActiveHeroes[_turnController.ActiveHeroes.Count - 1];

            //Remove the current active hero from the hero active heroes list
            _turnController.HeroesTurnQueue.Remove(_turnController.CurrentActiveHero as Object);
            
            //Set the current hero's active status to "ActiveHero"
            _turnController.CurrentActiveHero.HeroLogic.SetHeroActiveStatus.ActiveHero();
            
            //Reset the energy of the current active hero
            _turnController.CurrentActiveHero.HeroLogic.SetEnergy.ResetToZero();
            
           
            //Set energy visual
            var energy = (int) _turnController.CurrentActiveHero.HeroVisual.Hero.HeroLogic.HeroTimer.TimerValuePercent;
            visualTree.AddCurrent(SetEnergyVisual(energy));

            //TODO: Event call - EventCombatStartTurn
            
            //CALL NEXT PHASE
            logicTree.AddCurrent(_turnController.BeforeHeroStartTurn.StartAction());

            logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator SetEnergyVisual(int value)
        {
            var visualTree = _turnController.CoroutineTrees.MainVisualTree;
            
            _turnController.CurrentActiveHero.HeroVisual.SetEnergyVisual.StartAction(value);
            
            visualTree.EndSequence();
            yield return null;
        }
    }
}
