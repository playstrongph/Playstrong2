using System.Collections;
using Logic;

namespace ScriptableObjectScripts.AttackTargetCountTypeAssets
{
    public interface IAttackTargetCountTypeAsset
    {
        IEnumerator StartAction(IDealDamage dealDamage, IHero casterHero, IHero targetHero, int nonCriticalDamage, int criticalDamage);
    }
}