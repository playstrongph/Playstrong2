using System.Collections;

namespace Logic
{
    public interface IDealDamage
    {
        IEnumerator DealSingleAttackDamage(IHero casterHero, int nonCriticalDamage, int criticalDamage);
    }
}