using System.Collections;
using System.Collections.Generic;
using JondiBranchLogic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Logic
{
    /// <summary>
    /// Method that controls all the heroes' turns
    /// </summary>
    public class TurnController : MonoBehaviour, ITurnController
    {
        /// <summary>
        /// 100% percent timer full in speed units
        /// </summary>
        [SerializeField] private int timerFull = 500;
        public int TimerFull => timerFull;
        
        /// <summary>
        /// Energy increase per time "tick" (delta time)
        /// </summary>
        [SerializeField] private int speedConstant = 10;
        public int SpeedConstant => speedConstant;

        /// <summary>
        /// Stops all hero timers when true
        /// </summary>
        [SerializeField] private bool activeHeroFound = false;
        public bool ActiveHeroFound
        {
            get => activeHeroFound;
            set => activeHeroFound = value;
        }
        
        /// <summary>
        /// Turn controller reference to the global trees
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ICoroutineTreesAsset))]
        public Object coroutineTrees;

        public ICoroutineTreesAsset CoroutineTrees
        {
            get => coroutineTrees as ICoroutineTreesAsset;
            private set => coroutineTrees = value as Object;
        }

        //SET IN RUNTIME
        /// <summary>
        /// Reference to the battle scene manager
        /// Set during initialization
        /// </summary>
        
        public IBattleSceneManager BattleSceneManager { get; set; }
        
        /// <summary>
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;
        
        /// <summary>
        /// The hero currently taking a turn
        /// </summary>
        [Header("SET IN RUNTIME")]
        [SerializeField] private Object currentActiveHero;
        private IHero CurrentActiveHero
        {
            get => currentActiveHero as IHero;
            set => currentActiveHero = value as Object;
        }
        
        /// <summary>
        /// List of active heroes
        /// Displayed in inspector for debugging purposes
        /// </summary>
        [SerializeField] 
        private List<Object> activeHeroes = new List<Object>();
        
        /// <summary>
        /// Used for adding heroes to the active heroes list 
        /// </summary>
        public List<Object> ActiveHeroesList => activeHeroes;
        
        

        /// <summary>
        /// Returns list of active heroes
        /// Don't use this to add to the list
        /// </summary>
        public List<IHero> ActiveHeroes
        {
            get
            {
                var heroes = new List<IHero>();
                foreach (var heroObject in activeHeroes)
                {
                    var activeHero = heroObject as IHero;
                    heroes.Add(activeHero);
                }
                return heroes;
            }
        }
        
        /// <summary>
        /// Reference to sort heroes by energy
        /// </summary>
        public ISortHeroesByEnergy SortHeroesByEnergy { get; private set; }
        
        /// <summary>
        /// Updates all living heroes' hero timers
        /// </summary>
        public IUpdateHeroTimers UpdateHeroTimers { get; private set; }

        private void Awake()
        {
            SortHeroesByEnergy = GetComponent<ISortHeroesByEnergy>();
            UpdateHeroTimers = GetComponent<IUpdateHeroTimers>();
        }
        
        /// <summary>
        /// First time combat start
        /// </summary>
        public void StartBattle()
        {

            var logicTree = this.CoroutineTrees.MainLogicTree;
            logicTree.AddCurrent(StartHeroTimers());
            
        }
        
        private IEnumerator StartHeroTimers()
        {
            var logicTree = this.CoroutineTrees.MainLogicTree;
            logicTree.AddCurrent(RunHeroTimers());
            
            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator RunHeroTimers()
        {
            var logicTree = this.CoroutineTrees.MainLogicTree;
            
            ActiveHeroFound = false;
            
            //Run all hero timers to find next active hero/heroes
            while (!ActiveHeroFound)
            {
                UpdateHeroTimers.StartAction();
                yield return null;
            }
            
            //Start the next active hero
            logicTree.AddCurrent(SetCurrentActiveHero());

            logicTree.EndSequence();
            yield return null;
        }
        
        
        private IEnumerator SetCurrentActiveHero()  //possible state?
        {
            var logicTree = this.CoroutineTrees.MainLogicTree;
            
            //Sort the heroes (random sort for heroes with equal energy)
            SortHeroesByEnergy.StartAction();
            
            //Set the current active hero
            CurrentActiveHero = ActiveHeroes[ActiveHeroes.Count - 1];
            
            //Remove the current active hero from the hero active heroes list
            ActiveHeroesList.Remove(CurrentActiveHero as Object);
            
            //Set the current hero's active status to "ActiveHero"
            CurrentActiveHero.HeroLogic.SetHeroActiveStatus.ActiveHero();
            
            //Reset the energy of the current active hero
            CurrentActiveHero.HeroLogic.SetEnergy.ResetToZero();
            
            //TODO: Event call - EventCombatStartTurn

            logicTree.EndSequence();
            yield return null;
        }

    }
}