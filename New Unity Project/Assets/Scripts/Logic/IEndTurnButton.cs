using UnityEngine;

namespace Logic
{
    public interface IEndTurnButton
    {
        /// <summary>
        /// Reference is set during instantiation
        /// </summary>
        IBattleSceneManager BattleSceneManager { get; set; }

        /// <summary>
        /// Ends the current active hero turn
        /// </summary>
        void StartAction();
        
        /// <summary>
        /// EndTurnButton game object
        /// </summary>
        GameObject ThisGameObject { get; }
        
        /// <summary>
        /// Enable end turn button after hero start turn actions
        /// to prevent turn cycling if button is spammed
        /// </summary>
        void EnableEndTurnButton();
    }
}