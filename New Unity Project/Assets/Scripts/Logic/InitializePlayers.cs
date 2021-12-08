using System.Collections;
using UnityEngine;

namespace Logic
{
    public class InitializePlayers : MonoBehaviour, IInitializePlayers
    {
        /// <summary>
        /// Reference to battle scene manager
        /// </summary>
        private IBattleSceneManager _battleSceneManager;
        
        
        
        private void Awake()
        {
            _battleSceneManager = GetComponent<IBattleSceneManager>();
        }

        public IEnumerator StartAction()
        {
            var logicTree = _battleSceneManager.BattleSceneSettings.CoroutineTreesAsset.MainLogicTree;
            var playerPrefab = _battleSceneManager.BattleSceneSettings.PlayerPrefab.ThisGameObject;
            var playersParent = _battleSceneManager.ThisGameObject.transform;
            var mainPlayerGameObject = Instantiate(playerPrefab, playersParent);
            var mainPlayer = mainPlayerGameObject.GetComponent<IPlayer>();
            var enemyPlayerGameObject = Instantiate(playerPrefab, playersParent);
            var enemyPlayer = enemyPlayerGameObject.GetComponent<IPlayer>();
            
            //Set game object names in inspector
            mainPlayerGameObject.name = "MainPlayer";
            enemyPlayerGameObject.name = "EnemyPlayer";

            logicTree.EndSequence();
            yield return null;
        }


    }
}
