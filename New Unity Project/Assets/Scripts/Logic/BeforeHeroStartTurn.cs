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
            
            //execute hero action relative to hero inability status 
            logicTree.AddCurrent(currentActiveHero.HeroLogic.HeroInabilityStatus.TurnControllerAction(_turnController));

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Starts the hero turn when hero has no inability
        /// called by NoInabilityAsset's status action
        /// </summary>
        public void HeroStartTurn()
        {
            var logicTree = _turnController.CoroutineTrees.MainLogicTree;
            
            logicTree.AddCurrent(_turnController.HeroStartTurn.StartAction());
        }

       
    }
}
