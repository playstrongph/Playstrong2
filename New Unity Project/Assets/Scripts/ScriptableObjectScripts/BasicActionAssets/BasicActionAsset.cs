using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    public abstract class BasicActionAsset : ScriptableObject, IBasicActionAsset
    {
        
        /// <summary>
        /// Basic action reference to its respective status effect
        /// </summary>
        public IStatusEffect StatusEffectReference { get; set; }


        //These are the heroes used in the main execution action logic and visual
        public List<IHero> ExecuteActionTargetHeroes { get; private set; } = new List<IHero>();

        /// <summary>
       /// Checks for the validity of the conditions and targets before running the
       /// pre-events, main execution, and post-events
       /// </summary>
       /// <param name="casterHero"></param>
       /// <param name="targetHero"></param>
       /// <param name="standardAction"></param>
       /// <returns></returns>
        public virtual IEnumerator StartAction(IHero casterHero, IHero targetHero, IStandardActionAsset standardAction)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //Sets the main action target heroes.  "Void" used here to ensure heroes are set
            //before basic actions are called
            SetMainExecutionActionTargetHeroes(casterHero, targetHero, standardAction);
            
            //Caster Pre Action Animation
            logicTree.AddCurrent(PreActionAnimation(casterHero));
            
            //Run all pre-event actions when conditions and targets are valid
            logicTree.AddCurrent(PreBasicActionPhase(casterHero, targetHero, standardAction));

            //Run all main actions when conditions and targets are valid
            logicTree.AddCurrent(MainBasicActionPhase(casterHero, targetHero));
            
            ////Run all post-event actions when conditions and targets are valid
            logicTree.AddCurrent(PostBasicActionPhase(casterHero, targetHero, standardAction));

            logicTree.EndSequence();
            yield return null;
        }

        protected virtual IEnumerator PreActionAnimation(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Sets the valid action targets for main basic action.
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="standardAction"></param>
        /// <returns></returns>
        protected virtual void SetMainExecutionActionTargetHeroes(IHero casterHero, IHero targetHero,  IStandardActionAsset standardAction)
        {
            //From the perspective of the caster hero
            var actionTargetHeroes = standardAction.BasicActionTargets.GetActionHeroes(casterHero,targetHero,standardAction);
            
            //animation target heroes list 
            ExecuteActionTargetHeroes.Clear();

            //TEST START
            for (var index = 0; index < actionTargetHeroes.Count; index++)
            {
                var conditionTargetHeroes = standardAction.BasicConditionTargets.GetActionHeroes(casterHero,targetHero,standardAction);
                
                //Use index 0 if basic condition targets does not follow a multiple basic action targets scenario
                var conditionIndex = conditionTargetHeroes.Count < actionTargetHeroes.Count ? 0 : index;
                
                //This is effectively the actual "target hero" 
                var actionTargetHero = actionTargetHeroes[index];

                //Product of all 'And' and 'Or' basic condition logic
                if (FinalConditionValue(conditionTargetHeroes[conditionIndex],standardAction) > 0)
                {
                    //Add only living heroes (only) to the MainExecutionActionHeroes list
                    actionTargetHero.HeroLogic.HeroLifeStatus.AddToHeroList(ExecuteActionTargetHeroes,actionTargetHero);
                }
            }
        }

        /// <summary>
        /// Leads to "BasicAction.CallPreBasicActionEvents" when both caster and target hero are confirmed alive.
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        /// <param name="standardAction"></param>
        private IEnumerator PreBasicActionPhase(IHero casterHero, IHero targetHero,  IStandardActionAsset standardAction)
        {
            //These are the basic action target heroes - thisHero,targetHero, allEnemies, etc.
            var actionTargetHeroes = standardAction.BasicActionTargets.GetActionHeroes(casterHero,targetHero,standardAction);
            
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            for (var index = 0; index < actionTargetHeroes.Count; index++)
            {
                
                var conditionTargetHeroes = standardAction.BasicConditionTargets.GetActionHeroes(casterHero,targetHero,standardAction);

                //Use index 0 if basic condition targets does not follow a multiple basic action targets scenario
                var conditionIndex = conditionTargetHeroes.Count < actionTargetHeroes.Count ? 0 : index;
                
                //This is effectively the actual "target hero" 
                var actionTargetHero = actionTargetHeroes[index];

                //Product of all 'And' and 'Or' basic condition logic
                if (FinalConditionValue(conditionTargetHeroes[conditionIndex],standardAction) > 0)
                {
                    logicTree.AddCurrent(CallPreBasicActionEvents(casterHero,actionTargetHero));
                }
            }
            
            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// All events before main basic action.  Overriden by specific basic action.
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public virtual IEnumerator CallPreBasicActionEvents(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //No action for status effects and other skills
            
            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Overriden by the specific basic action (e.g. AttackAction).  
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        protected virtual IEnumerator MainBasicActionPhase(IHero casterHero, IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            //base class method that calls execute action after checking life status and inability status
            logicTree.AddCurrent(MainAction(casterHero));

            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        ///  Leads to "BasicAction.CallPostBasicActionEvents" when both caster and target hero are confirmed alive.
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="standardAction"></param>
        /// <returns></returns>
        private IEnumerator PostBasicActionPhase(IHero casterHero, IHero targetHero, IStandardActionAsset standardAction)
        {
            var actionTargetHeroes = standardAction.BasicActionTargets.GetActionHeroes(casterHero,targetHero,standardAction);
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            for (var index = 0; index < actionTargetHeroes.Count; index++)
            {
                //These are the basic condition target heroes - thisHero,targetHero, allEnemies, etc.
                var conditionTargetHeroes = standardAction.BasicConditionTargets.GetActionHeroes(casterHero,targetHero,standardAction);
                
                //Use index 0 if basic condition targets does not follow a multiple basic action targets scenario
                var conditionIndex = conditionTargetHeroes.Count < actionTargetHeroes.Count ? 0 : index;
                
                //This is effectively the actual "target hero"
                var actionTargetHero = actionTargetHeroes[index];

                //Product of all 'And' and 'Or' basic condition logic
                if (FinalConditionValue(conditionTargetHeroes[conditionIndex],standardAction) > 0)
                {
                    logicTree.AddCurrent(CallPostBasicActionEvents(casterHero,actionTargetHero));
                }
            }
            
            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// All events before main basic action.  Overriden by specific basic action.
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public virtual IEnumerator CallPostBasicActionEvents(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //No action for status effects and other skills
            
            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Executes the basic action logic, used by hero life status
        /// This is the method overriden by the specific basic actions
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public virtual IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Undoes the effect of execute action, mostly
        /// used in status effects
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        /// <returns></returns>
        public virtual IEnumerator UndoExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Basic action animation
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public virtual IEnumerator MainAnimation(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Calls Execute action if: 1) caster and target hero are alive
        /// 2) caster has no inability effects
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        protected virtual IEnumerator MainAction(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            foreach (var actionTargetHero in ExecuteActionTargetHeroes)
            {
                logicTree.AddCurrent(ExecuteAction(casterHero,actionTargetHero));
            }
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Shuffle status effects list
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        protected List<IStatusEffect> ShuffleStatusEffectsList(List<IStatusEffect> list)
        {
            //Randomize the List
            for (var i = 0; i < list.Count; i++) 
            {
                var temp = list[i];
                var randomIndex = Random.Range(i, list.Count);
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }
            return list;
        }



        #region FINAL CONDITION LOGIC

        /// <summary>
        /// AllAndBasicConditionsValue accumulator
        /// </summary>
        private int _finalAndConditionsValue;
        
        /// <summary>
        /// AllAndBasicConditionsValue accumulator
        /// </summary>
        private int _finalOrConditionsValue;

        protected int FinalConditionValue(IHero hero, IStandardActionAsset standardAction)
        {
            var finalCondition = AllAndBasicConditionsValue(hero, standardAction) * AllOrBasicConditionsValue(hero,standardAction);
            return finalCondition;
        }
        
        /// <summary>
        /// Returns the result of multiplying all 'And' conditions
        /// </summary>
        /// <param name="hero"></param>
        ///  /// <param name="standardAction"></param>
        /// <returns></returns>
        private int AllAndBasicConditionsValue(IHero hero, IStandardActionAsset standardAction)
        {
            if (standardAction.AndBasicConditions.Count > 0)
            {
                _finalAndConditionsValue = 1;
                foreach (var basicCondition in standardAction.AndBasicConditions)
                {
                    _finalAndConditionsValue *= basicCondition.ConditionValue(hero);
                    _finalAndConditionsValue = Mathf.Clamp(_finalAndConditionsValue, 0, 1);
                }
            }
            else
                _finalAndConditionsValue = 1; 
            
            return _finalAndConditionsValue;
        }
        
        /// <summary>
        /// Returns the result of multiplying all 'Or' conditions
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="standardAction"></param>
        /// <returns></returns>
        private int AllOrBasicConditionsValue(IHero hero, IStandardActionAsset standardAction)
        {
            if (standardAction.OrBasicConditions.Count > 0)
            {
                _finalOrConditionsValue = 0;
                foreach (var basicCondition in standardAction.OrBasicConditions)
                {
                    _finalOrConditionsValue += basicCondition.ConditionValue(hero);
                    _finalOrConditionsValue = Mathf.Clamp(_finalOrConditionsValue, 0, 1);

                }
            }
            else _finalOrConditionsValue =  1;

            return _finalOrConditionsValue;
        }

        #endregion


        #region OLD LOGIC

        
        

        #endregion

     
    }
}
