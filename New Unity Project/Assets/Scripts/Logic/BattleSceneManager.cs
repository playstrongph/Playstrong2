using System;
using JondiBranchLogic;
using ScriptableObjectScripts;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Logic
{
    public class BattleSceneManager : MonoBehaviour, IBattleSceneManager
    {
        
        /// <summary>
        /// Reference to battle scene settings asset
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IBattleSceneSettingsAsset))]
        private Object battleSceneSettings;
        public IBattleSceneSettingsAsset BattleSceneSettings
        {
            get => battleSceneSettings as IBattleSceneSettingsAsset;
            set => battleSceneSettings = value as Object;
        }

            
        /// <summary>
        /// Local variable for BranchLogic
        /// used in initialization of global coroutine trees
        /// </summary>
        private IBranchLogic _branchLogic;

        private void Awake()
        {
            _branchLogic = GetComponent<IBranchLogic>();
        }

        private void Start()
        {
            //Initializes the global coroutine trees in the coroutineTreesAsset
            _branchLogic.InitializeGlobalCoroutineTrees();
        }
    }
}
