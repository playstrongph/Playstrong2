namespace Logic
{
    public interface IPlayer
    {
        /// <summary>
        /// Interface access to alive heroes
        /// </summary>
        IAliveHeroes AliveHeroes { get; }
        
        /// <summary>
        /// Interface access to dead heroes
        /// </summary>
        IDeadHeroes DeadHeroes { get; }
        
        /// <summary>
        /// Interface access to hero skills
        /// </summary>
        IAllHeroSkills HeroSkills { get; }
        
        /// <summary>
        /// Interface access to portraits
        /// </summary>
        IPortraits Portraits { get; }

        /// <summary>
        /// Interface access to display skill
        /// </summary>
        IDisplaySkills DisplaySkills { get; }

        /// <summary>
        /// Interface access to display portraits
        /// </summary>
        IDisplayPortraits DisplayPortraits { get; }



    }
}