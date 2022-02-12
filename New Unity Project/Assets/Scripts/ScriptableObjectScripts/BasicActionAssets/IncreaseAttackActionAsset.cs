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
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            var baseValue = targetHero.HeroLogic.HeroAttributes.BaseAttack;
            
            //Compute change in attack value
            _changeValue = Mathf.RoundToInt(baseValue * percentValue / 100f) + flatValue;

            var newValue = targetHero.HeroLogic.HeroAttributes.Attack + _changeValue;
            
            //Set the new attack value in hero attributes
            targetHero.HeroLogic.SetAttack.StartAction(newValue);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoExecuteAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            var visualTree = targetHero.CoroutineTrees.MainVisualTree;

            //Use the change value set in execute action earlier
            var newValue = targetHero.HeroLogic.HeroAttributes.Attack - _changeValue;
            
            //Set the new attack value in hero attributes
            targetHero.HeroLogic.SetAttack.StartAction(newValue);
            
            //Update the attack text with no animation
            visualTree.AddCurrent(SetAttackVisual(targetHero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Text Update Animation
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator MainAnimation(IHero casterHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            var visualTree = targetHero.CoroutineTrees.MainVisualTree;

            //Update the attack text with no animation
            visualTree.AddCurrent(SetAttackVisual(targetHero));
            
            //Play text update animation
            visualTree.AddCurrent(BasicActionAnimation(targetHero));
            
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
        /// <param name="targetHero"></param>
        /// <returns></returns>
        private IEnumerator BasicActionAnimation(IHero targetHero)
        {
            var visualTree = targetHero.CoroutineTrees.MainVisualTree;

            //attack text mesh pro GUI
            var attackText = targetHero.HeroVisual.AttackVisual.Text;
            
            HeroAttributeAnimationAsset.PlayAnimation(attackText);

            visualTree.EndSequence();
            yield return null;
        }



    }
}
