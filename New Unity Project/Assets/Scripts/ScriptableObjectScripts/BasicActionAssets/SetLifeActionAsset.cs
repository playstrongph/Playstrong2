using System.Collections;
using Logic;
using ScriptableObjectScripts.GameAnimationAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "SetLifeAttackAction", menuName = "Assets/BasicActions/S/SetLifeAttackAction")]
    public class SetLifeActionAsset : BasicActionAsset
    {
        /// <summary>
        /// Set life to a fixed amount
        /// </summary>
        [SerializeField] private int flatValue = 1;
        
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
        /// Set health logic
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            //Set the new attack value in hero attributes
            targetHero.HeroLogic.SetHealth.StartAction(flatValue);
            
            //Note: No undo execute action
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// logic wrapper for set health visual
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator MainAnimation(IHero casterHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            var visualTree = targetHero.CoroutineTrees.MainVisualTree;

            //Play text update animation
            visualTree.AddCurrent(BasicActionAnimation(targetHero,flatValue));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Set health visual
        /// </summary>
        /// <param name="targetHero"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private IEnumerator BasicActionAnimation(IHero targetHero,int value)
        {
            var visualTree = targetHero.CoroutineTrees.MainVisualTree;

            //set text value
            targetHero.HeroVisual.SetHealthVisual.StartAction(value);
            
            //text mesh pro GUI
            var healthText = targetHero.HeroVisual.HealthVisual.Text;
            
            HeroAttributeAnimationAsset.PlayAnimation(healthText);
            
            visualTree.EndSequence();
            yield return null;
        }

    }
}
