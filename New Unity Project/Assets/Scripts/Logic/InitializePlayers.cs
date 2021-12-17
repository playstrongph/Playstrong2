using System.Collections;
using UnityEngine;

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
        
    /// <summary>
    /// Loads the main and enemy 
    /// </summary>
    /// <returns></returns>
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
            
        //Set MainPlayer and EnemyPlayer References
        _battleSceneManager.MainPlayer = mainPlayer;
        _battleSceneManager.EnemyPlayer = enemyPlayer;
            
        //Set Players battle scene manager references
        mainPlayer.BattleSceneManager = _battleSceneManager;
        enemyPlayer.BattleSceneManager = _battleSceneManager;
            
            
        //Set AliveHeroes transform position
        mainPlayer.AliveHeroes.ThisGameObject.transform.position =
            _battleSceneManager.BattleSceneSettings.AllyHeroesPosition;
        enemyPlayer.AliveHeroes.ThisGameObject.transform.position =
            _battleSceneManager.BattleSceneSettings.EnemyHeroesPosition;
            
        //Set the other player references
        mainPlayer.OtherPlayer = enemyPlayer;
        enemyPlayer.OtherPlayer = mainPlayer;

        logicTree.EndSequence();
        yield return null;
    }


}