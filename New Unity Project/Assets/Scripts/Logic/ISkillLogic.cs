﻿namespace Logic
{
    public interface ISkillLogic
    {
        /// <summary>
        /// Interface reference to skill
        /// </summary>
        ISkill Skill { get; }
        
        /// <summary>
        /// Contains the skill properties such as cooldown, skill type, etc.
        /// </summary>
        ISkillAttributes SkillAttributes { get; }
        
        /// <summary>
        /// Loads the skill attributes from the skill asset
        /// </summary>
        ILoadSkillAttributes LoadSkillAttributes { get; }
    }
}