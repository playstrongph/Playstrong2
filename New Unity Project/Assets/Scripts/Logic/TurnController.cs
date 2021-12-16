using System.Collections.Generic;
using JondiBranchLogic;
using UnityEngine;

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
        [SerializeField] private bool freezeTimers = false;
        public bool FreezeTimers
        {
            get => freezeTimers;
            set => freezeTimers = value;
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
        /// List of active heroes
        /// Displayed in inspector for debugging purposes
        /// </summary>
        [Header("SET IN RUNTIME")]
        [SerializeField] 
        private List<Object> activeHeroes = new List<Object>();
        
        /// <summary>
        /// Used for adding heroes to the active heroes list 
        /// </summary>
        public List<Object> ActiveHeroesList => activeHeroes;

        /// <summary>
        /// Returns list of active heroes
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


        public void StartGame()
        {
            
        }

    }
}
