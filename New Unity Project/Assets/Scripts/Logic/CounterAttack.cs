using System.Collections;
using UnityEngine;

namespace Logic
{
    
    public class CounterAttack : MonoBehaviour
    {

        #region VARIABLES

        private int _successChance = 0;

        #endregion

        #region EXECUTION

        /// <summary>
        /// Counter attack target hero using basic skill
        /// </summary>
        /// <param name="counterTarget"></param>
        ///  <param name="counterAttacker"></param>
        private void CounterAttackHero(IHero counterTarget,IHero counterAttacker)
        {
            var logicTree = counterTarget.CoroutineTrees.MainLogicTree;

            //prevents counterAttack of a counterAttack
            var temporaryResistance = 1000;
            
            if (_successChance > 0)
            {
                //Prevent counterattack of a counterattack
                logicTree.AddCurrent(ChanceCounterResistance(counterAttacker,temporaryResistance));
            
                //Counter Attack Action
                logicTree.AddCurrent(CounterAction(counterTarget,counterAttacker));
            
                //Return counterattack resistance to normal
                logicTree.AddCurrent(ChanceCounterResistance(counterAttacker,-temporaryResistance));
            }
        }
        
        /// <summary>
        /// Change the counter attack resistance
        /// </summary>
        /// <param name="counterAttacker"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private IEnumerator ChanceCounterResistance(IHero counterAttacker, int value)
        {
            var logicTree = counterAttacker.CoroutineTrees.MainLogicTree;
            var temporaryResistance = value;

            counterAttacker.HeroLogic.ResistanceAttributes.CounterAttackResistance += temporaryResistance;

            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Counter attack with basic skill
        /// </summary>
        /// <param name="counterTarget"></param>
        /// <param name="counterAttacker"></param>
        /// <returns></returns>
        private IEnumerator CounterAction(IHero counterTarget, IHero counterAttacker)
        {
            var logicTree = counterAttacker.CoroutineTrees.MainLogicTree;
            
            //The hero basic skill is always the first skill
            var heroBasicSKill = counterAttacker.HeroSkills.AllSkills[0];

            var standardActions = heroBasicSKill.SkillLogic.SkillEffect.StandardActions;

            foreach (var standardAction in standardActions)
            {
                standardAction.StartAction(counterAttacker,counterTarget);
            }

            logicTree.EndSequence();
            yield return null;
        }

        #endregion

        #region ANIMATION
        
      
      

        #endregion

        #region EVENTS
        
        /// <summary>
        /// All events before main basic action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public IEnumerator CallPreBasicActionEvents(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //Calculate the counter attack success chance
            ChanceSuccess(casterHero, targetHero);

            if (_successChance > 0)
            {
                //casterHero is the counter attacker
                casterHero.HeroLogic.HeroEvents.EventBeforeHeroCounterAttacks(casterHero,targetHero);

                //targetHero is the one being counter attacked (attacker)
                targetHero.HeroLogic.HeroEvents.EventBeforeHeroIsCounterAttacked(targetHero,casterHero);     
            }

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// All events after main basic action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public IEnumerator CallPostBasicActionEvents(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            if (_successChance > 0)
            {
                //casterHero is the counter attacker
                casterHero.HeroLogic.HeroEvents.EventAfterHeroCounterAttacks(casterHero,targetHero);

                //targetHero is the one being counter attacked (attacker)
                targetHero.HeroLogic.HeroEvents.EventAfterHeroIsCounterAttacked(targetHero,casterHero);    
            }
            
            logicTree.EndSequence();
            yield return null;
        }


        private void ChanceSuccess(IHero counterAttacker,IHero counterTarget)
        {
            //The caster hero is the target of the counter attack
            var counterChance = counterAttacker.HeroLogic.ChanceAttributes.CounterAttackChance;
            var counterResistance = counterTarget.HeroLogic.ResistanceAttributes.CounterAttackResistance;
            var netCounterChance = counterChance - counterResistance;
            var randomChance = Random.Range(1, 101);

            _successChance = randomChance <= netCounterChance ? 100 : 0;
        }


        #endregion

    }
}
