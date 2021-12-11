﻿using System;
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
        public IEnumerator StartAction(ITeamHeroesAsset teamHeroesAsset, GameObject heroPrefab, Transform heroesParentLocation,
            Vector3 heroPreviewLocation)
        {
            var logicTree = _player.CoroutineTrees.MainLogicTree;
            var xCompensation = 0;
            var compensationValue = 80;
            
            
            foreach (var heroAsset in teamHeroesAsset.TeamHeroes())
            {
                //Instantiate hero in the scene
                var heroObject = Instantiate(heroPrefab, heroesParentLocation);
                
                var hero = heroObject.GetComponent<IHero>();
                
                //Set hero name in the Inspector
                heroObject.name = heroAsset.HeroName;
                
                //Set the new hero's player reference
                hero.Player = Player;
                
                //Load the hero attributes
                hero.HeroLogic.LoadHeroAttributes.StartAction(heroAsset);
                
                //Load the hero preview visual attributes
                hero.HeroPreview.LoadHeroPreviewVisuals.StartAction(heroAsset);
                
                //Adjust x position to compensate offset due to grid layout component
                HeroPreviewSetPosition(xCompensation,hero);
                xCompensation -= compensationValue;
                
            }
            
            logicTree.EndSequence();
            yield return null;
        }

        private void HeroPreviewSetPosition(int xCompensation, IHero hero)
        {
            var previewPosition = hero.Player.BattleSceneManager.BattleSceneSettings.HeroPreviewPosition;
           
            previewPosition.x += xCompensation;
            hero.HeroPreview.ThisGameObject.transform.position = previewPosition;
        }


    }
}
