using System.Collections;
using UnityEngine;

namespace Logic
{
    public class AfterHeroEndTurn : MonoBehaviour, IAfterHeroEndTurn
    {
        private ITurnController _turnController;

        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
        }
        
        /// <summary>
        /// Update all skills cooldown, call after hero end turn event, call after combat event, update status effects,
        /// and call next phase - start next active hero 
        /// </summary>
        /// <returns></returns>
        public IEnumerator StartAction()
        {
            var logicTree = _turnController.CoroutineTrees.MainLogicTree;
            var currentActiveHero = _turnController.CurrentActiveHero;

            //Set hero status to Inactive
            currentActiveHero.HeroLogic.SetHeroActiveStatus.InactiveHero();
            
            //Hide green border, portrait, and skills
            currentActiveHero.HeroLogic.HeroActiveStatus.StatusAction(currentActiveHero);
            
            //Reduce All Hero Skills Cooldown by 1
            ReduceAllSkillsCooldown();
            
            //TODO - UpdateEndTurnStatusEffects
        
            //TODO - EventAfterHeroEndTurn
        
            //TODO - EventAfterCombatTurn

            //Determines the next active hero from the active heroes list 
            logicTree.AddCurrent(_turnController.StartNextHeroTurn.StartAction());
            
            logicTree.EndSequence();
            yield return null;
            
        }
        
        /// <summary>
        /// Normal end turn all hero skill cooldown reduction by 1  
        /// </summary>
        private void ReduceAllSkillsCooldown()
        {
            var currentActiveHero = _turnController.CurrentActiveHero;
            var allSkills = currentActiveHero.HeroSkills.AllSkills;

            foreach (var skill in allSkills)
            {
                skill.SkillLogic.UpdateSkillCooldown.TurnControllerReduceCooldown();
            }

        }







    }
}
