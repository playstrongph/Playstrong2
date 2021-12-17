using System;
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
        /// Hero attributes reference
        /// </summary>
        public IHeroAttributes HeroAttributes { get; private set; }

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
        

        private void Awake()
        {
            HeroAttributes = GetComponent<IHeroAttributes>();
            SetAttack = GetComponent<ISetAttack>();
            SetArmor = GetComponent<ISetArmor>();
            SetSpeed = GetComponent<ISetSpeed>();
            SetHealth = GetComponent<ISetHealth>();
            SetChance = GetComponent<ISetChance>();
            SetFightingSpirit = GetComponent<ISetFightingSpirit>();
            SetEnergy = GetComponent<ISetEnergy>();
            LoadHeroAttributes = GetComponent<ILoadHeroAttributes>();
            HeroTimer = GetComponent<IHeroTimer>();
        }
    }
}
