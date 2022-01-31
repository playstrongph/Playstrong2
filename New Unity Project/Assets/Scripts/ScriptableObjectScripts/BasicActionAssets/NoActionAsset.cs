using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "NoAction", menuName = "Assets/BasicActions/N/NoAction")]
    public class NoActionAsset : BasicActionAsset
    {
        /// <summary>
        /// Hero performs no action
        /// </summary>
        /// <param name="targetedHero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero targetedHero)
        {
            var logicTree = targetedHero.CoroutineTrees.MainLogicTree;
            
            Debug.Log("No Action Caster Hero:" +targetedHero.HeroName);

            logicTree.EndSequence();
            yield return null;
        }
    }
}
