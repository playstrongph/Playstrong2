using System.Collections;
using JondiBranchLogic;
using ScriptableObjectScripts;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Logic
{
    public class SequenceTester : MonoBehaviour, IBattleSceneManager
    {
        #region Variables

        

       
        
        
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
        /// Reference to the the turn controller
        /// set during initialization
        /// </summary>
        public ITurnController TurnController { get; set; }

        /// <summary>
        /// Reference to the game board
        /// </summary>
        public IGameBoard GameBoard { get; set; }
        
        /// <summary>
        /// Reference to the end turn button
        /// </summary>
        public IEndTurnButton EndTurnButton { get; set; }

        /// <summary>
        /// Local variable for BranchLogic
        /// used in initialization of global coroutine trees
        /// </summary>
        private IBranchLogic _branchLogic;
        
        /// <summary>
        /// Local access to initialize turn controller script
        /// </summary>
        private IInitializeTurnController _initializeTurnController;
        
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

        /// <summary>
        /// Local access to initialize game board script
        /// </summary>
        private IInitializeGameBoard _initializeGameBoard;
    
        /// <summary>
        /// Local access to start battle
        /// </summary>
        private IStartBattle _startBattle;
        
        #endregion
        
        private void Awake()
        {
            _branchLogic = GetComponent<IBranchLogic>();
        }

        private void Start()
        {
            var logicTree = BattleSceneSettings.CoroutineTreesAsset.MainLogicTree;
            
            //logicTree.AddSibling(MainTestSequence());
            MainTestSequence();
        }

        private void MainTestSequence()
        {
            var logicTree = BattleSceneSettings.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddSibling(CoroutineA());
            
            logicTree.AddSibling(CoroutineB());
            
            logicTree.AddSibling(CoroutineC());
            
            
            logicTree.EndSequence();
            //yield return null;

        }
        
        private IEnumerator CoroutineA()
        {
            var logicTree = BattleSceneSettings.CoroutineTreesAsset.MainLogicTree;
            
            Debug.Log("Coroutine A");
            
            logicTree.AddSibling(CoroutineA1());
            
            logicTree.AddSibling(CoroutineA2());
            
            logicTree.EndSequence();
            yield return null;

        }
        
        private IEnumerator CoroutineA1()
        {
            var logicTree = BattleSceneSettings.CoroutineTreesAsset.MainLogicTree;
            
            Debug.Log("Coroutine A.1");
            
            logicTree.AddSibling(CoroutineA11());
            
            logicTree.AddSibling(CoroutineA12());
            
            logicTree.EndSequence();
            yield return null;

        }
        
        private IEnumerator CoroutineA11()
        {
            var logicTree = BattleSceneSettings.CoroutineTreesAsset.MainLogicTree;
            
            Debug.Log("Coroutine A.1.1");
            
            logicTree.EndSequence();
            yield return null;

        }
        
        private IEnumerator CoroutineA12()
        {
            var logicTree = BattleSceneSettings.CoroutineTreesAsset.MainLogicTree;
            
            Debug.Log("Coroutine A.1.2");
            
            logicTree.EndSequence();
            yield return null;

        }
        
        private IEnumerator CoroutineA2()
        {
            var logicTree = BattleSceneSettings.CoroutineTreesAsset.MainLogicTree;
            
            Debug.Log("Coroutine A.2");
            
            logicTree.AddSibling(CoroutineA21());
            
            logicTree.AddSibling(CoroutineA22());
            
            logicTree.EndSequence();
            yield return null;

        }
        
        private IEnumerator CoroutineA21()
        {
            var logicTree = BattleSceneSettings.CoroutineTreesAsset.MainLogicTree;
            
            Debug.Log("Coroutine A.2.1");
            
            logicTree.EndSequence();
            yield return null;

        }
        
        private IEnumerator CoroutineA22()
        {
            var logicTree = BattleSceneSettings.CoroutineTreesAsset.MainLogicTree;
            
            Debug.Log("Coroutine A.2.2");
            
            logicTree.EndSequence();
            yield return null;

        }


        private IEnumerator CoroutineB()
        {
            var logicTree = BattleSceneSettings.CoroutineTreesAsset.MainLogicTree;
            
            Debug.Log("Coroutine B");
            
            logicTree.EndSequence();
            yield return null;

        }
        
        private IEnumerator CoroutineC()
        {
            var logicTree = BattleSceneSettings.CoroutineTreesAsset.MainLogicTree;
            
            Debug.Log("Coroutine C");
            
            logicTree.EndSequence();
            yield return null;

        }
        



    }
}