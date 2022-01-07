using ScriptableObjectScripts.HeroActiveStatusAssets;
using ScriptableObjectScripts.HeroInabilityStatusAssets;
using ScriptableObjectScripts.HeroLifeStatusAssets;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Logic
{
    public class HeroLogic : MonoBehaviour, IHeroLogic
    {
        /// <summary>
        /// Reference to Hero where other
        /// components can be accessed
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHero))]
        private Object hero;
        public IHero Hero
        {
            get => hero as IHero;
            set => hero = value as Object;
        }
        
        /// <summary>
        /// Hero active or inactive status
        /// </summary>
        [Header("HERO STATUSES")]
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroActiveStatusAsset))]
        private ScriptableObject heroActiveStatus;

        public IHeroActiveStatusAsset HeroActiveStatus
        {
            get => heroActiveStatus as IHeroActiveStatusAsset;
            set => heroActiveStatus = value as ScriptableObject;
        }
        
        /// <summary>
        /// Hero has inability or no inability (stun, sleep, etc.)
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroInabilityStatusAsset))]
        private ScriptableObject heroInabilityStatus;

        public IHeroInabilityStatusAsset HeroInabilityStatus
        {
            get => heroInabilityStatus as IHeroInabilityStatusAsset;
            set => heroInabilityStatus = value as ScriptableObject;
        }
        
        /// <summary>
        /// Hero is alive or dead
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroLifeStatusAsset))]
        private ScriptableObject heroLifeStatus;
        public IHeroLifeStatusAsset HeroLifeStatus
        {
            get => heroLifeStatus as IHeroLifeStatusAsset;
            set => heroLifeStatus = value as ScriptableObject;
        }

        #region COMPONENT REFERENCES

        /// <summary>
        /// Hero attributes reference
        /// </summary>
        public IHeroAttributes HeroAttributes { get; private set; }
        
        /// <summary>
        /// Reference to the hero's resistance attributes
        /// </summary>
        public IResistanceAttributes ResistanceAttributes { get; private set; }
        
        /// <summary>
        /// Reference to the hero's chance attributes
        /// </summary>
        public IChanceAttributes ChanceAttributes { get; private set; }

        /// <summary>
        /// Set attack reference
        /// </summary>
        public ISetAttack SetAttack { get; private set; }
        
        /// <summary>
        /// Set armor reference
        /// </summary>
        public ISetArmor SetArmor { get; private set; }
        
        /// <summary>
        /// Set armor reference
        /// </summary>
        public ISetSpeed SetSpeed { get; private set; }
        
        /// <summary>
        /// Set health reference
        /// </summary>
        public ISetHealth SetHealth { get; private set; }
        
        /// <summary>
        /// Set chance reference
        /// </summary>
        public ISetChance SetChance { get; private set; }
        
        /// <summary>
        /// Set fighting spirit reference
        /// </summary>
        public ISetFightingSpirit SetFightingSpirit { get; private set; }
        
        /// <summary>
        /// Set energy reference
        /// </summary>
        public ISetEnergy SetEnergy { get; private set; }

        /// <summary>
        /// Loads the hero prefab attributes from the hero asset
        /// </summary>
        public ILoadHeroAttributes LoadHeroAttributes { get; private set; }
        
        /// <summary>
        /// Access to the hero's energy via hero timers
        /// </summary>
        public IHeroTimer HeroTimer { get; private set; }
        
        /// <summary>
        /// Sets the hero's active status to either "ActiveHero" or "InactiveHero"
        /// </summary>
        public ISetHeroActiveStatus SetHeroActiveStatus { get; private set; }
        
        /// <summary>
        /// Sets the hero's/other hero's targeted/targeting hero 
        /// </summary>
        public ILastHeroTargets LastHeroTargets { get; private set; }
        
        /// <summary>
        /// Reference to hero events
        /// </summary>
        public IHeroEvents HeroEvents { get; private set; }
        
        

        #endregion

        private void Awake()
        {
            HeroAttributes = GetComponent<IHeroAttributes>();
            ResistanceAttributes = GetComponent<IResistanceAttributes>();
            ChanceAttributes = GetComponent<IChanceAttributes>();
            SetAttack = GetComponent<ISetAttack>();
            SetArmor = GetComponent<ISetArmor>();
            SetSpeed = GetComponent<ISetSpeed>();
            SetHealth = GetComponent<ISetHealth>();
            SetChance = GetComponent<ISetChance>();
            SetFightingSpirit = GetComponent<ISetFightingSpirit>();
            SetEnergy = GetComponent<ISetEnergy>();
            LoadHeroAttributes = GetComponent<ILoadHeroAttributes>();
            HeroTimer = GetComponent<IHeroTimer>();
            SetHeroActiveStatus = GetComponent<ISetHeroActiveStatus>();
            LastHeroTargets = GetComponent<ILastHeroTargets>();
            HeroEvents = GetComponent<IHeroEvents>();
        }
    }
}