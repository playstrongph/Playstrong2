namespace Logic
{
    public interface ILastHeroTargets
    {
        /// <summary>
        /// The last hero targeted by this hero
        /// </summary>
        IHero TargetedHero { get; }

        /// <summary>
        /// Last hero who targeted this hero
        /// </summary>
        IHero TargetingHero { get; }

        /// <summary>
        /// Set targeted hero 
        /// </summary>
        /// <param name="hero"></param>
        void SetTargetedHero(IHero hero);

        /// <summary>
        /// Set targeting hero
        /// </summary>
        /// <param name="hero"></param>
        void SetTargetingHero(IHero hero);
    }
}