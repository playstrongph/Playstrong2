using System;
using System.Collections;
using UnityEngine;

namespace Logic
{
    public class DealDamage : MonoBehaviour, IDealDamage
    {
        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
        
        /// <summary>
        /// Deal single attack damage
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Deals multi attack damage
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        public IEnumerator DealMultiAttackDamage(IHero casterHero, int nonCriticalDamage, int criticalDamage)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            var finalNonCriticalDamage = ComputeMultiAttackNonCriticalDamage(casterHero,nonCriticalDamage);
            var finalCriticalDamage = ComputeMultiAttackCriticalDamage(casterHero, criticalDamage);
            
            logicTree.AddCurrent(EventBeforeHeroDealsSkillDamage(casterHero));
            
            //TODO: logicTree.AddCurrent(targetHero.HeroLogic.TakeDamageTest.TakeMultiAttackDamage(finalNonCriticalDamage, finalCriticalDamage,attackerHero));
            
            logicTree.AddCurrent(EventAfterHeroDealsSkillDamage(casterHero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// For non-attack damage abilities in skills - e.g. Whenever you are attacked, deal damage to your  attacker
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="nonAttackSkillDamage"></param>
        /// <param name="penetrateArmorChance"></param>
        /// <returns></returns>
        public IEnumerator DealNonAttackSkillDamage(IHero casterHero, int nonAttackSkillDamage, int penetrateArmorChance)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            var heroPenetrateArmorChance = casterHero.HeroLogic.ChanceAttributes.PenetrateArmorChance;
            var totalPenetrateArmorChance = heroPenetrateArmorChance + penetrateArmorChance;
            var finalNonAttackSkillDamage = ComputeNonAttackSkillDamage(casterHero,nonAttackSkillDamage);
           
            
            logicTree.AddCurrent(EventBeforeHeroDealsSkillDamage(casterHero));
            
            //TODO:  logicTree.AddCurrent(targetHero.HeroLogic.TakeDamageTest.TakeNonAttackSkillDamage(finalNonAttackSkillDamage, totalIgnoreArmorChance));
            
            logicTree.AddCurrent(EventAfterHeroDealsSkillDamage(casterHero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// For non-skill damage sources like weapons, status effects, etc. 
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="nonSkillDamage"></param>
        /// <param name="penetrateArmorChance"></param>
        /// <returns></returns>
        public IEnumerator DealNonSkillDamage(IHero casterHero, int nonSkillDamage, int penetrateArmorChance)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            var finalNonSkillDamage = ComputeNonSkillDamage(casterHero,nonSkillDamage);

            logicTree.AddCurrent(EventBeforeDealingNonSkillDamage(casterHero));
            
            //TODO:  logicTree.AddCurrent(targetHero.HeroLogic.TakeDamageTest.TakeNonSkillDamage(finalNonSkillDamage, ignoreArmorChance));
            
            logicTree.AddCurrent(EventAfterDealingNonSkillDamage(casterHero));
            
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
        
        private IEnumerator EventBeforeDealingNonSkillDamage(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            casterHero.HeroLogic.HeroEvents.EventBeforeDealingNonSkillDamage(casterHero);

            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator EventAfterDealingNonSkillDamage(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            casterHero.HeroLogic.HeroEvents.EventAfterDealingNonSkillDamage(casterHero);

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
