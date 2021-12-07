using ScriptableObjectScripts;
using UnityEngine;

namespace JondiBranchLogic
{
    [CreateAssetMenu(fileName = "CoroutineTrees", menuName = "Assets/CoroutineSequenceLogic/CoroutineTrees")]
    public class CoroutineTreesAsset : ScriptableObject, ICoroutineTreesAsset
    {
        /// <summary>
        /// Main logic tree used in all coroutine logic sequences
        /// </summary>
        public ICoroutineTree MainLogicTree { get; set; }

        
        /// <summary>
        /// Main logic tree used in all coroutine visual sequences
        /// </summary>
        public ICoroutineTree MainVisualTree { get; set; }
    }
}
