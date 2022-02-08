using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    public abstract class BasicActionAsset : ScriptableObject, IBasicActionAsset
    {
       
        //TEST
        /// <summary>
        /// The duration (seconds) of the main animation
        /// set in the specific basic action
        /// </summary>
        protected float MainAnimationDuration = 0;
        
        //TEST
        private readonly List<IHero> _animationTargetHeroes = new List<IHero>();

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
            
            //Run all pre-event actions when conditions and targets are valid
            logicTree.AddCurrent(PreExecuteAction(casterHero, targetHero, standardAction));
            
            //Run all main actions when conditions and targets are valid
            logicTree.AddCurrent(MainExecuteAction(casterHero, targetHero, standardAction));
            
            //Run the animation sequence for each target.  Target hero is provided by main execute action (animation targets)
            logicTree.AddCurrent(MainAnimationAction(casterHero));

            ////Run all post-event actions when conditions and targets are valid
            logicTree.AddCurrent(PostExecuteAction(casterHero, targetHero, standardAction));
            
            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Run all the standard actions subscribed to the pre-action events before the main execute action
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        /// <param name="standardAction"></param>
        private IEnumerator PreExecuteAction(IHero casterHero, IHero targetHero,  IStandardActionAsset standardAction)
        {
            //These are the basic action target heroes - thisHero,targetHero, allEnemies, etc.
            var actionTargetHeroes = standardAction.BasicActionTargets.GetActionTargets(casterHero,targetHero);
            
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            for (var index = 0; index < actionTargetHeroes.Count; index++)
            {
                //These are the basic condition target heroes - thisHero,targetHero, allEnemies, etc.
                var conditionTargetHeroes = standardAction.BasicConditionTargets.GetActionTargets(casterHero,targetHero);

                //Use index 0 if basic condition targets does not follow a multiple basic action targets scenario
                var conditionIndex = conditionTargetHeroes.Count < actionTargetHeroes.Count ? 0 : index;
                
                //This is effectively the actual "target hero" 
                var actionTargetHero = actionTargetHeroes[index];

                //Product of all 'And' and 'Or' basic condition logic
                if (FinalConditionValue(conditionTargetHeroes[conditionIndex],standardAction) > 0)
                {
                    //Target action calls pre execute action if both the caster and target are alive
                    actionTargetHero.HeroLogic.HeroLifeStatus.TargetPreExecutionAction(this,casterHero,actionTargetHero);
                }
            }
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Run all the Main Execute Actions logic only
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="standardAction"></param>
        private IEnumerator MainExecuteAction(IHero casterHero, IHero targetHero,  IStandardActionAsset standardAction)
        {
            //From the perspective of the caster hero
            var actionTargetHeroes = standardAction.BasicActionTargets.GetActionTargets(casterHero,targetHero);
            
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //animation target heroes list 
            _animationTargetHeroes.Clear();
            
            for (var index = 0; index < actionTargetHeroes.Count; index++)
            {
                var conditionTargetHeroes = standardAction.BasicConditionTargets.GetActionTargets(casterHero,targetHero);
                
                //Use index 0 if basic condition targets does not follow a multiple basic action targets scenario
                var conditionIndex = conditionTargetHeroes.Count < actionTargetHeroes.Count ? 0 : index;
                
                //This is effectively the actual "target hero" 
                var actionTargetHero = actionTargetHeroes[index];

                //Product of all 'And' and 'Or' basic condition logic
                if (FinalConditionValue(conditionTargetHeroes[conditionIndex],standardAction) > 0)
                {
                    //Target action calls execute action if both the caster and target are alive
                    actionTargetHero.HeroLogic.HeroLifeStatus.TargetMainExecutionAction(this,casterHero,actionTargetHero);
                    
                    //Animation target heroes
                    _animationTargetHeroes.Add(actionTargetHero);
                }
            }
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Play the main execute action animations
        /// </summary>
        /// <param name="casterHero"></param>
        private IEnumerator MainAnimationAction(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var visualTree = casterHero.CoroutineTrees.MainVisualTree;

            //Execute animation for each animation target hero
            foreach (var animationTargetHero in _animationTargetHeroes)
            {
                animationTargetHero.HeroLogic.HeroLifeStatus.TargetMainAnimation(this,casterHero,animationTargetHero);
            }
            
            //Animation delay interval
            visualTree.AddCurrent(AnimationIntervalVisual(casterHero,MainAnimationDuration));

            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        ///  Run all the standard actions subscribed to the post-action events before the main execute action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="standardAction"></param>
        /// <returns></returns>
        private IEnumerator PostExecuteAction(IHero casterHero, IHero targetHero, IStandardActionAsset standardAction)
        {
            var actionTargetHeroes = standardAction.BasicActionTargets.GetActionTargets(casterHero,targetHero);
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            for (var index = 0; index < actionTargetHeroes.Count; index++)
            {
                //These are the basic condition target heroes - thisHero,targetHero, allEnemies, etc.
                var conditionTargetHeroes = standardAction.BasicConditionTargets.GetActionTargets(casterHero,targetHero);
                
                //Use index 0 if basic condition targets does not follow a multiple basic action targets scenario
                var conditionIndex = conditionTargetHeroes.Count < actionTargetHeroes.Count ? 0 : index;
                
                //This is effectively the actual "target hero"
                var actionTargetHero = actionTargetHeroes[index];

                //Product of all 'And' and 'Or' basic condition logic
                if (FinalConditionValue(conditionTargetHeroes[conditionIndex],standardAction) > 0)
                {
                    //Target action calls pre execute action if both the caster and target are alive
                    actionTargetHero.HeroLogic.HeroLifeStatus.TargetPostExecutionAction(this,casterHero,actionTargetHero);
                }
            }
            
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
        /// All events before Execute Action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public virtual IEnumerator PreExecuteActionEvents(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //No action for status effects and other skills
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// All events after Execute Action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public virtual IEnumerator PostExecuteActionEvents(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //No action for status effects and other skills
            
            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// The animation duration interval (in seconds) before next animation is played
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        private IEnumerator AnimationIntervalVisual(IHero casterHero, float duration)
        {
            var visualTree = casterHero.CoroutineTrees.MainVisualTree;

            var s = DOTween.Sequence();

            s.AppendInterval(duration)
                .AppendCallback(() =>
                    visualTree.EndSequence()
                );
            
            yield return null;
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

        private int FinalConditionValue(IHero hero, IStandardActionAsset standardAction)
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

        #region SHUFFLE LOGIC
        
        /// <summary>
        /// Returns a random list of heroes
        /// </summary>
        /// <param name="heroList"></param>
        /// <returns></returns>
        protected List<IHero> ShuffleList(List<IHero> heroList)
        {
            var randomList = heroList;
            
            //Randomize the List
            for (int i = 0; i < randomList.Count; i++) 
            {
                var temp = randomList[i];
                int randomIndex = Random.Range(i, randomList.Count);
                randomList[i] = randomList[randomIndex];
                randomList[randomIndex] = temp;
            }

            return randomList;
        }
        
        /// <summary>
        /// Returns a random list of status effects
        /// </summary>
        /// <param name="statusEffectsList"></param>
        /// <returns></returns>
        protected List<IStatusEffect> ShuffleList(List<IStatusEffect> statusEffectsList)
        {
            //Randomize the List
            for (int i = 0; i < statusEffectsList.Count; i++) 
            {
                var temp = statusEffectsList[i];
                int randomIndex = Random.Range(i, statusEffectsList.Count);
                statusEffectsList[i] = statusEffectsList[randomIndex];
                statusEffectsList[randomIndex] = temp;
            }

            return statusEffectsList;
        }
        
        #endregion

        #region OLD LOGIC

        #endregion

    }
}
