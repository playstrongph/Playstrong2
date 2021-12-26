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
            //var currentActiveHero = _turnController.CurrentActiveHero;
            
            //TODO: Visual Delay in Seconds
            
            //TODO: EventHeroEndTurn
            
            //Set hero status to Inactive - Transferred to AfterHeroEndTurn
            //currentActiveHero.HeroLogic.SetHeroActiveStatus.InactiveHero();
            
            //Hide green border, portrait, and skills - Transferred to AfterHeroEndTurn
            //currentActiveHero.HeroLogic.HeroActiveStatus.StatusAction(currentActiveHero);

            //Call AfterHeroEndTurn PHASE
            logicTree.AddCurrent(_turnController.AfterHeroEndTurn.StartAction());
            
           
            logicTree.EndSequence();
            yield return null;
        }

        





    }
}
