using System;
using Logic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScriptableObjectScripts
{
    [CreateAssetMenu(fileName = "BattleSceneSettings", menuName = "Assets/BattleSceneGeneral/BattleSceneSettings")]
    public class BattleSceneSettingsAsset : ScriptableObject, IBattleSceneSettingsAsset
    {
        
        
        
        /// <summary>
        /// Reference to player prefab
        /// </summary>
        [Header("BATTLE SCENE PREFABS")]
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
        private Object heroSkills;
        public IHeroSkills HeroSkills
        {
            get => heroSkills as IHeroSkills;
            private set => heroSkills = value as Object;
        }
        
        /// <summary>
        /// Reference to portrait
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IPortrait))]
        private Object heroPortrait;
        public IPortrait HeroPortrait
        {
            get => heroPortrait as IPortrait;
            private set => heroPortrait = value as Object;
        }

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
        /// Reference to battle scene manager 
        /// </summary>
        [Header("SET IN RUNTIME")]
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IBattleSceneManager))]
        private Object battleSceneManager;
        public IBattleSceneManager BattleSceneManager
        {
            get => battleSceneManager as IBattleSceneManager;
            set => battleSceneManager = value as Object;
        }

        
    }
}
