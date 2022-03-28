using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.AttackTargetCountTypeAssets
{
    [CreateAssetMenu(fileName = "MultiAttackType", menuName = "Assets/AttackTargetCountTypeAsset/MultiAttackType")]
    public class MultiAttackTypeAsset : AttackTargetCountTypeAsset
    {
        
        /// <summary>
        /// Used by attack basic action
        /// </summary>
        /// <param name="dealDamage"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <param name="percentPenetrateArmor"></param>
        /// <returns></returns>
        public override IEnumerator StartAction(IDealDamage dealDamage, IHero casterHero, IHero targetHero, int nonCriticalDamage, int criticalDamage,int percentPenetrateArmor)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
           logicTree.AddCurrent(PreMultiAttackEvents(casterHero,targetHero));

           logicTree.AddCurrent(dealDamage.DealMultiAttackDamage(casterHero,targetHero,nonCriticalDamage,criticalDamage,percentPenetrateArmor));
           
           logicTree.AddCurrent(PostMultiAttackEvents(casterHero,targetHero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
    }
}
