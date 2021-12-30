namespace Logic
{
    public interface IOtherSkillAttributes
    {
        /// <summary>
        /// If value is less than or equal to zero, skill can't be used
        /// Used by disable skill effects such as silence and seal
        /// </summary>
        int UsableSkillFactor { get; set; }
        
        /// <summary>
        /// Special counters used in specific skills
        /// </summary>
        int SkillCounters { get; set; }
    }
}