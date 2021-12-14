using System;
using System.Collections;
using System.Collections.Generic;
using AssetsScriptableObjects;
using UnityEngine;

namespace Logic
{

    public class InitializePlayerHeroes : MonoBehaviour, IInitializePlayerHeroes
    {
        
        /// <summary>
        /// Player reference
        /// Hero belongs to this player
        /// </summary>
        private IPlayer _player;
        private IPlayer Player => _player;

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
        public void StartAction(ITeamHeroesAsset teamHeroesAsset, GameObject heroPrefab, Transform heroesParentLocation,
            Vector3 heroPreviewLocation)
        {
            var logicTree = _player.CoroutineTrees.MainLogicTree;

            foreach (var heroAsset in teamHeroesAsset.TeamHeroes())
            {
                //Instantiate hero in the scene
                var heroObject = Instantiate(heroPrefab, heroesParentLocation);
                
                var hero = heroObject.GetComponent<IHero>();
                
                //Set hero name in the Inspector
                heroObject.name = heroAsset.HeroName;
                hero.HeroName = heroAsset.HeroName;
                
                //Set the new hero's player reference
                hero.Player = Player;
                
                //Load the hero attributes
                hero.HeroLogic.LoadHeroAttributes.StartAction(heroAsset);
                
                //Load the hero visuals
                hero.HeroVisual.LoadHeroVisuals.StartAction(heroAsset);
                
                //Load the hero preview visual attributes
                hero.HeroPreview.LoadHeroPreviewVisuals.StartAction(heroAsset);

                //Initializes hero portraits and display portraits
                hero.InitializeHeroPortrait.StartAction();
                
                //Initializes hero skills and display skills
                hero.InitializeHeroSkills.StartAction(heroAsset);
            }
            
            //logicTree.EndSequence();
            //yield return null;
        }




    }
}
