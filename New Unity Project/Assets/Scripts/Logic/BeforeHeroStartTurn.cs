using System.Collections;
using UnityEngine;

namespace Logic
{
    public class BeforeHeroStartTurn : MonoBehaviour, IBeforeHeroStartTurn
    {
        private ITurnController _turnController;

        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
        }
        
        /// <summary>
        /// Calls before start turn event, updates status effects, starts hero action depending
        /// on hero inability status 
        /// </summary>
        /// <returns></returns>
        public IEnumerator StartAction()
        {
            var logicTree = _turnController.CoroutineTrees.MainLogicTree;
            var currentActiveHero = _turnController.CurrentActiveHero;
            
            //TODO: EVENT - EventBeforeHeroStartTurn, wrap this in an IEnumerator
            
            //TODO: UpdateStartTurnStatusEffects, wrap this in an IEnumerator
            
            //Start action relative to hero inability status
            logicTree.AddCurrent(currentActiveHero.HeroLogic.HeroInabilityStatus.StartAction(_turnController));

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Starts the hero turn when hero has no inability
        /// CALLS NEXT PHASE IN THE TURN
        /// </summary>
        public void HeroStartTurn()
        {
            //TODO: StartHeroTurn IEnumerator
        }

        private void CheckHeroInability()
        {
            
        }
    }
}
