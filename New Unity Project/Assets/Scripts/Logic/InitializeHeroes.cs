using System.Collections;
using UnityEngine;

namespace Logic
{
    public class InitializeHeroes : MonoBehaviour
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
           
           //TODO: MainPlayerTeamHeroesAsset and MainEnemyTeamHeroesAsset
           
           //var mainPlayerTeamHeroesPosition = _battleSceneManager.
           
           
           
            
            

           logicTree.EndSequence();
           yield return null;
        }
    }
}
