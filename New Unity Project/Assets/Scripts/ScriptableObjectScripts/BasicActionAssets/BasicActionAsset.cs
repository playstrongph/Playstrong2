using System.Collections;
using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    public abstract class BasicActionAsset : ScriptableObject, IBasicActionAsset
    {
       /// <summary>
       /// Checks for the validity of the conditions and targets before running the
       /// pre-events, main execution, and post-events
       /// </summary>
       /// <param name="hero"></param>
       /// <param name="standardAction"></param>
       /// <returns></returns>
        public virtual IEnumerator StartAction(IHero hero, IStandardActionAsset standardAction)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            //Run all pre-event actions when conditions and targets are valid
            logicTree.AddCurrent(PreExecuteAction(hero, standardAction));
            
            //Run all main actions when conditions and targets are valid
            logicTree.AddCurrent(MainExecuteAction(hero, standardAction));
            
            ////Run all post-event actions when conditions and targets are valid
            logicTree.AddCurrent(PostExecuteAction(hero, standardAction));
            
            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Run all the pre-action events 
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="standardAction"></param>
        private IEnumerator PreExecuteAction(IHero hero,  IStandardActionAsset standardAction)
        {
            var actionTargetHeroes = standardAction.BasicActionTargets.ActionTargets(hero);
            var logicTree = hero.CoroutineTrees.MainLogicTree;

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
                    //Target action calls pre execute action if both the caster and target are alive
                    newTargetHero.HeroLogic.HeroLifeStatus.TargetPreExecutionAction(this,newTargetHero);
                }
            }
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Run all the Main Execute Actions
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="standardAction"></param>
        private IEnumerator MainExecuteAction(IHero hero,  IStandardActionAsset standardAction)
        {
            var actionTargetHeroes = standardAction.BasicActionTargets.ActionTargets(hero);
            var logicTree = hero.CoroutineTrees.MainLogicTree;

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
                    newTargetHero.HeroLogic.HeroLifeStatus.TargetMainExecutionAction(this,newTargetHero);
                }
            }
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Run all the post-action events 
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="standardAction"></param>
        private IEnumerator PostExecuteAction(IHero hero,  IStandardActionAsset standardAction)
        {
            var actionTargetHeroes = standardAction.BasicActionTargets.ActionTargets(hero);
            var logicTree = hero.CoroutineTrees.MainLogicTree;

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
                    //Target action calls pre execute action if both the caster and target are alive
                    newTargetHero.HeroLogic.HeroLifeStatus.TargetPostExecutionAction(this,newTargetHero);
                }
            }
            
            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Executes the basic action logic, used by hero life status
        /// This is the method overriden by the specific basic actions
        /// </summary>
        /// <param name="hero"></param>
        public virtual IEnumerator ExecuteAction(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Undoes the effect of execute action, mostly
        /// used in status effects
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public virtual IEnumerator UndoExecuteAction(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            logicTree.EndSequence();
            yield return null;
        }

        
        /// <summary>
        /// All events before Execute Action
        /// </summary>
        /// <param name="hero"></param>
        public virtual IEnumerator PreExecuteActionEvents(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// All events after Execute Action
        /// </summary>
        /// <param name="hero"></param>
        public virtual IEnumerator PostExecuteActionEvents(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            logicTree.EndSequence();
            yield return null;
        }

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
