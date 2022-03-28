using System.Collections;

namespace Logic
{
    public interface ITakeDamage
    {
        /// <summary>
        /// Final damage taken by targeted hero, also same as
        /// final damage dealt by targeting hero.
        /// </summary>
        int FinalDamageTaken { get; }
        
        IEnumerator TakeSingleAttackDamage(IHero casterHero,IHero targetHero, int nonCriticalDamage, int criticalDamage, int percentPenetrateArmor);
        IEnumerator TakeMultiAttackDamage(IHero casterHero,IHero targetHero, int nonCriticalDamage, int criticalDamage, int percentPenetrateArmor);
        IEnumerator TakeNonAttackSkillDamage(IHero casterHero,IHero targetHero, int nonAttackSkillDamage, int penetrateArmorChance,int percentPenetrateArmor);
        IEnumerator TakeNonSkillDamage(IHero targetHero, int nonSkillDamage, int penetrateArmorChance,int percentPenetrateArmor);
        
        /// <summary>
        /// Used in health text animation
        /// </summary>
        int HealthDamage { get; }
        
        /// <summary>
        /// Used in armor text animation
        /// </summary>
        int ArmorDamage { get;}
    }
}