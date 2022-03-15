using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "NoAction", menuName = "Assets/BasicActions/N/NoAction")]
    public class NoActionAsset : BasicActionAsset
    {
        
        /// <summary>
        /// The specific logic-visual sequence for basic action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        protected override IEnumerator MainBasicActionPhase(IHero casterHero, IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Hero performs no action
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param> 
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            Debug.Log("No Action Caster Hero:" +casterHero.HeroName);

            logicTree.EndSequence();
            yield return null;
        }
    }
}
