﻿using System.Collections;
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

            
            
            //The target hero is the counter attacker
            var counterChance = counterAttacker.HeroLogic.ChanceAttributes.CounterAttackChance;
            
            //The caster hero is the target of the counter attack
            var counterResistance = counterTarget.HeroLogic.ResistanceAttributes.CounterAttackResistance;
            var netCounterChance = counterChance - counterResistance;
            var randomChance = Random.Range(1, 101);
            var temporaryResistance = 1000;

            if (randomChance <= netCounterChance)
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
        public override IEnumerator CallPreBasicActionEvents(IHero targetHero,IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            //targetHero is the counter attacker
            targetHero.HeroLogic.HeroEvents.EventBeforeHeroCounterAttacks(targetHero,casterHero);
            
            //Debug.Log("BeforeHeroCounterAttacks.  CounterAttacker:" +targetHero +" CounterTarget: " +casterHero);
            
            //casterHero is the one being counter attacked (attacker)
            casterHero.HeroLogic.HeroEvents.EventBeforeHeroIsCounterAttacked(casterHero,targetHero);

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// All events after main basic action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator CallPostBasicActionEvents(IHero targetHero,IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //targetHero is the counter attacker
            targetHero.HeroLogic.HeroEvents.EventAfterHeroCounterAttacks(targetHero,casterHero);

            //Debug.Log("AfterHeroCounterAttacks.  CounterAttacker:" +targetHero +" CounterTarget: " +casterHero);
            
            //casterHero is the one being counter attacked (attacker)
            casterHero.HeroLogic.HeroEvents.EventAfterHeroIsCounterAttacked(casterHero,targetHero);
            

            logicTree.EndSequence();
            yield return null;
        }
        
       
        #endregion

    }
}
