using UnityEngine;

namespace Logic
{
    public interface IHeroVisual
    {
        /// <summary>
        /// Interface reference to Hero
        /// </summary>
        IHero Hero { get; }
        
        /// <summary>
        /// Graphic canvas to hide or
        /// show the hero
        /// </summary>
        Canvas HeroGraphicCanvas { get; }
        
        /// <summary>
        /// Taunt frame object
        /// </summary>
        ITauntFrame TauntFrame { get; }
        
        /// <summary>
        /// Normal frame object
        /// </summary>
        INormalFrame NormalFrame { get; }

        /// <summary>
        /// Hero graphic image
        /// </summary>
        IHeroGraphic HeroGraphic { get; }
        
        /// <summary>
        /// Attack visual text
        /// </summary>
        IAttackVisual AttackVisual { get; }
        
        /// <summary>
        /// Health visual text
        /// </summary>
        IHealthVisual HealthVisual { get; }
        
        /// <summary>
        /// Armor visual text
        /// </summary>
        IArmorVisual ArmorVisual { get; }
        
        /// <summary>
        /// Energy visual text
        /// </summary>
        IEnergyVisual EnergyVisual { get; }
        
        /// <summary>
        /// Fighting spirit visual text
        /// </summary>
        IFightingSpiritVisual FightingSpiritVisual { get; }

    }
}