using System;
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
        /// Start action proxy variable
        /// </summary>
        private Action _startAction;

        private void Awake()
        {
            _startAction = EndTurnButtonAction;
        }


        /// <summary>
        /// Ends the current active hero turn
        /// </summary>
        public void StartAction()
        {
            _startAction();
            
            _startAction = DisableEndTurnButton;
        }
        
        /// <summary>
        /// Enable end turn button after hero start turn actions
        /// to prevent turn cycling if button is spammed
        /// </summary>
        public void EnableEndTurnButton()
        {
            _startAction = EndTurnButtonAction;
        }


        /// <summary>
        /// End turn button main action
        /// </summary>
        private void EndTurnButtonAction()
        {
            var logicTree = BattleSceneManager.BattleSceneSettings.CoroutineTreesAsset.MainLogicTree;

            logicTree.AddSibling(BattleSceneManager.TurnController.HeroEndTurn.StartAction());
        }
        
        /// <summary>
        /// Disables end turn button functionality
        /// </summary>
        private void DisableEndTurnButton()
        {
            
        }


    }
}
