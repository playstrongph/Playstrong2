using System;
using System.Collections;
using System.Runtime.CompilerServices;
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
        /// Battle scene manager as a game object
        /// </summary>
        [SerializeField] private GameObject thisGameObject;
        public GameObject ThisGameObject
        {
            get
            {
                thisGameObject = this.gameObject;
                return thisGameObject;
            }
            private set => thisGameObject = value;
        }

        /// <summary>
        /// Local variable for BranchLogic
        /// used in initialization of global coroutine trees
        /// </summary>
        private IBranchLogic _branchLogic;
        
        /// <summary>
        /// Local access to InitializePlayers attached
        /// to the same gameObject
        /// </summary>
        private IInitializePlayers _initializePlayers;

        private void Awake()
        {
            _branchLogic = GetComponent<IBranchLogic>();
            _initializePlayers = GetComponent<IInitializePlayers>();
        }

        private void Start()
        {
            var logicTree = BattleSceneSettings.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(InitializeBattle());
        }

        /// <summary>
        /// Initializes the start of battle
        /// </summary>
        /// <returns></returns>
        private IEnumerator InitializeBattle()
        {
            var logicTree = BattleSceneSettings.CoroutineTreesAsset.MainLogicTree;
            
           logicTree.AddCurrent(_initializePlayers.StartAction());
            
            logicTree.EndSequence();
            yield return null;
        }
    }
}
