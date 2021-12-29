namespace Logic
{
    public interface ISkillGlowDisplay
    {
        /// <summary>
        /// Shows the green skill glow when skill is available for use
        /// </summary>
        void ShowGlow();

        /// <summary>
        /// Hides the green skill glow when skill is available for use
        /// </summary>
        void HideGlow();
    }
}