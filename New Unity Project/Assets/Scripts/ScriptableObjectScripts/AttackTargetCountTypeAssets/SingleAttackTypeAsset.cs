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
        /// <param name="hero"></param>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        public override IEnumerator StartAction(IDealDamage dealDamage, IHero hero, int nonCriticalDamage, int criticalDamage)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
           logicTree.AddCurrent(PreSingleAttackEvents(hero));

           logicTree.AddCurrent(dealDamage.DealSingleAttackDamage(nonCriticalDamage,criticalDamage));
           
           logicTree.AddCurrent(PostSingleAttackEvents(hero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
    }
}
