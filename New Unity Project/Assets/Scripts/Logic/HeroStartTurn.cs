using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Logic
{
    public class HeroStartTurn : MonoBehaviour, IHeroStartTurn
    {
        private ITurnController _turnController;

        private float visualDelay = 0; 

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
            
            //TODO: UpdateSkillReadinessStatus ?
            
            //TODO: EVENT - EventHeroStartTurn
            
            //TODO: Visual Delay
            logicTree.AddCurrent(ActiveStatusDelay());
            
            //Run the current hero active status action
            logicTree.AddCurrent(CurrentActiveStatusAction());
            
            //Update skill readiness based on skill cooldown
            logicTree.AddCurrent(UpdateAllSkillsReadinessStatus());
            
            //Re-enable end turn button
            logicTree.AddCurrent(EnableEndTurnButton());

            logicTree.EndSequence();
            yield return null;
        }
        
      

     
        /// <summary>
        /// Visual delay for hero start turn
        /// </summary>
        /// <returns></returns>
        private IEnumerator ActiveStatusDelay()
        {
            var logicTree = _turnController.CoroutineTrees.MainLogicTree;
            var visualTree = _turnController.CoroutineTrees.MainVisualTree;
            
            Debug.Log("hero start turn visual delay");
            
            visualTree.AddCurrent(VisualActiveStatusDelay());
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator VisualActiveStatusDelay()
        {
            var visualTree = _turnController.CoroutineTrees.MainVisualTree;

            var sequence = DOTween.Sequence();

            sequence
                .AppendInterval(visualDelay)
                
                //Reset visual delay back to zero (none)
                .AppendCallback(()=> visualDelay = 0)
                
                .AppendCallback(() => visualTree.EndSequence());

            yield return null;
        }
        
        /// <summary>
        /// Sets the visual delay in seconds
        /// </summary>
        /// <param name="value"></param>
        public void SetVisualDelay(float value)
        {
            visualDelay = value;
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
        
        /// <summary>
        /// Re-enables end turn button after hero on turn initializes
        /// </summary>
        /// <returns></returns>
        private IEnumerator EnableEndTurnButton()
        {
            var logicTree = _turnController.CoroutineTrees.MainLogicTree;
            
            _turnController.BattleSceneManager.EndTurnButton.EnableEndTurnButton();
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Updates each skill's readiness status based on skill cooldown
        /// </summary>
        /// <returns></returns>
        private IEnumerator UpdateAllSkillsReadinessStatus()
        {
            var logicTree = _turnController.CoroutineTrees.MainLogicTree;
            var currentActiveHero = _turnController.CurrentActiveHero;
            var allSkills = currentActiveHero.HeroSkills.AllSkills;

            foreach (var skill in allSkills)
            {
                skill.SkillLogic.UpdateSkillCooldown.UpdateSkillReadiness();
            }
            
            logicTree.EndSequence();
            yield return null;
        }
    }
}
