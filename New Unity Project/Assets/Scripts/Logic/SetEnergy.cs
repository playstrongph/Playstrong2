using System.Collections;
using UnityEngine;

namespace Logic
{
    public class SetEnergy : MonoBehaviour, ISetEnergy
    {
        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
        
        /// <summary>
        /// Converts the energy value to speed units then updates the hero energy
        /// through the hero timer
        /// </summary>
        public void SetToValue(int energyValue)
        {
            var heroTimer = _heroLogic.HeroTimer;
            heroTimer.SetHeroTimer(energyValue);
            
            var logicTree = _heroLogic.Hero.CoroutineTrees.MainLogicTree;
            logicTree.AddCurrent(SetTextVisual(energyValue));
        }
        
        /// <summary>
        /// Receive Bonus energy based on resistance
        /// </summary>
        /// <param name="energyValue"></param>
        public void IncreaseBonusEnergy(int energyValue)
        {
            var bonusEnergyResistance = _heroLogic.ResistanceAttributes.BonusEnergyResistance;
            var bonusEnergyDefaultChance = 100;
            var netBonusEnergyChance = bonusEnergyDefaultChance - bonusEnergyResistance;
            var randomChance = Random.Range(1, 101);

            var newEnergyValue = Mathf.Max(energyValue + _heroLogic.HeroAttributes.Energy,0);
            
            if(randomChance <= netBonusEnergyChance)
                SetToValue(newEnergyValue);
            
            Debug.Log("Increase Energy");

        }
        
        /// <summary>
        /// Receive Bonus energy based on resistance
        /// </summary>
        /// <param name="energyValue"></param>
        public void DecreaseBonusEnergy(int energyValue)
        {
            //Clamp minimum energy value to zero
            var newEnergyValue = Mathf.Max(_heroLogic.HeroAttributes.Energy - energyValue,0);

            SetToValue(newEnergyValue);
        }


        /// <summary>
        /// Sets the energy and hero timer units to zero
        /// </summary>
        public void ResetToZero()
        {
            var heroTimer = _heroLogic.HeroTimer;
            var zeroEnergy = 0;
            
            heroTimer.ResetHeroTimer();
            
            var logicTree = _heroLogic.Hero.CoroutineTrees.MainLogicTree;
            logicTree.AddCurrent(SetTextVisual(zeroEnergy));
        }
        
        /// <summary>
        /// Logic tree wrapper
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private IEnumerator SetTextVisual(int value)
        {
            var logicTree = _heroLogic.Hero.CoroutineTrees.MainLogicTree;
            var visualTree = _heroLogic.Hero.CoroutineTrees.MainVisualTree;
            
            visualTree.AddCurrent(TextVisual(value));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Armor text Update 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private IEnumerator TextVisual(int value)
        {
            var visualTree = _heroLogic.Hero.CoroutineTrees.MainVisualTree;
            var hero = _heroLogic.Hero;
            
            hero.HeroVisual.SetEnergyVisual.StartAction(value);
            
            visualTree.EndSequence();
            yield return null;
        }
    }
}