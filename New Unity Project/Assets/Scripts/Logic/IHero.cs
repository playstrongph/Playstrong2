namespace Logic
{
    public interface IHero
    {
        /// <summary>
        /// Interface access to heroLogic
        /// "Set" parameter is not used
        /// </summary>
        IHeroLogic HeroLogic { get; }
        
        /// <summary>
        /// Interface access to HeroVisual
        /// "Set" parameter is not used
        /// </summary>
        IHeroVisual HeroVisual { get; }


        /// <summary>
        /// Interface access to list of heroSkills
        /// </summary>
        IHeroSkills HeroSkills { get; set; }
        
        /// <summary>
        /// Interface access to list of statusEffects
        /// </summary>
        IStatusEffects StatusEffects { get; set; }


    }
}