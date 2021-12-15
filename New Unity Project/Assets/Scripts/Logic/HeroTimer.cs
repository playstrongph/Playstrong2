﻿using System;
using UnityEngine;

namespace Logic
{
    public class HeroTimer : MonoBehaviour
    {
        /// <summary>
        /// Timer value in units
        /// </summary>
        [SerializeField] private float timerValue;
        public float TimerValue
        {
            get => timerValue;
            set => timerValue = value;
        }
        
        /// <summary>
        /// Timer value expressed in percentage
        /// current timer value / timer full
        /// </summary>
        [SerializeField] private float timerValuePercent;
        public float TimerValuePercent
        {
            get => timerValuePercent;
            set => timerValuePercent = value;
        }
        
        private IHeroLogic HeroLogic { get; set; }

        private void Awake()
        {
            HeroLogic = GetComponent<IHeroLogic>();
        }
        
        /// <summary>
        /// Resets the energy and hero timer values back to zero
        /// </summary>
        public void ResetHeroTimer()
        {
            var heroEnergyVisual = HeroLogic.Hero.HeroVisual.EnergyVisual;

            TimerValue = 0;
            TimerValuePercent = 0;
            HeroLogic.HeroAttributes.Energy = Mathf.RoundToInt(TimerValuePercent);
            
            heroEnergyVisual.SetEnergyTextAndBarFill((int)TimerValuePercent);
        }
        
        /*/// <summary>
        /// Sets the hero's timer to the converted energy value
        /// </summary>
        /// <param name="turnController"></param>
        /// <param name="energyValue"></param>
        public void SetHeroTimerValue(ITurnController turnController, int energyValue)
        {
            var timerValueConvert = energyValue * turnController.TimerFull / 100f;
            TimerValue = timerValueConvert;
            TimerValue = Mathf.Max(0f, TimerValue);  
            
            //Transfer the method to TurnController
            //UpdateEnergyAndActiveHeroes(turnController);
        }*/
        
        /*/// <summary>
        /// Updates the hero's timer using the hero's speed and the
        /// turn controllers speed constant
        /// </summary>
        public void UpdateHeroTimer(ITurnController turnController )
        {
            var speedConstant = turnController.SpeedConstant;
            var heroSpeed = HeroLogic.HeroAttributes.Speed;
            TimerValue += heroSpeed * Time.deltaTime * speedConstant;
            
            //Transfer the method to TurnController
            //UpdateEnergyAndActiveHeroes(turnController);
        }*/
        
        
        
        
        

      
    }
}
