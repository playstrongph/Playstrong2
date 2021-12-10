using System.Collections;
using UnityEngine;

namespace Logic
{
    public class InitializeHeroes : MonoBehaviour, IInitializeHeroes
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
           var heroPrefab = _battleSceneManager.BattleSceneSettings.HeroPrefab.ThisGameObject;
           var heroPreviewPosition = _battleSceneManager.BattleSceneSettings.HeroPreviewPosition;
           var mainPlayerTeamHeroesAsset = _battleSceneManager.BattleSceneSettings.MainPlayerTeamHeroes;
           var enemyPlayerTeamHeroesAsset = _battleSceneManager.BattleSceneSettings.EnemyPlayerTeamHeroes;
           var mainPlayerTeamHeroesParentsLocation = _battleSceneManager.MainPlayer.AliveHeroes.ThisGameObject.transform;
           var enemyPlayerTeamHeroesParentsLocation = _battleSceneManager.EnemyPlayer.AliveHeroes.ThisGameObject.transform;

          
          logicTree.AddCurrent(_battleSceneManager.MainPlayer.InitializePlayerHeroes.StartAction(mainPlayerTeamHeroesAsset,heroPrefab,mainPlayerTeamHeroesParentsLocation,heroPreviewPosition));
          logicTree.AddCurrent(_battleSceneManager.EnemyPlayer.InitializePlayerHeroes.StartAction(enemyPlayerTeamHeroesAsset,heroPrefab,enemyPlayerTeamHeroesParentsLocation,heroPreviewPosition));
            

           logicTree.EndSequence();
           yield return null;
        }
    }
}
