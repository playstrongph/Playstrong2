namespace Logic
{
    public interface IHeroTargetCollider
    {
        /// <summary>
        /// Interface reference to Hero
        /// </summary>
        IHero Hero { get; }
        
        /// <summary>
        /// Reference to Display Hero Preview script
        /// </summary>
        IDisplayHeroPreview DisplayHeroPreview { get; }
        
        /// <summary>
        /// Hero that targeted this hero
        /// </summary>
        IHero TargetingHero { get; set; }
        
        /// <summary>
        /// Hero this hero targeted
        /// </summary>
        IHero TargetedHero { get; set; }
    }
}