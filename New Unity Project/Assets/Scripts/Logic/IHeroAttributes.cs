namespace Logic
{
    public interface IHeroAttributes
    {   
        /// <summary>
        /// Current Attack
        /// </summary>
        int Attack { get; set; }
        
        /// <summary>
        /// Current Health
        /// </summary>
        int Health { get; set; }
        
        /// <summary>
        /// Current Armor
        /// </summary>
        int Armor { get; set; }
        
        /// <summary>
        /// Current Speed
        /// </summary>
        int Speed { get; set; }
        
        /// <summary>
        /// Current Chance
        /// </summary>
        int Chance { get; set; }
        
        /// <summary>
        /// Current Energy
        /// </summary>
        int Energy { get; set; }
        
        /// <summary>
        /// Current Fighting Energy
        /// </summary>
        int FightingSpirit { get; set; }
        
        /// <summary>
        /// Base Attack
        /// </summary>
        int BaseAttack { get; set; }
        
        /// <summary>
        /// Base Health
        /// </summary>
        int BaseHealth { get; set; }
        
        /// <summary>
        /// Base Armor
        /// </summary>
        int BaseArmor { get; set; }
        
        /// <summary>
        /// Base Speed
        /// </summary>
        int BaseSpeed { get; set; }
        
        /// <summary>
        /// Base Chance
        /// </summary>
        int BaseChance { get; set; }
        
        /// <summary>
        /// Passive attack 
        /// </summary>
        int PassiveAttack { get; set; }
    }
}