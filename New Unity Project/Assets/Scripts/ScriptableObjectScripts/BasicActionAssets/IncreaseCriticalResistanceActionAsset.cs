using System.Collections;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.GameAnimationAssets;
using ScriptableObjectScripts.StandardActionAssets;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "IncreaseCriticalResistanceAction", menuName = "Assets/BasicActions/I/IncreaseCriticalResistanceAction")]
    public class IncreaseCriticalResistanceActionAsset : BasicActionAsset
    {   
       
        /// <summary>
        /// Increase value by a percentage attack amount
        /// </summary>
        [SerializeField] private int criticalResistance = 1000;

        /// <summary>
        /// Increase critical resistance logic execution
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            targetHero.HeroLogic.ResistanceAttributes.CriticalResistance += criticalResistance;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        /// <summary>
        /// Undo execute action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator UndoExecuteAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
           
            targetHero.HeroLogic.ResistanceAttributes.CriticalResistance -= criticalResistance;
            

            logicTree.EndSequence();
            yield return null;
        }

    }
}
