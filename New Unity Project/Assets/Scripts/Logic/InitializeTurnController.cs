using System.Collections;
using UnityEngine;

namespace Logic
{
    public class InitializeTurnController : MonoBehaviour, IInitializeTurnController
    {
        /// <summary>
        /// Reference to battle scene manager
        /// </summary>
        private IBattleSceneManager _battleSceneManager;
        
        private void Awake()
        {
            _battleSceneManager = GetComponent<IBattleSceneManager>();
        }
        
        /// <summary>
        /// Instantiates and initializes the turn controller
        /// </summary>
        /// <returns></returns>
        public IEnumerator StartAction()
        {
            var logicTree = _battleSceneManager.BattleSceneSettings.CoroutineTreesAsset.MainLogicTree;
            var turnControllerPrefab = _battleSceneManager.BattleSceneSettings.TurnController.ThisGameObject;
            var turnControllerObject = Instantiate(turnControllerPrefab, _battleSceneManager.ThisGameObject.transform);
            var turnController = turnControllerObject.GetComponent<ITurnController>();
            
            //Set Battle Scene Manager turn controller reference
            _battleSceneManager.TurnController = turnController;
            
            //Set turn controller battle scene manager reference
            turnController.BattleSceneManager = _battleSceneManager;
            
            //Remove "clone" from the name of the turn controller object in the inspector
            turnControllerObject.name = "TurnController";

            logicTree.EndSequence();
            yield return null;
        }

    }
}
