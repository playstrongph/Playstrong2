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
            logicTree.AddCurrent(PreExecuteAction(casterHero, standardAction));
            
            //Run all main actions when conditions and targets are valid
            logicTree.AddCurrent(MainExecuteAction(casterHero, standardAction));
            
            //Run the animation sequence for each target
            logicTree.AddCurrent(MainAnimationAction(casterHero,standardAction));

            ////Run all post-event actions when conditions and targets are valid
            logicTree.AddCurrent(PostExecuteAction(casterHero, standardAction));
            
            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Run all the standard actions subscribed to the pre-action events before the main execute action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="standardAction"></param>
        private IEnumerator PreExecuteAction(IHero casterHero,  IStandardActionAsset standardAction)
        {
            //These are the basic action target heroes - thisHero,targetHero, allEnemies, etc.
            var actionTargetHeroes = standardAction.BasicActionTargets.ActionTargets(casterHero);
            
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            for (var index = 0; index < actionTargetHeroes.Count; index++)
            {
                //These are the basic condition target heroes - thisHero,targetHero, allEnemies, etc.
                var conditionTargetHeroes = standardAction.BasicConditionTargets.ActionTargets(casterHero);
                
               
                //Use index 0 if basic condition targets does not follow a multiple basic action targets scenario
                var conditionIndex = conditionTargetHeroes.Count < actionTargetHeroes.Count ? 0 : index;
                
                var targetedHero = actionTargetHeroes[index];

                //hero.HeroLogic.LastHeroTargets.SetTargetedHero(newTargetHero);
                
                //Product of all 'And' and 'Or' basic condition logic
                if (FinalConditionValue(conditionTargetHeroes[conditionIndex],standardAction) > 0)
                {
                    //Set targeting hero of the targeted hero    
                    targetedHero.HeroLogic.LastHeroTargets.SetTargetingHero(casterHero);
                    
                    //Target action calls pre execute action if both the caster and target are alive
                    targetedHero.HeroLogic.HeroLifeStatus.TargetPreExecutionAction(this,targetedHero);
                }
            }
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Run all the Main Execute Actions logic only
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="standardAction"></param>
        private IEnumerator MainExecuteAction(IHero casterHero,  IStandardActionAsset standardAction)
        {
            var actionTargetHeroes = standardAction.BasicActionTargets.ActionTargets(casterHero);
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //animation target heroes list 
            _animationTargetHeroes.Clear();
            
            for (var index = 0; index < actionTargetHeroes.Count; index++)
            {
                var conditionTargetHeroes = standardAction.BasicConditionTargets.ActionTargets(casterHero);
                
                //Check if conditionTargetHeroes and actionTargetHeroes are the same
                //If not, use index 0 (meaning there is only 1 condition target)
                var conditionIndex = conditionTargetHeroes.Count < actionTargetHeroes.Count ? 0 : index;
                
                var targetedHero = actionTargetHeroes[index];

                //Product of all 'And' and 'Or' basic condition logic
                if (FinalConditionValue(conditionTargetHeroes[conditionIndex],standardAction) > 0)
                {
                    //Set targeting hero of the targeted hero    
                    targetedHero.HeroLogic.LastHeroTargets.SetTargetingHero(casterHero);
                    
                    //Target action calls execute action if both the caster and target are alive
                    targetedHero.HeroLogic.HeroLifeStatus.TargetMainExecutionAction(this,targetedHero);
                    
                    //TEST - Update animation target heroes list
                    _animationTargetHeroes.Add(targetedHero);
                }
            }
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Play the main execute action animations
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="standardAction"></param>
        private IEnumerator MainAnimationAction(IHero casterHero, IStandardActionAsset standardAction)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //Animation target heroes have already been selected in main execute action
            foreach (var targetHero in (_animationTargetHeroes))
            {
                targetHero.HeroLogic.HeroLifeStatus.TargetMainAnimation(this,targetHero);
            }
            
            //Animation interval delay.  Called here instead inside specific basic action due to parallel animations
            //example - multiple targets for attack, heal, etc.
            
            //TODO: - this is causing errors - re-implement elsewhere
            //logicTree.AddCurrent(AnimationInterval(casterHero,MainAnimationDuration));

            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        ///  Run all the standard actions subscribed to the post-action events before the main execute action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="standardAction"></param>
        /// <returns></returns>
        private IEnumerator PostExecuteAction(IHero casterHero,  IStandardActionAsset standardAction)
        {
            var actionTargetHeroes = standardAction.BasicActionTargets.ActionTargets(casterHero);
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            for (var index = 0; index < actionTargetHeroes.Count; index++)
            {
                var conditionTargetHeroes = standardAction.BasicConditionTargets.ActionTargets(casterHero);
                
                //Check if conditionTargetHeroes and actionTargetHeroes are the same
                //If not, use index 0 (meaning there is only 1 condition target)
                var conditionIndex = conditionTargetHeroes.Count < actionTargetHeroes.Count ? 0 : index;
                
                var targetedHero = actionTargetHeroes[index];

                //Product of all 'And' and 'Or' basic condition logic
                if (FinalConditionValue(conditionTargetHeroes[conditionIndex],standardAction) > 0)
                {
                    //Set targeting hero of the targeted hero    
                    targetedHero.HeroLogic.LastHeroTargets.SetTargetingHero(casterHero);
                    
                    //Target action calls pre execute action if both the caster and target are alive
                    targetedHero.HeroLogic.HeroLifeStatus.TargetPostExecutionAction(this,targetedHero);
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
        public virtual IEnumerator ExecuteAction(IHero casterHero)
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
        /// <returns></returns>
        public virtual IEnumerator MainAnimation(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// All events before Execute Action
        /// </summary>
        /// <param name="casterHero"></param>
        public virtual IEnumerator PreExecuteActionEvents(IHero casterHero)
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
        public virtual IEnumerator PostExecuteActionEvents(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //No action for status effects and other skills
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// logic tree wrapper for animation interval, to ensure correct timing of
        /// visual tree method calls
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        private IEnumerator AnimationInterval(IHero casterHero, float duration)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var visualTree = casterHero.CoroutineTrees.MainVisualTree;
            
            visualTree.AddCurrent(AnimationIntervalVisual(casterHero,duration));
            
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
        
        /*/// <summary>
        /// Checks if the targeted and targeting hero are both alive before
        /// executing the basic action.  Can be overriden to bypass these checks
        /// as required - e.g. resurrect, base stats change
        /// </summary>
        /// <param name="hero"></param>
        public virtual IEnumerator StartAction(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            hero.HeroLogic.HeroLifeStatus.TargetAction(this,hero);
            
            logicTree.EndSequence();
            yield return null;
        }*/
        
        /*/// <summary>
      /// Checks if all conditions are met (basic conditions plus caster and target life status)
      /// before proceeding to execute action 
      /// </summary>
      /// <param name="hero"></param>
      /// <param name="standardAction"></param>
      /// <returns></returns>
      public virtual IEnumerator StartAction(IHero hero, IStandardActionAsset standardAction)
      {
          var logicTree = hero.CoroutineTrees.MainLogicTree;
          var actionTargetHeroes = standardAction.BasicActionTargets.ActionTargets(hero);

          for (var index = 0; index < actionTargetHeroes.Count; index++)
          {
              var conditionTargetHeroes = standardAction.BasicConditionTargets.ActionTargets(hero);
              
              //Check if conditionTargetHeroes and actionTargetHeroes are the same
              //If not, use index 0 (meaning there is only 1 condition target)
              var conditionIndex = conditionTargetHeroes.Count < actionTargetHeroes.Count ? 0 : index;
              
              var newTargetHero = actionTargetHeroes[index];
              
              //Product of all 'And' and 'Or' basic condition logic
              if (FinalConditionValue(conditionTargetHeroes[conditionIndex],standardAction) > 0)
              {
                  //Target action calls execute action if both the caster and target are alive
                  newTargetHero.HeroLogic.HeroLifeStatus.TargetAction(this,newTargetHero);
              }
          }

          logicTree.EndSequence();
          yield return null;
      }*/
        

        #endregion

    }
}
