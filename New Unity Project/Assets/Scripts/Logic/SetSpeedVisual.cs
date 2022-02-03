using System;
using UnityEngine;

namespace Logic
{
    public class SetSpeedVisual : MonoBehaviour, ISetSpeedVisual
    {
        private IHeroVisual _heroVisual;

        private void Awake()
        {
            _heroVisual = GetComponent<IHeroVisual>();
        }
        
        /// <summary>
        /// Changes the energy fill and color 
        /// </summary>
        public void StartAction()
        {
            var energyFillIcon = _heroVisual.EnergyVisual.Icon;
            var energyTextColor = _heroVisual.EnergyVisual.Text;
            var baseSpeed = _heroVisual.Hero.HeroLogic.HeroAttributes.BaseSpeed;
            var speed = _heroVisual.Hero.HeroLogic.HeroAttributes.Speed;

            if (speed == baseSpeed)
            {
                energyFillIcon.color = Color.white;
                energyTextColor.color = Color.white;
            }
            else if (speed > baseSpeed)
            {
                energyFillIcon.color = Color.green;
                energyTextColor.color = Color.green;
            }
            else if (speed < baseSpeed)
            {
                energyFillIcon.color = Color.red;
                energyTextColor.color = Color.red;
            }
        }
    }
}
