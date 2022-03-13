using System.Collections;
using ScriptableObjectScripts.GameAnimationAssets;
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
       /// <param name="value"></param>
        public void StartAction(int value)
        {
            //var timerValuePercent = _heroVisual.Hero.HeroLogic.HeroTimer.TimerValuePercent;
            
            //Clamps the displayed text to 100%
            var energyText = _heroVisual.EnergyVisual.Text;
            var energyIcon = _heroVisual.EnergyVisual.Icon;
            
            
            //var energyDisplayText = (int)timerValuePercent;
            var energyDisplayText = value;
            
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