namespace Logic
{
    public interface IUpdateSkillReadiness
    {
        /// <summary>
        /// Set skill status to 'Ready' and execute status actions
        /// </summary>
        void SetSkillReady();

        /// <summary>
        /// Set skill status to 'Not Ready' and execute status actions
        /// </summary>
        void SetSkillNotReady();
    }
}