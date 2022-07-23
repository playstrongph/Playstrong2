using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Logic
{
    
    public class CounterAttack : MonoBehaviour, ICounterAttack
    {

        #region VARIABLES

        private int successChance = 0;

        private IHeroLogic heroLogic;

        #endregion

        #region EXECUTION

        private void Awake()
        {
            heroLogic = GetComponent<IHeroLogic>();
        }


        /// <summary>
        /// Counter attack target hero using basic skill
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        public void CounterAttackHero(IHero casterHero,IHero targetHero)
        {
            /*Debug.Log("Counter Attack Hero");
            
            var logicTree = counterTarget.CoroutineTrees.MainLogicTree;

            //prevents counterAttack of a counterAttack
            var temporaryResistance = 1000;
            
            ChanceSuccess(counterAttacker,counterTarget);
            
            Debug.Log("CounterAttacker: " +counterAttacker.HeroName +" counterTarget: " +counterTarget.HeroName);
            
            Debug.Log("Success Chance: " +successChance);
            
            if (successChance > 0)
            {
                logicTree.AddCurrent(PreCounterAttackEvents(counterAttacker,counterTarget));
                
                //Prevent counterattack of a counterattack
                logicTree.AddCurrent(ChanceCounterResistance(counterAttacker,temporaryResistance));
            
                //Counter Attack Action
                logicTree.AddCurrent(CounterAction(counterTarget,counterAttacker));
            
                //Return counterattack resistance to normal
                logicTree.AddCurrent(ChanceCounterResistance(counterAttacker,-temporaryResistance));
                
                logicTree.AddCurrent(PostCounterAttackEvents(counterAttacker,counterTarget));
            }*/
            
            CounterAttackAction(targetHero,casterHero);
        }
        
        private void CounterAttackAction(IHero counterTarget,IHero counterAttacker)
        {
            Debug.Log("Counter Attack Hero");
            
            var logicTree = counterTarget.CoroutineTrees.MainLogicTree;

            //prevents counterAttack of a counterAttack
            var temporaryResistance = 1000;
            
            ChanceSuccess(counterAttacker,counterTarget);
            
            Debug.Log("CounterAttacker: " +counterAttacker.HeroName +" counterTarget: " +counterTarget.HeroName);
            
            Debug.Log("Success Chance: " +successChance);
            
            if (successChance > 0)
            {
                logicTree.AddCurrent(PreCounterAttackEvents(counterAttacker,counterTarget));
                
                //Prevent counterattack of a counterattack
                logicTree.AddCurrent(ChanceCounterResistance(counterAttacker,temporaryResistance));
            
                //Counter Attack Action
                logicTree.AddCurrent(CounterAction(counterTarget,counterAttacker));
            
                //Return counterattack resistance to normal
                logicTree.AddCurrent(ChanceCounterResistance(counterAttacker,-temporaryResistance));
                
                logicTree.AddCurrent(PostCounterAttackEvents(counterAttacker,counterTarget));
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
        private IEnumerator PreCounterAttackEvents(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            //casterHero is the counter attacker
            casterHero.HeroLogic.HeroEvents.EventBeforeHeroCounterAttacks(casterHero,targetHero);

            //targetHero is the one being counter attacked (attacker)
            targetHero.HeroLogic.HeroEvents.EventBeforeHeroIsCounterAttacked(targetHero,casterHero);

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// All events after main basic action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        private IEnumerator PostCounterAttackEvents(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

           //casterHero is the counter attacker
           casterHero.HeroLogic.HeroEvents.EventAfterHeroCounterAttacks(casterHero,targetHero);

           //targetHero is the one being counter attacked (attacker)
           targetHero.HeroLogic.HeroEvents.EventAfterHeroIsCounterAttacked(targetHero,casterHero);  
           
            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Checks if hero counter attacks
        /// </summary>
        /// <param name="counterAttacker"></param>
        /// <param name="counterTarget"></param>
        private void ChanceSuccess(IHero counterAttacker,IHero counterTarget)
        {
            //The caster hero is the target of the counter attack
            var counterChance = counterAttacker.HeroLogic.ChanceAttributes.CounterAttackChance;
            var counterResistance = counterTarget.HeroLogic.ResistanceAttributes.CounterAttackResistance;
            var netCounterChance = counterChance - counterResistance;
            var randomChance = Random.Range(1, 101);

            successChance = randomChance <= netCounterChance ? 100 : 0;
        }


        #endregion

    }
}
