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
            var turnController = _heroLogic.Hero.Player.BattleSceneManager.TurnController;
            var heroTimer = _heroLogic.HeroTimer;
            
            heroTimer.SetHeroTimer(energyValue);
        }
        
        /// <summary>
        /// Sets the energy and hero timer units to zero
        /// </summary>
        public void ResetToZero()
        {
            var turnController = _heroLogic.Hero.Player.BattleSceneManager.TurnController;
            var heroTimer = _heroLogic.HeroTimer;
            
            heroTimer.ResetHeroTimer();
        }
    }
}