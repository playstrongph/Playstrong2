using System.Collections;
using UnityEngine;

namespace Logic
{
    public class InitializeGameBoard : MonoBehaviour, IInitializeGameBoard
    {
        private IBattleSceneManager BattleSceneManager { get; set; }

        private void Awake()
        {
            BattleSceneManager = GetComponent<IBattleSceneManager>();
        }

        public IEnumerator StartAction()
        {
            var logicTree = BattleSceneManager.BattleSceneSettings.CoroutineTreesAsset.MainLogicTree;
            var gameBoardPrefab = BattleSceneManager.BattleSceneSettings.GameBoard.ThisGameObject;
            var gameBoardObject = Instantiate(gameBoardPrefab, BattleSceneManager.ThisGameObject.transform);
            var gameBoard = gameBoardObject.GetComponent<IGameBoard>();
            
            //Remove 'clone' from the name
            gameBoardObject.name = gameBoardPrefab.name;
            
            //Set references
            gameBoard.BattleSceneManager = BattleSceneManager;
            BattleSceneManager.GameBoard = gameBoard;

            logicTree.EndSequence();
            yield return null;
        }
    }
}