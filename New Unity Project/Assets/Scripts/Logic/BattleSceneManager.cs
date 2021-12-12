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
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;
        
        /// <summary>
        /// Reference to Main Player
        /// used in Initializing heroes
        /// </summary>
        public IPlayer MainPlayer { get; set; }
        
        /// <summary>
        /// Reference to Enemy Player
        ///  used in Initializing heroes
        /// </summary>
        public IPlayer EnemyPlayer { get; set; }

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
        
        /// <summary>
        /// Local access to initialize heroes
        /// attached to the same game object
        /// </summary>
        private IInitializeHeroes _initializeHeroes;

        private void Awake()
        {
            _branchLogic = GetComponent<IBranchLogic>();
            _initializePlayers = GetComponent<IInitializePlayers>();
            _initializeHeroes = GetComponent<IInitializeHeroes>();
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
            
           logicTree.AddSibling(_initializePlayers.StartAction());
           
           logicTree.AddSibling(_initializeHeroes.StartAction());
            
           logicTree.EndSequence();
           yield return null;
        }
    }
}
