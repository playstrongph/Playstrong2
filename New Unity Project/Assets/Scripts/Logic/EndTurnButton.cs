using UnityEngine;

namespace Logic
{
    public class EndTurnButton : MonoBehaviour, IEndTurnButton
    {
        /// <summary>
        /// Reference is set during instantiation
        /// </summary>
        public IBattleSceneManager BattleSceneManager { get; set; }
        
        /// <summary>
        /// Return this as a GameObject
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;


        /// <summary>
        /// Ends the current active hero turn
        /// </summary>
        public void StartAction()
        {
            var logicTree = BattleSceneManager.BattleSceneSettings.CoroutineTreesAsset.MainLogicTree;

            logicTree.AddSibling(BattleSceneManager.TurnController.HeroEndTurn.StartAction());
        }
        
        

    }
}
