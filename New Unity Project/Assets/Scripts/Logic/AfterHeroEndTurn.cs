using System.Collections;
using UnityEngine;

namespace Logic
{
    public class AfterHeroEndTurn : MonoBehaviour, IAfterHeroEndTurn
    {
        private ITurnController _turnController;

        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
        }
        
        /// <summary>
        /// Update all skills cooldown, call after hero end turn event, call after combat event, update status effects,
        /// and call next phase - start next active hero 
        /// </summary>
        /// <returns></returns>
        public IEnumerator StartAction()
        {
            var logicTree = _turnController.CoroutineTrees.MainLogicTree;
            var currentActiveHero = _turnController.CurrentActiveHero;
            
            //Set hero status to Inactive
            currentActiveHero.HeroLogic.SetHeroActiveStatus.InactiveHero();
            
            //Hide green border, portrait, and skills
            currentActiveHero.HeroLogic.HeroActiveStatus.StatusAction(currentActiveHero);
            
            //TODO: Update Hero Skills Cooldown
        
            //TODO - EventAfterHeroEndTurn
        
            //TODO - EventAfterCombatTurn
        
            //TODO - UpdateEndTurnStatusEffects
            
            //TODO - IEnumerator Start Next Active Hero
            
            //TEST
            logicTree.AddCurrent(StartNextHeroTurn());
            
            logicTree.EndSequence();
            yield return null;
            
        }
        
        private IEnumerator StartNextHeroTurn()
        {
            var logicTree = _turnController.CoroutineTrees.MainLogicTree;

            logicTree.AddCurrent(_turnController.ActiveHeroes.Count > 0
                ? _turnController.SetCurrentActiveHero.StartAction()
                : _turnController.StartHeroTimers());

            logicTree.EndSequence();
            yield return null;
        }


    }
}
