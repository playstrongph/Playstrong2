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
        /// <param name="hero"></param>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        public override IEnumerator StartAction(IDealDamage dealDamage, IHero hero, int nonCriticalDamage, int criticalDamage)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
           logicTree.AddCurrent(PreMultiAttackEvents(hero));

           logicTree.AddCurrent(dealDamage.DealMultiAttackDamage(nonCriticalDamage,criticalDamage));
           
           logicTree.AddCurrent(PostMultiAttackEvents(hero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
    }
}
