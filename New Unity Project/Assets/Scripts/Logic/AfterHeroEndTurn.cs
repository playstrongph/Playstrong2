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
            

            //Updates and executes the hero active status and action
            logicTree.AddCurrent(UpdateHeroActiveStatus());
            
            //Reduce All Hero Skills Cooldown by 1
            logicTree.AddCurrent(ReduceAllSkillsCooldown());
            
            //Reduce all "start turn counter update" status effect counters
            logicTree.AddCurrent(UpdateStatusEffects());
        
            //Call after hero end turn event 
            logicTree.AddCurrent(EventAfterHeroEndTurn());
            
            //Turn controller end combat turn
            logicTree.AddCurrent(EventEndCombatTurn());

            //Determines the next active hero from the active heroes list 
            logicTree.AddCurrent(_turnController.StartNextHeroTurn.StartAction());
            
            logicTree.EndSequence();
            yield return null;
            
        }
        
        /// <summary>
        /// Updates the hero active status and executes the status action
        /// </summary>
        /// <returns></returns>
        private IEnumerator UpdateHeroActiveStatus()
        {
            var logicTree = _turnController.CoroutineTrees.MainLogicTree;
            var currentActiveHero = _turnController.CurrentActiveHero;
            
            //Set hero status to Inactive
            currentActiveHero.HeroLogic.SetHeroActiveStatus.InactiveHero();
            
            //Hide green border, portrait, and skills
            currentActiveHero.HeroLogic.HeroActiveStatus.StatusAction(currentActiveHero);
            
            logicTree.EndSequence();
            yield return null;
        }


        /// <summary>
        /// Normal end turn all hero skill cooldown reduction by 1  
        /// </summary>
        private IEnumerator ReduceAllSkillsCooldown()
        {
            var logicTree = _turnController.CoroutineTrees.MainLogicTree;
            var currentActiveHero = _turnController.CurrentActiveHero;
            var allSkills = currentActiveHero.HeroSkills.AllSkills;

            foreach (var skill in allSkills)
            {
                skill.SkillLogic.UpdateSkillCooldown.TurnControllerReduceCooldown();
            }
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Reduce all "start turn counter update" status effect counters
        /// </summary>
        /// <returns></returns>
        private IEnumerator UpdateStatusEffects()
        {
            var currentActiveHero = _turnController.CurrentActiveHero;
            var logicTree = _turnController.CoroutineTrees.MainLogicTree;
            
            currentActiveHero.HeroStatusEffects.UpdateStatusEffectCounters.UpdateCountersEndTurn();

            logicTree.EndSequence();
            yield return null;

        }
        
        /// <summary>
        /// Call after hero end turn event
        /// </summary>
        /// <returns></returns>
        private IEnumerator EventAfterHeroEndTurn()
        {
            var currentActiveHero = _turnController.CurrentActiveHero;
            var logicTree = _turnController.CoroutineTrees.MainLogicTree;
            
            currentActiveHero.HeroLogic.HeroEvents.EventAfterHeroEndTurn(currentActiveHero);

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// End of combat turn event
        /// </summary>
        /// <returns></returns>
        private IEnumerator EventEndCombatTurn()
        {
            var logicTree = _turnController.CoroutineTrees.MainLogicTree;
            
            _turnController.TurnControllerEvents.EventEndCombatTurn();

            logicTree.EndSequence();
            yield return null;
        }







    }
}
