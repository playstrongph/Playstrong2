using System.Collections;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.GameAnimationAssets;
using ScriptableObjectScripts.StandardActionAssets;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "DestroyHpAction", menuName = "Assets/BasicActions/D/DestroyHpAction")]
    public class DestroyHpActionAsset : BasicActionAsset
    {   
        /// <summary>
        /// Increase value by a fixed amount
        /// </summary>
        [SerializeField] private int flatValue = 0;
        
        /// <summary>
        /// Increase value by a percentage attack amount
        /// </summary>
        [SerializeField] private int percentValue = 0;


        /// <summary>
        /// The specific logic-visual sequence for basic action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        protected override IEnumerator MainBasicActionPhase(IHero casterHero, IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            //base class method that calls execute action after checking life status and inability status
            logicTree.AddCurrent(MainAction(casterHero));

            logicTree.EndSequence();
            yield return null;
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

            DestroyHp(targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoExecuteAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            
            //No Undo Execute Action
            

            logicTree.EndSequence();
            yield return null;
        }

        private void DestroyHp(IHero targetHero)
        {
            var baseHealth = targetHero.HeroLogic.HeroAttributes.BaseHealth;
            var currentHealth = targetHero.HeroLogic.HeroAttributes.Health;

            var newBaseHealth = Mathf.Max(0, baseHealth - flatValue - Mathf.RoundToInt(percentValue * baseHealth));

            targetHero.HeroLogic.HeroAttributes.BaseHealth = newBaseHealth;
            
            //set current health equal to base health when base health is lower
            if(targetHero.HeroLogic.HeroAttributes.BaseHealth < currentHealth)
                targetHero.HeroLogic.SetHealth.StartAction(targetHero.HeroLogic.HeroAttributes.BaseHealth);

        }

    }
}
