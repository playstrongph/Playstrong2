using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "IncreaseSpeedAction", menuName = "Assets/BasicActions/I/IncreaseSpeedAction")]
    public class IncreaseSpeedActionAsset : BasicActionAsset
    {
        /// <summary>
        /// Increase value by a fixed amount
        /// </summary>
        [SerializeField] private int flatValue = 0;
        
        /// <summary>
        /// Increase value by a percentage speed amount
        /// </summary>
        [SerializeField] private int percentValue = 0;
        
        //TODO: CalculatedValue
        
        /// <summary>
        /// change in attribute value - used by execute and undo execute action
        /// </summary>
        private int _changeValue = 0;
        
        /// <summary>
        /// Increase speed logic execution
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;

            var baseValue = hero.HeroLogic.HeroAttributes.BaseSpeed;
            
            //Compute change in attack value
            _changeValue = Mathf.RoundToInt(baseValue * percentValue / 100f) + flatValue;

            var newValue = hero.HeroLogic.HeroAttributes.Speed + _changeValue;
            
            //Set the new attack value in hero attributes
            hero.HeroLogic.SetSpeed.StartAction(newValue);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoExecuteAction(IHero targetedHero)
        {
            var logicTree = targetedHero.CoroutineTrees.MainLogicTree;
            var visualTree = targetedHero.CoroutineTrees.MainVisualTree;

            var newValue = targetedHero.HeroLogic.HeroAttributes.Speed - _changeValue;
            
            //Set the new attack value in hero attributes
            targetedHero.HeroLogic.SetSpeed.StartAction(newValue);
            
            //Update the energy bar and text color
            visualTree.AddCurrent(SetSpeedVisual(targetedHero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Text Update Animation
        /// </summary>
        /// <param name="targetedHero"></param>
        /// <returns></returns>
        public override IEnumerator MainAnimation(IHero targetedHero)
        {
            var logicTree = targetedHero.CoroutineTrees.MainLogicTree;
            var visualTree = targetedHero.CoroutineTrees.MainVisualTree;
            
            //Update the energy bar and text color
            visualTree.AddCurrent(SetSpeedVisual(targetedHero));

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Update the energy speed and text value 
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        private IEnumerator SetSpeedVisual(IHero hero)
        {
            var visualTree = hero.CoroutineTrees.MainVisualTree;
            
            hero.HeroVisual.SetSpeedVisual.StartAction();

            visualTree.EndSequence();
            yield return null;
        }
        
        
    }
}
