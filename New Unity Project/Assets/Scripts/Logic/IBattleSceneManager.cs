﻿using ScriptableObjectScripts;
using UnityEngine;

namespace Logic
{
    public interface IBattleSceneManager
    {
        /// <summary>
        /// Interface access to battle scene settings asset
        /// </summary>
        IBattleSceneSettingsAsset BattleSceneSettings { get; set; }
        
        /// <summary>
        /// Interface reference to battle scene manager game object
        /// </summary>
        GameObject ThisGameObject { get; }
        
        /// <summary>
        /// Interface access to Main player 
        /// </summary>
        IPlayer MainPlayer { get; set; }
        
        /// <summary>
        /// Interface access to Enemy player
        /// </summary>
        IPlayer EnemyPlayer { get; set; }
    }
}