namespace Logic
{
    public interface IResistanceAttributes
    {
        /// <summary>
        ///  Value greater than zero means the hero can't be targeted directly by attack type skills.
        /// Used by stealth, taunt, and similar effects.
        /// </summary>
        int TargetAttackResistance { get; set; }
        
        /// <summary>
        /// Probability for a hero to resist critical strike
        /// </summary>
        int CriticalResistance { get; set; }
        
        /// <summary>
        /// Probability for hero to resist ignore armor 
        /// </summary>
        int PenetrateArmorResistance { get; set; }
    }
}