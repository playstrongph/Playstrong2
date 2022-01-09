﻿using AssetsScriptableObjects;
using UnityEngine;

namespace Logic
{
    public class LoadHeroAttributes : MonoBehaviour, ILoadHeroAttributes
    {
        /// <summary>
        /// Hero logic reference
        /// </summary>
        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        public void StartAction(IHeroAsset heroAsset)
        {
            StartActionLogic(heroAsset);
            StartActionVisual();
        }
        
        /// <summary>
        /// Start action logic component
        /// </summary>
        /// <param name="heroAsset"></param>
        private void StartActionLogic(IHeroAsset heroAsset)
        {
            var heroAttributes = _heroLogic.HeroAttributes;
            var initialEnergy = 0;
           
            
            //BASE VALUES 
            heroAttributes.BaseAttack = heroAsset.Attack;
            heroAttributes.BaseArmor = heroAsset.Armor;
            heroAttributes.BaseChance = heroAsset.Chance;
            heroAttributes.BaseHealth = heroAsset.Health;
            heroAttributes.BaseSpeed = heroAsset.Speed;
            
            //CURRENT VALUES
            _heroLogic.SetAttack.StartAction(heroAsset.Attack);
            _heroLogic.SetArmor.StartAction(heroAsset.Armor);
            _heroLogic.SetChance.StartAction(heroAsset.Chance);
            _heroLogic.SetHealth.StartAction(heroAsset.Health);
            _heroLogic.SetSpeed.StartAction(heroAsset.Speed);
            _heroLogic.SetFightingSpirit.StartAction(heroAsset.FightingSpirit);


            //TODO: Break this down
            _heroLogic.SetEnergy.SetToValue(initialEnergy);
        }
        
        /// <summary>
        /// Start action visual component
        /// </summary>
        private void StartActionVisual()
        {
            var heroVisual = _heroLogic.Hero.HeroVisual;
            
            heroVisual.SetAttackVisual.StartAction();
            heroVisual.SetArmorVisual.StartAction();
            heroVisual.SetHealthVisual.StartAction();
            heroVisual.SetFightingSpiritVisual.StartAction();
            
        }
    }
}