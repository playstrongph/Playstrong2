using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    
    [CreateAssetMenu(fileName = "IncreaseDealMultipleDamageReduction", menuName = "Assets/BasicActions/I/IncreaseDealMultipleDamageReduction")]
    public class IncreaseDealMultipleDamageReductionAsset : BasicActionAsset
    {
        /// <summary>
        /// Value of damage reduction
        /// </summary>
        [SerializeField] private int value = 0;
        
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
            logicTree.AddCurrent(MainAction(targetHero));

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            var damageAttributes = targetHero.HeroLogic.DamageAttributes;

            damageAttributes.MultiDealDamageReduction += value;

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoExecuteAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            var damageAttributes = targetHero.HeroLogic.DamageAttributes;

            damageAttributes.MultiDealDamageReduction -= value;

            logicTree.EndSequence();
            yield return null;
        }


    }
}
