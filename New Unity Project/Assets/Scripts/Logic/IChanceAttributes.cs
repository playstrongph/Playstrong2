namespace Logic
{
    public interface IChanceAttributes
    {
        /// <summary>
        /// Probability for a hero to deal critical strike
        /// </summary>
        int CriticalChance { get; set; }
        
        /// <summary>
        /// Probability for damage to ignore armor
        /// </summary>
        int PenetrateArmorChance { get; set; }
        
        /// <summary>
        /// Probability for hero to cast healing
        /// </summary>
        int HealChance { get; set; }

        /// <summary>
        /// Probability for hero to inflict buff
        /// </summary>
        int BuffChance { get; set; }
        
        /// <summary>
        /// Additional chance to inflict a debuff.  Default debuff chance is set in the AddStatusEffect action default chance
        /// </summary>
        int DebuffChance { get; set; }
        
        /// <summary>
        /// Additional chance to counter attack with a basic skill.
        /// </summary>
        int CounterAttackChance { get; set; }
    }
}