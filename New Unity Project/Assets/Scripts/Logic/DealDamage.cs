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
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        public IEnumerator DealSingleAttackDamage(int nonCriticalDamage, int criticalDamage)
        {
            var casterHero = _heroLogic.Hero;
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            var finalNonCriticalDamage = ComputeSingleAttackNonCriticalDamage(casterHero,nonCriticalDamage);
            var finalCriticalDamage = ComputeSingleAttackCriticalDamage(casterHero, criticalDamage);
            
            logicTree.AddCurrent(EventBeforeHeroDealsSkillDamage(casterHero));
            
            logicTree.AddCurrent(targetedHero.HeroLogic.TakeDamage.TakeSingleAttackDamage(finalNonCriticalDamage, finalCriticalDamage));
            
            logicTree.AddCurrent(EventAfterHeroDealsSkillDamage(casterHero));
            
            logicTree.EndSequence();
            yield return null;
        }
        /// <summary>
        /// Deals multi attack damage
        /// </summary>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        public IEnumerator DealMultiAttackDamage(int nonCriticalDamage, int criticalDamage)
        {
            var casterHero = _heroLogic.Hero;
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            var finalNonCriticalDamage = ComputeMultiAttackNonCriticalDamage(casterHero,nonCriticalDamage);
            var finalCriticalDamage = ComputeMultiAttackCriticalDamage(casterHero, criticalDamage);
            
            logicTree.AddCurrent(EventBeforeHeroDealsSkillDamage(casterHero));
            
            logicTree.AddCurrent(targetedHero.HeroLogic.TakeDamage.TakeMultiAttackDamage(finalNonCriticalDamage, finalCriticalDamage));
            
            logicTree.AddCurrent(EventAfterHeroDealsSkillDamage(casterHero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// For non-attack damage abilities in skills - e.g. Whenever you are attacked, deal damage to your  attacker
        /// </summary>
        /// <param name="nonAttackSkillDamage"></param>
        /// <param name="penetrateArmorChance"></param>
        /// <returns></returns>
        public IEnumerator DealNonAttackSkillDamage(int nonAttackSkillDamage, int penetrateArmorChance)
        {
            var casterHero = _heroLogic.Hero;
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            var heroPenetrateArmorChance = casterHero.HeroLogic.ChanceAttributes.PenetrateArmorChance;
            var totalPenetrateArmorChance = heroPenetrateArmorChance + penetrateArmorChance;
            var finalNonAttackSkillDamage = ComputeNonAttackSkillDamage(casterHero,nonAttackSkillDamage);
           
            
            logicTree.AddCurrent(EventBeforeHeroDealsSkillDamage(casterHero));
            
            logicTree.AddCurrent(targetedHero.HeroLogic.TakeDamage.TakeNonAttackSkillDamage(finalNonAttackSkillDamage, totalPenetrateArmorChance));
            
            logicTree.AddCurrent(EventAfterHeroDealsSkillDamage(casterHero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// For non-skill damage sources like weapons, status effects, etc. 
        /// </summary>
        /// <param name="nonSkillDamage"></param>
        /// <param name="penetrateArmorChance"></param>
        /// <returns></returns>
        public IEnumerator DealNonSkillDamage(int nonSkillDamage, int penetrateArmorChance)
        {
            var casterHero = _heroLogic.Hero;
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            var finalNonSkillDamage = ComputeNonSkillDamage(casterHero,nonSkillDamage);

            logicTree.AddCurrent(EventBeforeDealingNonSkillDamage(casterHero));
            
            logicTree.AddCurrent(targetedHero.HeroLogic.TakeDamage.TakeNonSkillDamage(finalNonSkillDamage, penetrateArmorChance));
            
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
            var allDealDamageReduction = hero.HeroLogic.DamageAttributes.AllDealDamageReduction/100f;
            var dealSingleDamageReduction = hero.HeroLogic.DamageAttributes.SingleDealDamageReduction/100f;
            var dealSkillDamageReduction = hero.HeroLogic.DamageAttributes.SkillDealDamageReduction/100f;

            var damage = (1 - allDealDamageReduction) * (1 - dealSingleDamageReduction) *
                (1 - dealSkillDamageReduction) * nonCriticalDamage;

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
            var allDealDamageReduction = hero.HeroLogic.DamageAttributes.AllDealDamageReduction/100f;
            var dealSingleDamageReduction = hero.HeroLogic.DamageAttributes.SingleDealDamageReduction/100f;
            var dealSkillDamageReduction = hero.HeroLogic.DamageAttributes.SkillDealDamageReduction/100f;

            var damage = (1 - allDealDamageReduction) * (1 - dealSingleDamageReduction) *
                (1 - dealSkillDamageReduction) * criticalDamage;

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
            var allDealDamageReduction = hero.HeroLogic.DamageAttributes.AllDealDamageReduction/100f;
            var dealMultiDamageReduction = hero.HeroLogic.DamageAttributes.MultiDealDamageReduction/100f;
            var dealSkillDamageReduction = hero.HeroLogic.DamageAttributes.SkillDealDamageReduction/100f;

            var damage = (1 - allDealDamageReduction) * (1 - dealMultiDamageReduction) *
                (1 - dealSkillDamageReduction) * nonCriticalDamage;

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
            var allDealDamageReduction = hero.HeroLogic.DamageAttributes.AllDealDamageReduction/100f;
            var dealMultiDamageReduction = hero.HeroLogic.DamageAttributes.MultiDealDamageReduction/100f;
            var dealSkillDamageReduction = hero.HeroLogic.DamageAttributes.SkillDealDamageReduction/100f;

            var damage = (1 - allDealDamageReduction) * (1 - dealMultiDamageReduction) *
                (1 - dealSkillDamageReduction) * criticalDamage;

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
            var allDealDamageReduction = hero.HeroLogic.DamageAttributes.AllDealDamageReduction/100f;
            var dealSkillDamageReduction = hero.HeroLogic.DamageAttributes.SkillDealDamageReduction/100f;
            
            var damage = (1 - allDealDamageReduction)*(1 - dealSkillDamageReduction) * nonAttackSkillDamage;

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
            var allDealDamageReduction = hero.HeroLogic.DamageAttributes.AllDealDamageReduction/100f;
            var dealNonSkillDamageReduction = hero.HeroLogic.DamageAttributes.NonSkillDealDamageReduction/100f;
            
            var damage = (1 - allDealDamageReduction)*(1 - dealNonSkillDamageReduction) * nonAttackSkillDamage;

            var finalDamage = Mathf.RoundToInt(damage);

            return finalDamage;
        }


        #endregion
    }
}
