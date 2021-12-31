namespace Logic
{
    public interface IUpdateSkillEnableStatus
    {
        /// <summary>
        /// Method used by 'Silence' and similar effects
        /// </summary>
        void DisableActiveSkill();

        /// <summary>
        ///Method used by 'Silence' and similar effects
        /// </summary>
        void EnableActiveSkill();
        
        /// <summary>
        /// Method used by 'Seal' and similar effects
        /// </summary>
        void DisablePassiveSkill();
        
        /// <summary>
        /// Method used by 'Seal' and similar effects
        /// </summary>
        void EnablePassiveSkill();
    }
}