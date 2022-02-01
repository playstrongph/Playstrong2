using System.Collections;
using Logic;
using ScriptableObjectScripts.GameAnimationAssets;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "IncreaseAttackAction", menuName = "Assets/BasicActions/I/IncreaseAttackAction")]
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


        [Header("ANIMATIONS")]
        [SerializeField]
        [RequireInterfaceAttribute.RequireInterface(typeof(IGameAnimationsAsset))]
        private ScriptableObject heroAttributeAnimationAsset;

        private IGameAnimationsAsset HeroAttributeAnimationAsset
        {
            get => heroAttributeAnimationAsset as IGameAnimationsAsset;
            set => heroAttributeAnimationAsset = value as ScriptableObject;
        }


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
        
        public override IEnumerator UndoExecuteAction(IHero targetedHero)
        {
            var logicTree = targetedHero.CoroutineTrees.MainLogicTree;
            var visualTree = targetedHero.CoroutineTrees.MainVisualTree;

            //Use the change value set in execute action earlier
            var newAttackValue = targetedHero.HeroLogic.HeroAttributes.Attack - _changeValue;
            
            //Set the new attack value in hero attributes
            targetedHero.HeroLogic.SetAttack.StartAction(newAttackValue);
            
            //Update the attack text with no animation
            visualTree.AddCurrent(SetAttackVisual(targetedHero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Text Update Animation
        /// </summary>
        /// <param name="targetedHero"></param>
        /// <returns></returns>
        public override IEnumerator MainAnimationAction(IHero targetedHero)
        {
            var logicTree = targetedHero.CoroutineTrees.MainLogicTree;
            var visualTree = targetedHero.CoroutineTrees.MainVisualTree;
            
            //Update the attack text with no animation
            visualTree.AddCurrent(SetAttackVisual(targetedHero));
            
            //Play text update animation
            visualTree.AddCurrent(BasicActionAnimation(targetedHero));
            
            logicTree.EndSequence();
            yield return null;
        }


        /// <summary>
        /// Updates the attack "text" in game
        /// used separately by undo execute action
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
        
        /// <summary>
        /// Bounce Visual Text animation
        /// </summary>
        /// <param name="targetedHero"></param>
        /// <returns></returns>
        private IEnumerator BasicActionAnimation(IHero targetedHero)
        {
            var visualTree = targetedHero.CoroutineTrees.MainVisualTree;

            //attack text mesh pro GUI
            var attackText = targetedHero.HeroVisual.AttackVisual.Text;
            
            HeroAttributeAnimationAsset.PlayAnimation(attackText);

            visualTree.EndSequence();
            yield return null;
        }



    }
}
