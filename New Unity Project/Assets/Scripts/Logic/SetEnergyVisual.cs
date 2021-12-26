﻿using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public class SetEnergyVisual : MonoBehaviour, ISetEnergyVisual
    {   
        
        private IHeroVisual _heroVisual;
        
        private void Awake()
        {
            _heroVisual = GetComponent<IHeroVisual>();
        }
        
        /// <summary>
        /// Updates the displayed energy text and bar fill
        /// EXCLUSIVELY used for turn controller update hero timers 
        /// </summary>
        /// <param name="energyValue"></param>
        public void UpdateEnergyTextAndBarFill(int energyValue)
        {
            //Clamps the displayed text to 100%
            //var energyDisplayText = Mathf.Min(100, energyValue);
            var energyText = _heroVisual.EnergyVisual.Text;
            var energyIcon = _heroVisual.EnergyVisual.Icon;
            var energyDisplayText = energyValue;
            
            energyText.text = energyDisplayText.ToString() +"%";
            energyIcon.fillAmount = energyDisplayText/100f;
        }
        
        /// <summary>
        ///  Updates the displayed energy text and bar fill
        /// </summary>
        /// <param name="energyValue"></param>
        /// <param name="hero"></param>
        public void SetEnergyTextAndBarFill(int energyValue, IHero hero)
        {
            //Clamps the displayed text to 100%
            //var energyDisplayText = Mathf.Min(100, energyValue);

            var energyText = _heroVisual.EnergyVisual.Text;
            var energyIcon = _heroVisual.EnergyVisual.Icon;
            var energyDisplayText = energyValue;
            
            energyText.text = energyDisplayText.ToString() +"%";
            energyIcon.fillAmount = energyDisplayText/100f;
        }

       /// <summary>
       /// Sets the energy percentage text color
       /// </summary>
       /// <param name="textColor"></param>
       /// <param name="hero"></param>
        public void SetEnergyTextColor(Color textColor, IHero hero)
        {
            var energyText = _heroVisual.EnergyVisual.Text;
            
            energyText.color = textColor;
        }

      /// <summary>
      /// Sets the energy bar color used by abilities like slow and haste
      /// </summary>
      /// <param name="energyBarColor"></param>
      /// <param name="hero"></param>
        public void SetBarFillColor(Color energyBarColor, IHero hero)
        {
            var energyIcon = _heroVisual.EnergyVisual.Icon;
            
            energyIcon.color = energyBarColor;
        }
    }
}