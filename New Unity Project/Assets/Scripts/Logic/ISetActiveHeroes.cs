namespace Logic
{
    public interface ISetActiveHeroes
    {
        /// <summary>
        /// Add hero to the turn controller's active heroes list
        /// </summary>
        /// <param name="hero"></param>
        void AddHero(IHero hero);

        /// <summary>
        /// Remove hero from the turn controller's active heroes list
        /// </summary>
        /// <param name="hero"></param>
        void RemoveHero(IHero hero);
    }
}