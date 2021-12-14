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
            
            //BASE VALUES
            heroAttributes.BaseAttack = heroAsset.Attack;
            heroAttributes.BaseArmor = heroAsset.Armor;
            heroAttributes.BaseChance = heroAsset.Chance;
            heroAttributes.BaseHealth = heroAsset.Health;
            heroAttributes.BaseSpeed = heroAsset.Speed;
            
            //CURRENT VALUES
            //logicTree.AddCurrent(_heroLogic.SetAttack.StartAction(heroAsset.Attack));
            _heroLogic.SetAttack.StartAction(heroAsset.Attack);
            
            //logicTree.AddCurrent(_heroLogic.SetArmor.StartAction(heroAsset.Armor));
            _heroLogic.SetArmor.StartAction(heroAsset.Armor);
            
            //logicTree.AddCurrent(_heroLogic.SetChance.StartAction(heroAsset.Chance));
            _heroLogic.SetChance.StartAction(heroAsset.Chance);
            
            //logicTree.AddCurrent(_heroLogic.SetHealth.StartAction(heroAsset.Health));
            _heroLogic.SetHealth.StartAction(heroAsset.Health);
            
            //logicTree.AddCurrent(_heroLogic.SetSpeed.StartAction(heroAsset.Speed));
            _heroLogic.SetSpeed.StartAction(heroAsset.Speed);

            //NON-BASIC ATTRIBUTES
            //logicTree.AddCurrent(_heroLogic.SetFightingSpirit.StartAction(heroAsset.FightingSpirit));
            _heroLogic.SetFightingSpirit.StartAction(heroAsset.FightingSpirit);
            
            //TODO: Replace with SetEnergy
            heroAttributes.Energy = initialEnergy;
        }
    }
}
