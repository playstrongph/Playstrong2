using ScriptableObjectScripts;
using UnityEngine;

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
        
    /// <summary>
    /// Reference to the turn controller
    /// </summary>
    ITurnController TurnController { get; set; }
        
    /// <summary>
    /// Reference to the game board
    /// </summary>
    IGameBoard GameBoard { get; set; }
}