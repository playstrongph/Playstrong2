namespace Logic
{
    public interface IHeroLogic
    {   
        /// <summary>
        /// Interface reference to Hero
        /// </summary>
        IHero Hero { get; }
        
        /// <summary>
        /// Hero attributes reference
        /// </summary>
        IHeroAttributes HeroAttributes { get; }
    }
}