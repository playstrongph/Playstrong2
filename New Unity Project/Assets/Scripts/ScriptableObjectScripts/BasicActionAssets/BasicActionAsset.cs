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


        /// <summary>
        /// Basic action target heroes
        /// </summary>
        public List<IHero> ExecuteActionTargetHeroes { get; private set; } = new List<IHero>();
        
        /// <summary>
        /// Basic action caster heroes
        /// </summary>
        public List<IHero> ExecuteActionCasterHeroes { get; private set; } = new List<IHero>();

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
            
            //Set the basic action target heroes
            SetMainExecutionActionTargetHeroes(casterHero, targetHero, standardAction);
            
            //Set the basic action caster heroes
            SetMainExecutionActionCasterHeroes(casterHero, targetHero, standardAction);
            
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
                    //Set caster heroes depending on skill/statusEffect action asset
                    standardAction.SetTargetHeroes(actionTargetHero,ExecuteActionTargetHeroes);
                }
            }
        }
        
        /// <summary>
        /// Sets the valid action targets for main basic action.
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="standardAction"></param>
        /// <returns></returns>
        protected virtual void SetMainExecutionActionCasterHeroes(IHero casterHero, IHero targetHero,  IStandardActionAsset standardAction)
        {
            //From the perspective of the caster hero
            var actionCasterHeroes = standardAction.BasicActionCasters.GetActionHeroes(casterHero,targetHero,standardAction);

            //animation target heroes list 
            ExecuteActionCasterHeroes.Clear();

            //TEST START
            for (var index = 0; index < actionCasterHeroes.Count; index++)
            {
                var conditionTargetHeroes = standardAction.BasicConditionTargets.GetActionHeroes(casterHero,targetHero,standardAction);
                
                //Use index 0 if basic condition targets does not follow a multiple basic action targets scenario
                var conditionIndex = conditionTargetHeroes.Count < actionCasterHeroes.Count ? 0 : index;
                
                //This is effectively the actual "target hero" 
                var actionCasterHero = actionCasterHeroes[index];

                //Product of all 'And' and 'Or' basic condition logic
                if (FinalConditionValue(conditionTargetHeroes[conditionIndex],standardAction) > 0)
                {
                    //Set caster heroes depending on skill/statusEffect action asset
                    standardAction.SetCasterHeroes(actionCasterHero,ExecuteActionCasterHeroes);
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
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            foreach (var actionCasterHero in ExecuteActionCasterHeroes)
            {
                foreach (var actionTargetHero in ExecuteActionTargetHeroes)
                {
                    logicTree.AddCurrent(CallPreBasicActionEvents(actionCasterHero,actionTargetHero));
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
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            foreach (var actionCasterHero in ExecuteActionCasterHeroes)
            {
                foreach (var actionTargetHero in ExecuteActionTargetHeroes)
                {
                    logicTree.AddCurrent(CallPostBasicActionEvents(actionCasterHero,actionTargetHero));
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
        /// <param name="hero"></param>
        /// <returns></returns>
        protected virtual IEnumerator MainAction(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;

            foreach (var actionCasterHero in ExecuteActionCasterHeroes)
            {
                foreach (var actionTargetHero in ExecuteActionTargetHeroes)
                {
                    logicTree.AddCurrent(ExecuteAction(actionCasterHero,actionTargetHero));
                }    
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
        private int finalAndConditionsValue;
        
        /// <summary>
        /// AllAndBasicConditionsValue accumulator
        /// </summary>
        private int finalOrConditionsValue;

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
                finalAndConditionsValue = 1;
                foreach (var basicCondition in standardAction.AndBasicConditions)
                {
                    finalAndConditionsValue *= basicCondition.ConditionValue(hero);
                    finalAndConditionsValue = Mathf.Clamp(finalAndConditionsValue, 0, 1);
                }
            }
            else
                finalAndConditionsValue = 1; 
            
            return finalAndConditionsValue;
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
                finalOrConditionsValue = 0;
                foreach (var basicCondition in standardAction.OrBasicConditions)
                {
                    finalOrConditionsValue += basicCondition.ConditionValue(hero);
                    finalOrConditionsValue = Mathf.Clamp(finalOrConditionsValue, 0, 1);

                }
            }
            else finalOrConditionsValue =  1;

            return finalOrConditionsValue;
        }

        #endregion


        #region OLD LOGIC

        
        

        #endregion

     
    }
}
