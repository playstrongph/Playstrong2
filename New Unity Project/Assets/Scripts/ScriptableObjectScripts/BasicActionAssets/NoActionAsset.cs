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
        /// <param name="hero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            Debug.Log("No Action Caster Hero:" +hero.HeroName);

            logicTree.EndSequence();
            yield return null;
        }
    }
}
