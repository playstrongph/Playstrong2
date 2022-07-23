using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.AttackTargetCountTypeAssets;
using ScriptableObjectScripts.GameAnimationAssets;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "CounterAttackAction", menuName = "Assets/BasicActions/C/CounterAttackAction")]
    public class CounterAttackActionAsset : BasicActionAsset
    {

        #region VARIABLES

        private int successChance = 0;

        #endregion

        #region EXECUTION


        /// <summary>
        /// Calls the basic action's specific effects
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            //Counter Attacker: Caster hero
            //Counter Target: TargetHero
            
            CounterAttackHero(targetHero,casterHero);

            logicTree.EndSequence();
            yield return null;
        }
        

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
            
            if (successChance > 0)
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
        public override IEnumerator CallPreBasicActionEvents(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //Calculate the counter attack success chance
            ChanceSuccess(casterHero, targetHero);

            if (successChance > 0)
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
        public override IEnumerator CallPostBasicActionEvents(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            if (successChance > 0)
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

            successChance = randomChance <= netCounterChance ? 100 : 0;
        }


        #endregion

    }
}
