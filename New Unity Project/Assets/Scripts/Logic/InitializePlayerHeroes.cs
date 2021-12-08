using System;
using System.Collections;
using System.Collections.Generic;
using AssetsScriptableObjects;
using UnityEngine;

namespace Logic
{

    public class InitializePlayerHeroes : MonoBehaviour, IInitializePlayerHeroes
    {
        private IPlayer _player;

        private void Awake()
        {
            _player = GetComponent<IPlayer>();
        }
        
        
        /// <summary>
        /// Instantiates hero in the game and loads all corresponding values
        /// </summary>
        /// <param name="teamHeroesAsset"></param>
        /// <param name="heroPrefab"></param>
        /// <param name="heroesParentLocation"></param>
        /// <param name="heroPreviewLocation"></param>
        /// <returns></returns>
        public IEnumerator StartAction(ITeamHeroesAsset teamHeroesAsset, GameObject heroPrefab, Transform heroesParentLocation,
            Vector3 heroPreviewLocation)
        {
            var logicTree = _player.CoroutineTrees.MainLogicTree;

            foreach (var heroAsset in teamHeroesAsset.TeamHeroes())
            {
                //Instantiate hero in the scene
                var heroObject = Instantiate(heroPrefab, heroesParentLocation);
                
                //Set hero name in the Inspector
                heroObject.name = heroAsset.HeroName;


            }
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
    }
}
