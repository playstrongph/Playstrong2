using System;
using JondiBranchLogic;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Logic
{
    public class Player : MonoBehaviour, IPlayer
    {
        
        /// <summary>
        /// Reference to AliveHeroes
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IAliveHeroes))]
        private Object aliveHeroes;
        public IAliveHeroes AliveHeroes
        {
            get => aliveHeroes as IAliveHeroes;
            set => aliveHeroes = value as Object;
        }
        
        /// <summary>
        /// Reference to dead heroes
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IDeadHeroes))]
        private Object deadHeroes;
        public IDeadHeroes DeadHeroes
        {
            get => deadHeroes as IDeadHeroes;
            set => deadHeroes = value as Object;
        }

        /// <summary>
        /// Reference access to hero skills
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkillsAllHeroes))]
        private Object skillsAllHeroes;

        public ISkillsAllHeroes SkillsAllHeroes
        {
            get => skillsAllHeroes as ISkillsAllHeroes;
            set => skillsAllHeroes = value as Object;
        }
        
        /// <summary>
        /// Reference access to portraits
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IPortraits))]
        private Object portraits;
        public IPortraits Portraits
        {
            get => portraits as IPortraits;
            set => portraits = value as Object;
        }
        
        /// <summary>
        /// Reference access to display skills
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IDisplaySkills))]
        private Object displaySkills;
        public IDisplaySkills DisplaySkills
        {
            get => displaySkills as IDisplaySkills;
            set => displaySkills = value as Object;
        }
        
        /// <summary>
        /// Reference access to display portraits
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IDisplayPortraits))]
        private Object displayPortraits;
        public IDisplayPortraits DisplayPortraits
        {
            get => displayPortraits as IDisplayPortraits;
            set => displayPortraits = value as Object;
        }
        
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroAndSkillPreviews))]
        private Object heroAndSkillPreviews;

        public IHeroAndSkillPreviews HeroAndSkillPreviews
        {
            get => heroAndSkillPreviews as IHeroAndSkillPreviews;
            private set => heroAndSkillPreviews = value as Object;
        }
        
        /// <summary>
        /// Global Main and Visual trees reference
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ICoroutineTreesAsset))]private Object coroutineTrees;
        public ICoroutineTreesAsset CoroutineTrees
        {
            get => coroutineTrees as ICoroutineTreesAsset;
            private set => coroutineTrees = value as Object;

        }

        //RUNTIME VARIABLES

        /// <summary>
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;
        
        /// <summary>
        /// Initialize player heroes component reference
        /// </summary>
        private IInitializePlayerHeroes _initializePlayerHeroes;
        public IInitializePlayerHeroes InitializePlayerHeroes => _initializePlayerHeroes;

        /// <summary>
        /// Reference to BattleSceneManager.
        /// Set in runtime. 
        /// </summary>
        public IBattleSceneManager BattleSceneManager { get; set; }

        /// <summary>
        /// The enemy of the current player
        /// </summary>
        public IPlayer OtherPlayer { get; set; }



        private void Awake()
        {
            _initializePlayerHeroes = GetComponent<IInitializePlayerHeroes>();

        }
    }
}
