namespace Logic
{
    public interface IDisplayedPortraitAndSkills
    {
        /// <summary>
        /// Current displayed heroPortrait
        /// </summary>
        IHeroPortrait DisplayedHeroPortrait { get; set; }

        /// <summary>
        /// Current displayed hero skills 
        /// </summary>
        IHeroSkills DisplayedHeroSkills { get; set; }
    }
}