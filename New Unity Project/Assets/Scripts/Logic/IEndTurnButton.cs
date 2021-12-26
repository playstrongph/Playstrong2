﻿namespace Logic
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
    }
}