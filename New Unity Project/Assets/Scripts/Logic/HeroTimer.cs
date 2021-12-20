using UnityEngine;
using Object = UnityEngine.Object;

namespace Logic
{
    public class HeroTimer : MonoBehaviour, IHeroTimer
    {
        #region PROPERTIES AND VARIABLES

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
        
        #endregion

        #region EXECUTION
        
        private void Awake()
        {
            HeroLogic = GetComponent<IHeroLogic>();
        }

        /// <summary>
        /// Updates the hero's timer using the hero's speed and the turn controllers speed constant
        /// EXCLUSIVELY used by the turn controller to update hero timers
        /// </summary>
        public void UpdateHeroTimer()
        {
            var turnController = HeroLogic.Hero.Player.BattleSceneManager.TurnController;
            var speedConstant = turnController.SpeedConstant;
            var heroSpeed = HeroLogic.HeroAttributes.Speed;

            TimerValue += heroSpeed * Time.deltaTime * speedConstant;

            UpdateEnergy(turnController);
            UpdateActiveHeroes(turnController);
        }
        
        /// <summary>
        /// Resets the energy and hero timer values back to zero
        /// </summary>
        public void ResetHeroTimer()
        {
            var turnController = HeroLogic.Hero.Player.BattleSceneManager.TurnController;

            TimerValue = 0;

            SetEnergy(turnController);
            UpdateActiveHeroes(turnController);
        }
        
        /// <summary>
        /// Sets the hero's timer to the converted energy value
        /// </summary>
        /// <param name="energyValue"></param>
        public void SetHeroTimer(int energyValue)
        {
            var turnController = HeroLogic.Hero.Player.BattleSceneManager.TurnController;
            var timerValueConvert = energyValue * turnController.TimerFull / 100f;
            TimerValue = timerValueConvert;
            TimerValue = Mathf.Max(0f, TimerValue);  
            
            SetEnergy(turnController);
            UpdateActiveHeroes(turnController);
        }
        
        #endregion

        #region AUXILLIARY METHODS

        /// <summary>
        /// Updates the energy attribute, text, and bar fill
        /// EXCLUSIVELY used by the turn controller update hero timers
        /// </summary>
        /// <param name="turnController"></param>
        private void UpdateEnergy(ITurnController turnController)
        {
            //Debug.Log("Update Energy");
            
            var timerFull = turnController.TimerFull;
            var heroEnergyVisual = HeroLogic.Hero.HeroVisual.EnergyVisual;
            
            //Set timer value percent
            TimerValuePercent = Mathf.FloorToInt(TimerValue * 100 / timerFull);
            
            //Set hero energy attribute
            HeroLogic.HeroAttributes.Energy = Mathf.FloorToInt(TimerValuePercent);
            
            //Visual energy text and bar update
            heroEnergyVisual.UpdateEnergyTextAndBarFill((int)TimerValuePercent);
        }
        
        /// <summary>
        /// Updates the energy attribute, text, and bar fill
        /// </summary>
        /// <param name="turnController"></param>
        private void SetEnergy(ITurnController turnController)
        {

            var timerFull = turnController.TimerFull;
            var heroEnergyVisual = HeroLogic.Hero.HeroVisual.EnergyVisual;
            var visualTree = HeroLogic.Hero.CoroutineTrees.MainVisualTree;
            
            //Set timer value percent
            TimerValuePercent = Mathf.FloorToInt(TimerValue * 100 / timerFull);
            
            //Set hero energy attribute
            HeroLogic.HeroAttributes.Energy = Mathf.FloorToInt(TimerValuePercent);
            
            //Visual energy text and bar update
            visualTree.AddCurrent(heroEnergyVisual.SetEnergyTextAndBarFill((int)TimerValuePercent, HeroLogic.Hero));
        }
        
        
        /// <summary>
        /// Updates the active heroes in turn controller
        /// </summary>
        /// <param name="turnController"></param>
        private void UpdateActiveHeroes(ITurnController turnController)
        {
            var timerFull = turnController.TimerFull;
            var activeHeroes = turnController.ActiveHeroes;
            var activeHeroesList = turnController.ActiveHeroesList;
            
            //If hero's energy is >= 100%, add to active heroes list
            if (TimerValue >= timerFull)
            {
                turnController.ActiveHeroFound = true;

                //Check first if hero is not in the active heroes list before adding
                if(!activeHeroes.Contains(this.HeroLogic.Hero)) 
                    activeHeroesList.Add(this.HeroLogic.Hero as Object);
                
                //Sort heroes by Highest to lowest energy
                //logicTree.AddCurrent(turnController.SortHeroesByEnergy.StartAction());
                turnController.SortHeroesByEnergy.StartAction();
            }
            
            //If hero's energy is < 100%, remove form active heroes list
            if (TimerValue < timerFull)
            {
                //Check first if hero is in the active heroes list
                if(activeHeroes.Contains(this.HeroLogic.Hero)) 
                    activeHeroesList.Remove(this.HeroLogic.Hero as Object);
                
                //Sort heroes by Highest to lowest energy
                //logicTree.AddCurrent(turnController.SortHeroesByEnergy.StartAction());
                turnController.SortHeroesByEnergy.StartAction();
            } 
        }
       
        
        
        #endregion

    }
}