using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.AttackTargetCountTypeAssets
{
    [CreateAssetMenu(fileName = "SingleAttackType", menuName = "Assets/AttackTargetCountTypeAsset/SingleAttackType")]
    public class SingleAttackTypeAsset : AttackTargetCountTypeAsset
    {
        
        /// <summary>
        /// Used by attack basic action
        /// </summary>
        /// <param name="dealDamage"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        public override IEnumerator StartAction(IDealDamage dealDamage, IHero casterHero, IHero targetHero, int nonCriticalDamage, int criticalDamage)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
           logicTree.AddCurrent(PreSingleAttackEvents(casterHero,targetHero));

           logicTree.AddCurrent(dealDamage.DealSingleAttackDamage(casterHero,targetHero,nonCriticalDamage,criticalDamage));
           
           logicTree.AddCurrent(PostSingleAttackEvents(casterHero,targetHero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
    }
}
