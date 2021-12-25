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
            var currentActiveHero = _turnController.CurrentActiveHero;
            
            //TODO: Visual Delay in Seconds
            
            //TODO: EVENT - HeroEndTurn
            
            //Set hero status to Inactive
            currentActiveHero.HeroLogic.SetHeroActiveStatus.InactiveHero();
            
            //Hide green border, portrait, and skills
            currentActiveHero.HeroLogic.HeroActiveStatus.StatusAction(currentActiveHero);

            //TODO: StartNextHeroTurn

            logicTree.EndSequence();
            yield return null;
        }
        
        
       

        
    }
}
