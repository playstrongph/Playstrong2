namespace Logic
{
    public interface ISetHeroActiveStatus
    {
        /// <summary>
        /// Sets the hero's active status to "ActiveHero" 
        /// </summary>
        void ActiveHero();

        /// <summary>
        /// Sets the hero's active status to "InactiveHero"
        /// </summary>
        void InactiveHero();
    }
}