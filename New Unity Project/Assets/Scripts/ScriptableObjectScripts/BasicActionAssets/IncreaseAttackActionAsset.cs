using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    public class IncreaseAttackActionAsset : BasicActionAsset
    {   
        /// <summary>
        /// Increase value by a fixed amount
        /// </summary>
        [SerializeField] private int flatValue = 0;
        
        /// <summary>
        /// Increase value by a percentage attack amount
        /// </summary>
        [SerializeField] private int percentValue = 0;

        //TODO: CalculatedValue
        
        /// <summary>
        /// change in attribute value - used by execute and undo execute action
        /// </summary>
        private int _changeValue = 0;
        
        /// <summary>
        /// Increase attack logic execution
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;

            var baseValue = hero.HeroLogic.HeroAttributes.BaseAttack;
            
            //Compute change in attack value
            _changeValue = Mathf.RoundToInt(baseValue * percentValue / 100f) + flatValue;

            var newAttackValue = hero.HeroLogic.HeroAttributes.Attack + _changeValue;
            
            //Set the new attack value in hero attributes
            hero.HeroLogic.SetAttack.StartAction(newAttackValue);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoExecuteAction(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            var visualTree = hero.CoroutineTrees.MainVisualTree;

            //Use the change value set in execute action earlier
            var newAttackValue = hero.HeroLogic.HeroAttributes.Attack - _changeValue;
            
            //Set the new attack value in hero attributes
            hero.HeroLogic.SetAttack.StartAction(newAttackValue);
            
            //Update the attack text with no animation
            visualTree.AddCurrent(SetAttackVisual(hero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Text Update Animation
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public override IEnumerator MainAnimationAction(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        
        
        
        /// <summary>
        /// Updates the attack "text" in game
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        private IEnumerator SetAttackVisual(IHero hero)
        {
            var visualTree = hero.CoroutineTrees.MainVisualTree;
            
            hero.HeroVisual.SetAttackVisual.StartAction();
            
            visualTree.EndSequence();
            yield return null;
        }



    }
}
