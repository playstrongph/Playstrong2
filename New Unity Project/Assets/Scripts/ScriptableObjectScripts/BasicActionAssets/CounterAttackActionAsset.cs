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
            
            CounterAttackHero(casterHero,targetHero);

            logicTree.EndSequence();
            yield return null;
        }
        

        /// <summary>
        /// Counter attack target hero using basic skill
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        private void CounterAttackHero(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //Note: the casterHero in the args is the Attacker, and the targetHero is the counterAttacker

            //The target hero is the counter attacker
            var counterChance = targetHero.HeroLogic.ChanceAttributes.CounterAttackChance;
            
            //The caster hero is the target of the counter attack
            var counterResistance = casterHero.HeroLogic.ResistanceAttributes.CounterAttackResistance;
            var netCounterChance = counterChance - counterResistance;
            var randomChance = Random.Range(1f, 101f);
            var temporaryResistance = 1000;
            
                     

            if (randomChance <= netCounterChance)
            {
                //TODO: CounterAttack Chance and Resistance Checking (void)
            
                //If counter chance true
                //TODO: Temporary Increase of counterAttacker counter attack resistance (IEnumerator)
                logicTree.AddCurrent(ChanceCounterResistance(targetHero,temporaryResistance));
            
                //Counter Attack Action
                logicTree.AddCurrent(CounterAction(casterHero,targetHero));
            
                //TODO: Remove Temporary Increase of counterAttacker counter attack resistance (IEnumerator)
                logicTree.AddCurrent(ChanceCounterResistance(targetHero,-temporaryResistance));
            }
        }

        private IEnumerator ChanceCounterResistance(IHero counterAttacker, int value)
        {
            var logicTree = counterAttacker.CoroutineTrees.MainLogicTree;
            var temporaryResistance = value;

            counterAttacker.HeroLogic.ResistanceAttributes.CounterAttackResistance += temporaryResistance;
            
            Debug.Log("CounterAttacker Resistance: " +counterAttacker.HeroLogic.ResistanceAttributes.CounterAttackResistance);

            logicTree.EndSequence();
            yield return null;
        }





        private IEnumerator CounterAction(IHero attacker, IHero counterAttacker)
        {
            var logicTree = counterAttacker.CoroutineTrees.MainLogicTree;
            
            //The hero basic skill is always the first skill
            var heroBasicSKill = counterAttacker.HeroSkills.AllSkills[0];

            var standardActions = heroBasicSKill.SkillLogic.SkillEffect.StandardActions;

            foreach (var standardAction in standardActions)
            {
                standardAction.StartAction(counterAttacker,attacker);
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
            
            //TODO: Create Pre-CounterAttack events

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
            
            //TODO: Create Post-CounterAttack events

            logicTree.EndSequence();
            yield return null;
        }
        
       
        #endregion

    }
}
