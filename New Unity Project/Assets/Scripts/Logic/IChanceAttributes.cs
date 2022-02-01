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
        /// Probability for hero to inflict buff
        /// </summary>
        int BuffChance { get; set; }
    }
}