﻿using System.Collections;
using UnityEngine;

namespace Logic
{
    public class HeroStartTurn : MonoBehaviour, IHeroStartTurn
    {
        private ITurnController _turnController;

        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
        }
        
        /// <summary>
        /// Update all skills readiness status, calls start hero turn event subscribers, and
        /// executes the action of the hero's current active status
        /// </summary>
        /// <returns></returns>
        public IEnumerator StartAction()
        {
            var logicTree = _turnController.CoroutineTrees.MainLogicTree;
            var currentActiveHero = _turnController.CurrentActiveHero;
            
            //TODO: UpdateSkillReadinessStatus
            
            //TODO: EVENT - EventHeroStartTurn
            
            //Run the current hero active status action
            logicTree.AddCurrent(CurrentActiveStatusAction());

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Executes the action of the hero's current active status
        /// </summary>
        /// <returns></returns>
        private IEnumerator CurrentActiveStatusAction()
        {
            var logicTree = _turnController.CoroutineTrees.MainLogicTree;
            var currentActiveHero = _turnController.CurrentActiveHero;
            
            //Displays green action border, hero portrait, and hero skills
            currentActiveHero.HeroLogic.HeroActiveStatus.StatusAction(currentActiveHero);
            
            logicTree.EndSequence();
            yield return null;
        }
    }
}