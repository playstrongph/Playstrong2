using ScriptableObjectScripts;
using UnityEngine;

namespace JondiBranchLogic
{
    [CreateAssetMenu(fileName = "CoroutineTrees", menuName = "Assets/CoroutineSequenceLogic/CoroutineTrees")]
    public class CoroutineTreesAsset : ScriptableObject, ICoroutineTreesAsset
    {
        public ICoroutineTree MainLogicTree { get; set; }

        public ICoroutineTree MainVisualTree { get; set; }
    }
}
