namespace Logic
{
    public interface IDamageAttributes
    {
        /// <summary>
        /// Percent additional damage due to critical attack.
        /// Default value is 100%.
        /// </summary>
        int CriticalDamage { get; set; }
        
        /// <summary>
        /// Percent of damage taken that penetrates armor
        /// </summary>
        int TakeDamagePenetrateArmor { get; set; }
        
        /// <summary>
        /// Percent of damage dealt that penetrates armor
        /// </summary>
        int DealDamagePenetrateArmor { get; set; }

        /// <summary>
        /// All deal damage types percent reduction
        /// </summary>
        int AllDealDamageReduction { get; set; }

        /// <summary>
        /// Single attack deal damage percent reduction
        /// </summary>
        int SingleDealDamageReduction { get; set; }

        /// <summary>
        /// Multiple attack deal damage percent reduction
        /// </summary>
        int MultiDealDamageReduction { get; set; }

        /// <summary>
        /// Skill deal damage percent reduction.
        /// </summary>
        int SkillDealDamageReduction { get; set; }

        /// <summary>
        /// NonSkill deal damage percent reduction.
        /// </summary>
        int NonSkillDealDamageReduction { get; set; }

        /// <summary>
        /// All take damage types percent reduction
        /// </summary>
        int AllTakeDamageReduction { get; set; }

        /// <summary>
        /// Single attack take damage percent reduction
        /// </summary>
        int SingleTakeDamageReduction { get; set; }

        /// <summary>
        /// Multiple attack take damage percent reduction
        /// </summary>
        int MultiTakeDamageReduction { get; set; }

        /// <summary>
        /// Skill take damage percent reduction.
        /// </summary>
        int SkillTakeDamageReduction { get; set; }

        /// <summary>
        /// NonSkill take damage percent reduction.
        /// </summary>
        int NonSkillTakeDamageReduction { get; set; }
    }
}