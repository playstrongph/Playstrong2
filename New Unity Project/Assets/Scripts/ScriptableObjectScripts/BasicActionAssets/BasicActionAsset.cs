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

        #region TEST LOGIC
        
        /// <summary>
        /// Checks if all conditions are met (basic conditions plus caster and target life status)
        /// before proceeding to execute action 
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="standardAction"></param>
        /// <returns></returns>
        public virtual IEnumerator StartAction1(IHero hero, IStandardActionAsset standardAction)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            //TODO: Iterate over hero targets
            //TODO: Check final conditions
            //TODO: Check Hero life status 
            //TODO: Execute Action
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
                    
                    Debug.Log("Start Action 1: " +newTargetHero.HeroName );
                }
            }
            logicTree.EndSequence();
            yield return null;
        }
        
        
        
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

    }
}
