using System.Collections;
using UnityEngine;

namespace Logic
{
    public class HeroEndTurn : MonoBehaviour, IHeroEndTurn
    {
        
        private ITurnController _turnController;

        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
        }
        
        /// <summary>
        /// Call hero end turn subscribers, set current hero inactive, remove active hero
        /// visuals
        /// </summary>
        /// <returns></returns>
        public IEnumerator StartAction()
        {
            var logicTree = _turnController.CoroutineTrees.MainLogicTree;

            //TODO: Visual Delay in Seconds
            
            //TODO: EventHeroEndTurn

            //Delay allows to cleanup the Heroes Turn Queue for dead heroes
            logicTree.AddSibling(_turnController.AfterHeroEndTurn.StartAction());

            logicTree.EndSequence();
            yield return null;
        }

        





    }
}
