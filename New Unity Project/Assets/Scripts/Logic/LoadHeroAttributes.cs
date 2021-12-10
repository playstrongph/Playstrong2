using System;
using AssetsScriptableObjects;
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
            
            var heroAttributes = _heroLogic.HeroAttributes;
            var initialEnergy = 0;
            var logicTree = _heroLogic.Hero.CoroutineTrees.MainLogicTree;
            
            //TODO: This should already utilize the SetAttributeMethods in heroLogic
            
            //BASE VALUES
            heroAttributes.BaseAttack = heroAsset.Attack;
            heroAttributes.BaseArmor = heroAsset.Armor;
            heroAttributes.BaseChance = heroAsset.Chance;
            heroAttributes.BaseHealth = heroAsset.Health;
            heroAttributes.BaseSpeed = heroAsset.Speed;
            
            //CURRENT VALUES
            logicTree.AddCurrent(_heroLogic.SetAttack.StartAction(heroAsset.Attack));
            logicTree.AddCurrent(_heroLogic.SetArmor.StartAction(heroAsset.Armor));
            
            heroAttributes.Speed = heroAsset.Speed;
            
            heroAttributes.Chance = heroAsset.Chance;
            
            heroAttributes.Health = heroAsset.Health;
            
            heroAttributes.FightingEnergy = heroAttributes.FightingEnergy;
            heroAttributes.Energy = initialEnergy;
        }
    }
}
