namespace Logic
{
    public interface IHeroDies
    {
        /// <summary>
        /// Checks if fatal damage kills hero 
        /// </summary>
        /// <param name="hero"></param>
        void CheckFatalDamage(IHero hero);
    }
}