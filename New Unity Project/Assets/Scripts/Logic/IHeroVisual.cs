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
        IHeroFrameAndGlow TauntFrame { get; }
        
        /// <summary>
        /// Normal frame object
        /// </summary>
        IHeroFrameAndGlow NormalFrame { get; }

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
        
        /// <summary>
        /// Loads the hero visual components
        /// </summary>
        ILoadHeroVisuals LoadHeroVisuals { get; }
        
        /// <summary>
        /// Returns the current hero frame and glow setting or change it
        /// to either Taunt or Normal frame.
        /// </summary>
        ISetHeroFrameAndGlow SetHeroFrameAndGlow { get; }
        
        /// <summary>
        /// Set the armor text
        /// Hide and show armor icon
        /// </summary>
        ISetArmorVisual SetArmorVisual { get;}
        
        /// <summary>
        /// Set the attack text and color
        /// </summary>
        ISetAttackVisual SetAttackVisual { get; }
        
        /// <summary>
        /// Set the health text and color
        /// </summary>
        ISetHealthVisual SetHealthVisual { get; }
        
        /// <summary>
        /// Set the fighting spirit, show and hide icon
        /// </summary>
        ISetFightingSpiritVisual SetFightingSpiritVisual { get; }
        
        /// <summary>
        /// Sets the energy text, fill, and color
        /// </summary>
        ISetEnergyVisual SetEnergyVisual { get; }
        
        /// <summary>
        /// Sets the energy text and fill color based on changes in speed
        /// </summary>
        ISetSpeedVisual SetSpeedVisual { get;}

    }
}