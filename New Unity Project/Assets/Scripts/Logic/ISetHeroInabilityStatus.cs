namespace Logic
{
    public interface ISetHeroInabilityStatus
    {
        /// <summary>
        /// Sets the hero inability status to "HasInability"
        /// </summary>
        void HasInability();

        /// <summary>
        /// Sets the hero inability status to "NoInability"
        /// </summary>
        void NoInability();
    }
}