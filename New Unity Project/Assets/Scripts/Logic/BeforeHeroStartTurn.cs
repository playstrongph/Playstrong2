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
            
            //TODO: Turn controller Event - Event Before Combat  
            
            //TODO: Hero event - EventBeforeHeroStartTurn, wrap this in an IEnumerator
            
            //Update start turn status effects (reduce their counters)
            logicTree.AddCurrent(UpdateStatusEffects());
            
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
        
        /// <summary>
        /// Reduce all "start turn counter update" status effect counters
        /// </summary>
        /// <returns></returns>
        private IEnumerator UpdateStatusEffects()
        {
            var currentActiveHero = _turnController.CurrentActiveHero;
            var logicTree = _turnController.CoroutineTrees.MainLogicTree;
            
            currentActiveHero.HeroStatusEffects.UpdateStatusEffectCounters.UpdateCountersStartTurn();

            logicTree.EndSequence();
            yield return null;

        }


    }
}
