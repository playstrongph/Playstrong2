using System.Collections;
using UnityEngine;

namespace Logic
{
    public class StartBattle : MonoBehaviour, IStartBattle
    {

        private IBattleSceneManager _battleSceneManager;

        private void Awake()
        {
            _battleSceneManager = GetComponent<IBattleSceneManager>();
        }
    
        /// <summary>
        /// Combat start for both players
        /// </summary>
        /// <returns></returns>
        public IEnumerator StartAction()
        {
            var logicTree = _battleSceneManager.BattleSceneSettings.CoroutineTreesAsset.MainLogicTree;
            var turnController = _battleSceneManager.TurnController;
            
            turnController.StartBattle();
            
            logicTree.EndSequence();
            yield return null;
        }
    
    
    }
}
