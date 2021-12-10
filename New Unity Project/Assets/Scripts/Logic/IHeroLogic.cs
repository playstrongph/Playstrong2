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
        
        /// <summary>
        /// Set attack reference
        /// </summary>
        ISetAttack SetAttack { get; }
        
        /// <summary>
        /// Set attack reference
        /// </summary>
        ISetArmor SetArmor { get; }
    }
}