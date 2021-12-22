﻿using System.Collections;
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
        public IHero CurrentActiveHero
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
        
        /// <summary>
        /// Sets the current active hero
        /// </summary>
        public ISetCurrentActiveHero SetCurrentActiveHero { get; private set; }
        
        /// <summary>
        /// Before hero starts the turn actions
        /// </summary>
        public IBeforeHeroStartTurn BeforeHeroStartTurn { get; private set; }

        private void Awake()
        {
            SortHeroesByEnergy = GetComponent<ISortHeroesByEnergy>();
            UpdateHeroTimers = GetComponent<IUpdateHeroTimers>();
            SetCurrentActiveHero = GetComponent<ISetCurrentActiveHero>();
            BeforeHeroStartTurn = GetComponent<IBeforeHeroStartTurn>();
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
            
            //CALL NEXT PHASE
            logicTree.AddCurrent(SetCurrentActiveHero.StartAction());

            logicTree.EndSequence();
            yield return null;
        }


    }
}