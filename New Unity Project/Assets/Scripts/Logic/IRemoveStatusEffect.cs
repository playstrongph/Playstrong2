namespace Logic
{
    public interface IRemoveStatusEffect
    {
        /// <summary>
        /// Removes and destroys the status effect
        /// </summary>
        /// <param name="hero"></param>
        void StartAction(IHero hero);
    }
}