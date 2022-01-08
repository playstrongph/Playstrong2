using System.Collections;
using Logic;

namespace ScriptableObjectScripts.AttackTargetCountTypeAssets
{
    public interface IAttackTargetCountTypeAsset
    {
        IEnumerator StartAction(IDealDamage dealDamage, IHero hero, int nonCriticalDamage, int criticalDamage);
    }
}