using System.Collections;
using UnityEngine;

namespace Logic
{
    public class BeforeHeroStartTurn : MonoBehaviour
    {
        private ITurnController _turnController;

        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
        }

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
        /// Called when hero has no turn inability
        /// </summary>
        public void StartHeroTurn()
        {
            //TODO: StartHeroTurn IEnumerator
        }

        private void CheckHeroInability()
        {
            
        }
    }
}
