namespace Logic
{
    public interface ISkillLogic
    {
        /// <summary>
        /// Interface reference to skill
        /// </summary>
        ISkill Skill { get; }
        
        /// <summary>
        /// Reference to skill attributes
        /// </summary>
        ISkillAttributes SkillAttributes { get; }
    }
}