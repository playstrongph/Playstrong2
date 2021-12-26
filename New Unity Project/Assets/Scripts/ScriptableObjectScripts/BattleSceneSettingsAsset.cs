using AssetsScriptableObjects;
using JondiBranchLogic;
using Logic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScriptableObjectScripts
{
    [CreateAssetMenu(fileName = "BattleSceneSettings", menuName = "Assets/BattleSceneGeneral/BattleSceneSettings")]
    public class BattleSceneSettingsAsset : ScriptableObject, IBattleSceneSettingsAsset
    {
        #region PREFABS

        /// <summary>
        /// Reference for instantiating turn controller prefab
        /// </summary>
        [Header("BATTLE SCENE PREFABS")]
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ITurnController))]
        private Object turnController;
        public ITurnController TurnController
        {
            get => turnController as TurnController;
            private set => turnController = value as Object;
        }
        
        /// <summary>
        /// Reference to the game board prefab
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IGameBoard))]
        private Object gameBoard;
        public IGameBoard GameBoard
        {
            get => gameBoard as IGameBoard;
            private set => gameBoard = value as Object;
        }

        /// <summary>
        /// Reference to player prefab
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IPlayer))]
        private Object playerPrefab;
        public IPlayer PlayerPrefab
        {
            get => playerPrefab as IPlayer;
            private set => playerPrefab = value as Object;
        }
        
        

        /// <summary>
        /// Reference to hero prefab
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHero))]
        private Object heroPrefab;
        public IHero HeroPrefab
        {
            get => heroPrefab as IHero;
            private set => heroPrefab = value as Object;
        }
        
        /// <summary>
        /// Reference to skill prefab
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkill))]
        private Object skillPrefab;
        public ISkill SkillPrefab
        {
            get => skillPrefab as ISkill;
            private set => skillPrefab = value as Object;
        }
        
        /// <summary>
        /// Reference to hero skills prefab
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroSkills))]
        private Object heroSkillsPrefab;
        public IHeroSkills HeroSkillsPrefab
        {
            get => heroSkillsPrefab as IHeroSkills;
            private set => heroSkillsPrefab = value as Object;
        }
        
        /// <summary>
        /// Reference to portrait
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroPortrait))]
        private Object heroPortraitPrefab;
        public IHeroPortrait HeroPortraitPrefab
        {
            get => heroPortraitPrefab as IHeroPortrait;
            private set => heroPortraitPrefab = value as Object;
        }
        
        /// <summary>
        /// End turn button prefab 
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IEndTurnButton))]
        private Object endTurnButtonPrefab;
        public IEndTurnButton EndTurnButtonPrefab
        {
            get => endTurnButtonPrefab as IEndTurnButton;
            private set => endTurnButtonPrefab = value as Object;
        }


        #endregion
        
        

        /// <summary>
        /// Board location of ally heroes
        /// </summary>
        [Header("BATTLE SCENE TRANSFORMS")] 
        
        [SerializeField] private Vector3 allyHeroesPosition;

        public Vector3 AllyHeroesPosition
        {
            get => allyHeroesPosition;
            private set => allyHeroesPosition = value;
        }

        /// <summary>
        /// Board location of enemy heroes
        /// </summary>
        [SerializeField] private Vector3 enemyHeroesPosition;
        public Vector3 EnemyHeroesPosition
        {
            get => enemyHeroesPosition;
            private set => enemyHeroesPosition = value;
        }
        
        /// <summary>
        /// Board location of hero skills
        /// </summary>
        [SerializeField] private Vector3 skillsPosition;
        public Vector3 SkillsPosition
        {
            get => skillsPosition;
            private set => skillsPosition = value;
        }

        /// <summary>
        /// Board location of display hero skills
        /// </summary>
        [SerializeField] private Vector3 displaySkillsPosition;

        public Vector3 DisplaySkillsPosition
        {
            get => displaySkillsPosition;
            private set => displaySkillsPosition = value;
        }

        /// <summary>
        /// Board location of hero portraits
        /// </summary>
        [SerializeField] private Vector3 portraitPosition;

        public Vector3 PortraitPosition
        {
            get => portraitPosition;
            private set => portraitPosition = value;
        }

        /// <summary>
        /// Board location of displayed hero portraits
        /// </summary>
        [SerializeField] private Vector3 displayPortraitPosition;
        public Vector3 DisplayPortraitPosition
        {
            get => displayPortraitPosition;
            private set => displayPortraitPosition = value;
        }

        /// <summary>
        /// Board location of skill previews
        /// </summary>
        [SerializeField] private Vector3 skillPreviewPosition;
        public Vector3 SkillPreviewPosition
        {
            get => skillPreviewPosition;
            private set => skillPreviewPosition = value;
        }

        /// <summary>
        /// Board location of hero previews
        /// </summary>
        [SerializeField] private Vector3 heroPreviewPosition;

        public Vector3 HeroPreviewPosition
        {
            get => heroPreviewPosition;
            private set => heroPreviewPosition = value;
        }       
        
        /// <summary>
        /// End turn button board position
        /// </summary>
        [SerializeField] private Vector3 endTurnButtonPosition;
        public Vector3 EndTurnButtonPosition
        {
            get => endTurnButtonPosition;
            private set => endTurnButtonPosition = value;
        }

        /// <summary>
        /// Reference to coroutine trees asset
        /// </summary>
        [Header("BATTLE SCENE ASSETS")]
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ICoroutineTreesAsset))] 
        private CoroutineTreesAsset coroutineTreesAsset;
        public CoroutineTreesAsset CoroutineTreesAsset
        {
            get => coroutineTreesAsset;
            private set => coroutineTreesAsset = value;
        }
        
        /// <summary>
        /// Reference to main player team heroes asset
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ITeamHeroesAsset))] 
        private Object mainPlayerTeamHeroes;
        public ITeamHeroesAsset MainPlayerTeamHeroes
        {
            get => mainPlayerTeamHeroes as ITeamHeroesAsset;
            private set => mainPlayerTeamHeroes = value as Object;
        }
        
        /// <summary>
        /// Reference to enemy player team heroes asset
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ITeamHeroesAsset))] 
        private Object enemyPlayerTeamHeroes;
        public ITeamHeroesAsset EnemyPlayerTeamHeroes
        {
            get => enemyPlayerTeamHeroes as ITeamHeroesAsset;
            private set => enemyPlayerTeamHeroes = value as Object;
        }






    }
}
