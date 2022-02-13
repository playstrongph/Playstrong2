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
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        IEnumerator TakeSingleAttackDamage(IHero casterHero,IHero targetHero, int nonCriticalDamage, int criticalDamage);

        /// <summary>
        /// Take multi attack damage
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        IEnumerator TakeMultiAttackDamage(IHero casterHero,IHero targetHero, int nonCriticalDamage, int criticalDamage);

        IEnumerator TakeNonAttackSkillDamage(IHero casterHero,IHero targetHero, int nonAttackSkillDamage, int penetrateArmorChance);
        IEnumerator TakeNonSkillDamage(IHero casterHero,IHero targetHero, int nonSkillDamage, int penetrateArmorChance);
        
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