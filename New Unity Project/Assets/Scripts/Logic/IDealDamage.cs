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
        /// <param name="percentPenetrateArmor"></param>
        /// <returns></returns>
        IEnumerator DealSingleAttackDamage(IHero casterHero, IHero targetHero, int nonCriticalDamage, int criticalDamage,int percentPenetrateArmor);
        
        /// <summary>
        /// Deals Multi attack damage
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <param name="percentPenetrateArmor"></param>
        /// <returns></returns>
        IEnumerator DealMultiAttackDamage(IHero casterHero, IHero targetHero, int nonCriticalDamage, int criticalDamage,int percentPenetrateArmor);
        
        /// <summary>
        ///  For non-attack damage abilities in skills - e.g. Whenever you are attacked, deal damage to your attacker
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        /// <param name="nonAttackSkillDamage"></param>
        /// <param name="penetrateArmorChance"></param>
        /// <param name="percentPenetrateArmor"></param>
        /// <returns></returns>
        IEnumerator DealNonAttackSkillDamage(IHero casterHero, IHero targetHero,int nonAttackSkillDamage, int penetrateArmorChance,int percentPenetrateArmor);

        /// <summary>
        /// For non-skill damage sources like weapons, status effects, etc. 
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        /// <param name="nonSkillDamage"></param>
        /// <param name="penetrateArmorChance"></param>
        /// <param name="percentPenetrateArmor"></param>
        /// <returns></returns>
        IEnumerator DealNonSkillDamage(IHero casterHero, IHero targetHero, int nonSkillDamage, int penetrateArmorChance,int percentPenetrateArmor);


    }
}