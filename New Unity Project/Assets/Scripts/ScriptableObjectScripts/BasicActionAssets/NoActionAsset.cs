using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "NoAction", menuName = "Assets/BasicActions/NoAction")]
    public class NoActionAsset : BasicActionAsset
    {
        /// <summary>
        /// Hero performs no action
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            logicTree.EndSequence();
            yield return null;
        }
    }
}
