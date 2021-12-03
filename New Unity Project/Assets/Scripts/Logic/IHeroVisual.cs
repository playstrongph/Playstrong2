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
        /// Interface reference to hero
        /// graphic canvas
        /// </summary>
        Canvas HeroGraphicCanvas { get; }

    }
}