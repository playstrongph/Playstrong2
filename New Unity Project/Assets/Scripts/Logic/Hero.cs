using System;
using JetBrains.Annotations;
using JondiBranchLogic;
using ScriptableObjectScripts;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Logic
{
    /// <summary>
    /// Hero prefab reference 
    /// </summary>
    public class Hero : MonoBehaviour, IHero
    {
        /// <summary>
        /// HeroLogic Reference
        /// Set not used but is scripted to avoid null warnings
        /// </summary>
        [Header("SET IN INSPECTOR")]
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroLogic))]
        private Object heroLogic;
        public IHeroLogic HeroLogic
        {
            get => heroLogic as IHeroLogic;
            set => heroLogic = value as Object;
        }
        
        /// <summary>
        /// Hero visual reference
        /// Set in Inspector
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroVisual))]
        private Object heroVisual;
        public IHeroVisual HeroVisual
        {
            get => heroVisual as IHeroVisual;
            set => heroVisual = value as Object;
        }
        
        /// <summary> 
        /// Hero status effects reference
        /// Set in Inspector
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroStatusEffects))]
        private Object heroStatusEffects;
        public IHeroStatusEffects HeroStatusEffects
        {
            get => heroStatusEffects as IHeroStatusEffects;
            set => heroStatusEffects = value as Object;
        }
        
        /// <summary>
        /// Hero preview reference
        /// set in Inspector
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroPreview))]
        private Object heroPreview;
        public IHeroPreview HeroPreview
        {
            get => heroPreview as IHeroPreview;
            set => heroPreview = value as Object;
        }

        /// <summary>
        /// target Collider (Box Collider) reference
        /// set in Inspector
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ITargetCollider))]
        private Object targetCollider;
        public ITargetCollider TargetCollider
        {
            get => targetCollider as ITargetCollider;
            set => targetCollider = value as Object;
        }
        
        /// <summary>
        /// CoroutineTrees asset reference
        /// set in Inspector
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ICoroutineTreesAsset))]
        private Object coroutineTrees;
        public ICoroutineTreesAsset CoroutineTrees
        {
            get => coroutineTrees as ICoroutineTreesAsset;
            set => coroutineTrees = value as Object;
        }



        /// <summary>
        /// TODO: To be recoded to return list of heroSkills
        /// </summary>
        [Header("SET IN RUNTIME")]
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkillsAllHeroes))]
        private Object heroSkills;
        public ISkillsAllHeroes HeroSkills
        {
            get => heroSkills as ISkillsAllHeroes;
            set => heroSkills = value as Object;
        }

        /// <summary>
        /// Hero Portrait
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroPortrait))]
        private Object heroPortrait;
        public IHeroPortrait HeroPortrait
        {
            get => heroPortrait as IHeroPortrait;
            set => heroPortrait = value as Object;
        }
        
        /// <summary>
        /// Information Panel Hero Portrait
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IDisplayPortraits))]
        private Object panelHeroPortrait;
        public IDisplayPortraits PanelHeroPortrait
        {
            get => panelHeroPortrait as IDisplayPortraits;
            set => panelHeroPortrait = value as Object;
        }
        
        /// <summary>
        /// Panel Hero Skills
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IDisplaySkills))]
        private Object panelSkills;
        public IDisplaySkills PanelSkills
        {
            get => panelSkills as IDisplaySkills;
            set => panelSkills = value as Object;
        }
        
        /// <summary>
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;

        /// <summary>
        /// The player this hero belongs to
        /// </summary>
        public IPlayer Player { get; set; }

        /// <summary>
        /// Initialize hero portrait reference
        /// </summary>
        public IInitializeHeroPortrait InitializeHeroPortrait { get; private set; }

        private void Awake()
        {
            InitializeHeroPortrait = GetComponent<IInitializeHeroPortrait>();
        }
    }
}
