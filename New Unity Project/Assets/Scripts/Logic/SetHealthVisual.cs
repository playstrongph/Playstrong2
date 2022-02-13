﻿using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Sets the hero's health visual text
    /// </summary>
    public class SetHealthVisual : MonoBehaviour, ISetHealthVisual
    {
        private IHeroVisual _heroVisual;
        
        private void Awake()
        {
            _heroVisual = GetComponent<IHeroVisual>();
        }
        
        /// <summary>
        /// Sets the health visual value
        /// value can be negative
        /// </summary>
        public void StartAction(int value)
        {
            SetVisualValue(value);
        }

        private void SetVisualValue(int value)
        {
            var heroLogic = _heroVisual.Hero.HeroLogic;
            var baseValue = heroLogic.HeroAttributes.BaseHealth;
            
            //var healthValue = heroLogic.HeroAttributes.Health;
            var healthValue = value;
            
            _heroVisual.HealthVisual.Text.text = healthValue.ToString();
            _heroVisual.HealthVisual.Text.color = GetTextColor(baseValue,healthValue );
        }
        
        private Color GetTextColor(int baseValue, int value)
        {
            if(value>baseValue)
                return Color.green;
            else if (value == baseValue)
                return Color.white;
            else if(value < baseValue)
                return Color.red;
            else
                return Color.white;
            
        }


    }
}