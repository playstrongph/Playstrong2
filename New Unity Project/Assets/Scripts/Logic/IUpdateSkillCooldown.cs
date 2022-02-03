namespace Logic
{
    public interface IUpdateSkillCooldown
    {
        /// <summary>
        /// Decreases cooldown based on the skill cooldown type
        /// </summary>
        /// <param name="counter"></param>
        void DecreaseCooldown(int counter);

        /// <summary>
        /// Increases cooldown based on the skill cooldown type
        /// </summary>
        /// <param name="counter"></param>
        void IncreaseCooldown(int counter);

        /// <summary>
        /// Set cooldown to value based on the skill cooldown type
        /// </summary>
        /// <param name="value"></param>
        void SetCooldownToValue(int value);

        /// <summary>
        /// Set cooldown to max value based on the skill cooldown type
        /// </summary>
        void ResetCooldownToMax();

        /// <summary>
        /// Refreshes cooldown based on the skill cooldown type
        /// </summary>
        void RefreshCooldownToZero();

        /// <summary>
        /// Reduces skill cooldown at the end of the turn,
        /// except for passive skills (with no cooldown)
        /// </summary>
        /// <param name="counter"></param>
        void TurnControllerReduceCooldown(int counter = 1);

        /// <summary>
        /// Resets the cooldown after skill use
        /// except for passive skills (with no cooldown)
        /// </summary>
        void UseSkillResetCooldown();
        
        /// <summary>
        /// Checks and updates the skill readiness status during the hero's start turn.
        /// E.g. - refresh skill target of another ally on another turn
        /// </summary>
        void UpdateSkillReadiness();
    }
}