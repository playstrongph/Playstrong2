using ScriptableObjectScripts.HeroActiveStatusAssets;
using ScriptableObjectScripts.HeroInabilityStatusAssets;
using ScriptableObjectScripts.HeroLifeStatusAssets;

namespace Logic
{
    public interface IHeroLogic
    {   
        /// <summary>
        /// Interface reference to Hero
        /// </summary>
        IHero Hero { get; }
        
        /// <summary>
        /// Hero active or inactive status
        /// </summary>
        IHeroActiveStatusAsset HeroActiveStatus { get; set; }

        IHeroInabilityStatusAsset HeroInabilityStatus { get; set; }

        IHeroLifeStatusAsset HeroLifeStatus { get; set; }

        #region COMPONENT REFERENCES

        /// <summary>
        /// Hero attributes reference
        /// </summary>
        IHeroAttributes HeroAttributes { get; }
        
        /// <summary>
        /// Other hero attributes reference
        /// </summary>
        IResistanceAttributes ResistanceAttributes { get; }
        
        /// <summary>
        /// Reference to the hero's chance attributes
        /// </summary>
        IChanceAttributes ChanceAttributes { get;  }
        
        /// <summary>
        /// Reference to the hero's damage factors 
        /// </summary>
        IDamageAttributes DamageAttributes { get; }

        /// <summary>
        /// Set attack reference
        /// </summary>
        ISetAttack SetAttack { get; }
        
        /// <summary>
        /// Set attack reference
        /// </summary>
        ISetArmor SetArmor { get; }
        
        /// <summary>
        /// Set speed reference
        /// </summary>
        ISetSpeed SetSpeed { get; }
        
        /// <summary>
        /// Set health reference
        /// </summary>
        ISetHealth SetHealth { get; }
        
        /// <summary>
        /// Set chance reference
        /// </summary>
        ISetChance SetChance { get; }
        
        /// <summary>
        /// Set fighting spirit reference
        /// </summary>
        ISetFightingSpirit SetFightingSpirit { get; }
        
        /// <summary>
        /// Set energy reference
        /// </summary>
        ISetEnergy SetEnergy { get; }

        /// <summary>
        /// Loads the hero prefab attributes from the hero asset
        /// </summary>
        ILoadHeroAttributes LoadHeroAttributes { get; }
        
        /// <summary>
        /// Access to the hero's energy via hero timers
        /// </summary>
        IHeroTimer HeroTimer { get; }
        
        /// <summary>
        /// Sets the hero's active status to either "ActiveHero" or "InactiveHero"
        /// </summary>
        ISetHeroActiveStatus SetHeroActiveStatus { get; }

        /// <summary>
        /// Reference to hero events
        /// </summary>
        IHeroEvents HeroEvents { get; }
        
        /// <summary>
        /// Reference to deal damage
        /// </summary>
        IDealDamage DealDamage { get; }
        
        /// <summary>
        /// Reference to take damage
        /// </summary>
        ITakeDamage TakeDamage { get; }

        #endregion
    }
}