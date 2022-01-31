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

        /// <summary>
        /// Take single attack damage 
        /// </summary>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        IEnumerator TakeSingleAttackDamage(int nonCriticalDamage, int criticalDamage);

        /// <summary>
        /// Take multi attack damage
        /// </summary>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        IEnumerator TakeMultiAttackDamage(int nonCriticalDamage, int criticalDamage);

        IEnumerator TakeNonAttackSkillDamage(int nonAttackSkillDamage, int penetrateArmorChance);
        IEnumerator TakeNonSkillDamage(int nonSkillDamage, int penetrateArmorChance);
        
        /// <summary>
        /// Damage dealt to health
        /// </summary>
        int HealthDamage { get; }
    }
}