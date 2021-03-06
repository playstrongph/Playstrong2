using System.Collections;

namespace Logic
{
    public interface IDealDamage
    {   
        /// <summary>
        /// Deals single attack damage
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        IEnumerator DealSingleAttackDamage(IHero casterHero, IHero targetHero, int nonCriticalDamage, int criticalDamage);
        
        /// <summary>
        /// Deals Multi attack damage
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        IEnumerator DealMultiAttackDamage(IHero casterHero, IHero targetHero, int nonCriticalDamage, int criticalDamage);
        
        /// <summary>
        ///  For non-attack damage abilities in skills - e.g. Whenever you are attacked, deal damage to your attacker
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        /// <param name="nonAttackSkillDamage"></param>
        /// <param name="penetrateArmorChance"></param>
        /// <returns></returns>
        IEnumerator DealNonAttackSkillDamage(IHero casterHero, IHero targetHero,int nonAttackSkillDamage, int penetrateArmorChance);

        /// <summary>
        /// For non-skill damage sources like weapons, status effects, etc. 
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        /// <param name="nonSkillDamage"></param>
        /// <param name="penetrateArmorChance"></param>
        /// <returns></returns>
        IEnumerator DealNonSkillDamage(IHero casterHero, IHero targetHero, int nonSkillDamage, int penetrateArmorChance);


    }
}