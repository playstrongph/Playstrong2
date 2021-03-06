using System.Collections;
using Logic;
using ScriptableObjectScripts;
using UnityEngine;

namespace JondiBranchLogic
{
    /// <summary>
    /// Initializes the global visual and logic coroutine trees 
    /// </summary>
    public class BranchLogic : MonoBehaviour, IBranchLogic
    {
        /// <summary>
        /// Local logic coroutine tree variable
        /// </summary>
        private ICoroutineTree _logicTree;
        
        /// <summary>
        /// Local visual coroutine tree variable
        /// </summary>
        private ICoroutineTree _visualTree;
        
        /// <summary>
        ///  Local battle scene manager reference
        /// </summary>
        private IBattleSceneManager _battleSceneManager;
        
        /// <summary>
        /// Local battle scene settings reference
        /// </summary>
        private IBattleSceneSettingsAsset _battleSceneSettings;
        
        //TODO: Can this be transferred to the BattleSceneManager instead?
        private void Awake()
        {
            _battleSceneManager = GetComponent<IBattleSceneManager>();
            _battleSceneSettings = _battleSceneManager.BattleSceneSettings;

            InitializeGlobalCoroutineTrees();
        }
        
        /// <summary>
        /// Visual and Logic trees initialization for global use
        /// </summary>
        public void InitializeGlobalCoroutineTrees()
        {
            InitializeGlobalLogicTree();
            InitializeGlobVisualTree();
        }

        /// <summary>
        /// Initializes the global logic tree
        /// </summary>
        private void InitializeGlobalLogicTree()
        {
            _logicTree = new CoroutineTree();
            _logicTree.CoroutineRunner(this);
            _logicTree.Start();
            _logicTree.AddRoot(LogicTreeMain());
            _battleSceneSettings.CoroutineTreesAsset.MainLogicTree = _logicTree;
        }
        
        /// <summary>
        /// Initializes the global visual tree
        /// </summary>
        private void InitializeGlobVisualTree()
        {
            _visualTree = new CoroutineTree();
            _visualTree.CoroutineRunner(this);
            _visualTree.Start();
            _visualTree.AddRoot(VisualTreeMain());
            _battleSceneSettings.CoroutineTreesAsset.MainVisualTree = _visualTree;
        }
        
        /// <summary>
        /// Empty tree for the root logic tree main
        /// used for initialization purposes
        /// </summary>
        /// <returns></returns>
        private IEnumerator LogicTreeMain()
        {
            _logicTree.EndSequence();
            yield return null;
            
        }
        
        /// <summary>
        /// Empty tree for the root visual tree main
        /// used for initialization purposes
        /// </summary>
        /// <returns></returns>
        private IEnumerator VisualTreeMain()
        {
            _visualTree.EndSequence();
            yield return null;
        }

    }
}
