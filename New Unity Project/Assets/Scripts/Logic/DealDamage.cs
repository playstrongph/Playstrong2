using System;
using System.Collections;
using UnityEngine;

namespace Logic
{
    public class DealDamage : MonoBehaviour
    {
        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
        
        public IEnumerator DealSingleAttackDamage(IHero casterHero, int nonCriticalDamage, int criticalDamage)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            
            //TODO: var finalNonCriticalDamage = ComputeSingleAttackNonCriticalDamage(nonCriticalDamage);
            
            //TODO: var finalCriticalDamage = ComputeSingleAttackCriticalDamage(criticalDamage);
            
            logicTree.AddCurrent(EventBeforeHeroDealsSkillDamage(casterHero));
            
            //TODO: logicTree.AddCurrent(targetHero.HeroLogic.TakeDamageTest.TakeSingleAttackDamage(finalNonCriticalDamage, finalCriticalDamage,attackerHero));
            
            logicTree.AddCurrent(EventAfterHeroDealsSkillDamage(casterHero));
            
            logicTree.EndSequence();
            yield return null;
        }

        #region EVENTS

        private IEnumerator EventBeforeHeroDealsSkillDamage(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            casterHero.HeroLogic.HeroEvents.EventBeforeHeroDealsSkillDamage(casterHero);

            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator EventAfterHeroDealsSkillDamage(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            casterHero.HeroLogic.HeroEvents.EventAfterHeroDealsSkillDamage(casterHero);

            logicTree.EndSequence();
            yield return null;
        }

        #endregion
    }
}
