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
            var finalNonCriticalDamage = ComputeSingleAttackNonCriticalDamage(casterHero,nonCriticalDamage);
            var finalCriticalDamage = ComputeSingleAttackCriticalDamage(casterHero, criticalDamage);
            
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

        #region COMPUTE DAMAGE METHODS
        
        /// <summary>
        /// Single Attack type non critical damage component
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="nonCriticalDamage"></param>
        /// <returns></returns>
        private int ComputeSingleAttackNonCriticalDamage(IHero hero, int nonCriticalDamage)
        {
            var allDealDamageReduction = hero.HeroLogic.DamageAttributes.AllDealDamageReduction;
            var dealSingleDamageReduction = hero.HeroLogic.DamageAttributes.SingleDealDamageReduction;
            var dealSkillDamageReduction = hero.HeroLogic.DamageAttributes.SkillDealDamageReduction;

            var damage = (100 - allDealDamageReduction) * (100 - dealSingleDamageReduction) *
                (100 - dealSkillDamageReduction) * nonCriticalDamage / 100f;

            var finalDamage = Mathf.RoundToInt(damage);

            return finalDamage;
            
        }
        
        /// <summary>
        /// Single Attack type critical damage component
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        private int ComputeSingleAttackCriticalDamage(IHero hero, int criticalDamage)
        {
            var allDealDamageReduction = hero.HeroLogic.DamageAttributes.AllDealDamageReduction;
            var dealSingleDamageReduction = hero.HeroLogic.DamageAttributes.SingleDealDamageReduction;
            var dealSkillDamageReduction = hero.HeroLogic.DamageAttributes.SkillDealDamageReduction;

            var damage = (100 - allDealDamageReduction) * (100 - dealSingleDamageReduction) *
                (100 - dealSkillDamageReduction) * criticalDamage / 100f;

            var finalDamage = Mathf.RoundToInt(damage);

            return finalDamage;
        }
        
        /// <summary>
        /// Multi Attack type non critical damage component
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="nonCriticalDamage"></param>
        /// <returns></returns>
        private int ComputeMultiAttackNonCriticalDamage(IHero hero, int nonCriticalDamage)
        {
            var allDealDamageReduction = hero.HeroLogic.DamageAttributes.AllDealDamageReduction;
            var dealMultiDamageReduction = hero.HeroLogic.DamageAttributes.MultiDealDamageReduction;
            var dealSkillDamageReduction = hero.HeroLogic.DamageAttributes.SkillDealDamageReduction;

            var damage = (100 - allDealDamageReduction) * (100 - dealMultiDamageReduction) *
                (100 - dealSkillDamageReduction) * nonCriticalDamage / 100f;

            var finalDamage = Mathf.RoundToInt(damage);

            return finalDamage;
            
        }
        
        /// <summary>
        ///  Multi Attack type critical damage component
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        private int ComputeMultiAttackCriticalDamage(IHero hero, int criticalDamage)
        {
            var allDealDamageReduction = hero.HeroLogic.DamageAttributes.AllDealDamageReduction;
            var dealMultiDamageReduction = hero.HeroLogic.DamageAttributes.MultiDealDamageReduction;
            var dealSkillDamageReduction = hero.HeroLogic.DamageAttributes.SkillDealDamageReduction;

            var damage = (100 - allDealDamageReduction) * (100 - dealMultiDamageReduction) *
                (100 - dealSkillDamageReduction) * criticalDamage / 100f;

            var finalDamage = Mathf.RoundToInt(damage);

            return finalDamage;
            
        }
        
        /// <summary>
        /// Non-attack skill damage component
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="nonAttackSkillDamage"></param>
        /// <returns></returns>
        private int ComputeNonAttackSkillDamage(IHero hero, int nonAttackSkillDamage)
        {
            var allDealDamageReduction = hero.HeroLogic.DamageAttributes.AllDealDamageReduction;
            var dealSkillDamageReduction = hero.HeroLogic.DamageAttributes.SkillDealDamageReduction;
            
            var damage = (100 - allDealDamageReduction)*(100 - dealSkillDamageReduction) * nonAttackSkillDamage / 100f;

            var finalDamage = Mathf.RoundToInt(damage);

            return finalDamage;
        }
        
        /// <summary>
        /// Non skill damage component
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="nonAttackSkillDamage"></param>
        /// <returns></returns>
        private int ComputeNonSkillDamage(IHero hero, int nonAttackSkillDamage)
        {
            var allDealDamageReduction = hero.HeroLogic.DamageAttributes.AllDealDamageReduction;
            var dealNonSkillDamageReduction = hero.HeroLogic.DamageAttributes.NonSkillDealDamageReduction;
            
            var damage = (100 - allDealDamageReduction)*(100 - dealNonSkillDamageReduction) * nonAttackSkillDamage / 100f;

            var finalDamage = Mathf.RoundToInt(damage);

            return finalDamage;
        }


        #endregion
    }
}
