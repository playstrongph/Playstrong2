using System.Collections;
using UnityEngine;

namespace Logic
{
    public class HeroStartTurn : MonoBehaviour
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
            
            //TODO: UpdateSkillReadinessStatus
            
            //TODO: EVENT - EventHeroStartTurn
            
            //TODO: UpdateHeroActionPhase
           

            logicTree.EndSequence();
            yield return null;
        }
    }
}
