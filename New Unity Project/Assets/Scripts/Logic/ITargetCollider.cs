public interface ITargetCollider
{
    /// <summary>
    /// Interface reference to Hero
    /// </summary>
    IHero Hero { get; }
        
    /// <summary>
    /// Reference to Display Hero Preview script
    /// </summary>
    IDisplayHeroPreview DisplayHeroPreview { get; }
}