namespace Logic
{
    public interface ISetHeroFrameAndGlow
    {
        IHeroFrameAndGlow CurrentHeroFrame { get; set; }

        /// <summary>
        /// Taunt setting for the current hero frame and glows
        /// </summary>
        void SetTauntFrame();

        /// <summary>
        /// Normal setting for the current hero frame and glows
        /// </summary>
        void SetNormalFrame();
    }
}