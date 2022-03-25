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
        ///  <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        public IEnumerator DealSingleAttackDamage(IHero casterHero, IHero targetHero, int nonCriticalDamage, int criticalDamage)
        {
            //var casterHero = _heroLogic.Hero;
            //var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            var finalNonCriticalDamage = ComputeSingleAttackNonCriticalDamage(casterHero,nonCriticalDamage);
            var finalCriticalDamage = ComputeSingleAttackCriticalDamage(casterHero, criticalDamage);
            
            logicTree.AddCurrent(EventBeforeHeroDealsSkillDamage(casterHero,targetHero));
            
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamage.TakeSingleAttackDamage(casterHero,targetHero,finalNonCriticalDamage, finalCriticalDamage));
            
            logicTree.AddCurrent(EventAfterHeroDealsSkillDamage(casterHero,targetHero));
            
            logicTree.EndSequence();
            yield return null;
        }
        /// <summary>
        /// Deals multi attack damage
        /// </summary>
        ///  <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        public IEnumerator DealMultiAttackDamage(IHero casterHero, IHero targetHero, int nonCriticalDamage, int criticalDamage)
        {
            //var casterHero = _heroLogic.Hero;
            //var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var finalNonCriticalDamage = ComputeMultiAttackNonCriticalDamage(casterHero,nonCriticalDamage);
            var finalCriticalDamage = ComputeMultiAttackCriticalDamage(casterHero, criticalDamage);
            
            logicTree.AddCurrent(EventBeforeHeroDealsSkillDamage(casterHero,targetHero));
            
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamage.TakeMultiAttackDamage(casterHero,targetHero,finalNonCriticalDamage, finalCriticalDamage));
            
            logicTree.AddCurrent(EventAfterHeroDealsSkillDamage(casterHero,targetHero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// For non-attack damage abilities in skills - e.g. Whenever you are attacked, deal damage to your  attacker
        /// </summary>
        ///  <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        /// <param name="nonAttackSkillDamage"></param>
        /// <param name="penetrateArmorChance"></param>
        /// <returns></returns>
        public IEnumerator DealNonAttackSkillDamage(IHero casterHero, IHero targetHero, int nonAttackSkillDamage, int penetrateArmorChance)
        {
            //var casterHero = _heroLogic.Hero;
            //var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
          
            var heroPenetrateArmorChance = casterHero.HeroLogic.ChanceAttributes.PenetrateArmorChance;
            var totalPenetrateArmorChance = heroPenetrateArmorChance + penetrateArmorChance;
            var finalNonAttackSkillDamage = ComputeNonAttackSkillDamage(casterHero,nonAttackSkillDamage);
           
            
            logicTree.AddCurrent(EventBeforeHeroDealsSkillDamage(casterHero,targetHero));
            
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamage.TakeNonAttackSkillDamage(casterHero,targetHero,finalNonAttackSkillDamage, totalPenetrateArmorChance));
            
            logicTree.AddCurrent(EventAfterHeroDealsSkillDamage(casterHero,targetHero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// For non-skill damage sources like weapons, status effects, etc.
        /// TODO:  caster Hero not required, for cleanup.  DealNonSkillDamage is not required, only TakeNonSkillDamage
        /// </summary>
        ///  <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        /// <param name="nonSkillDamage"></param>
        /// <param name="penetrateArmorChance"></param>
        /// <returns></returns>
        public IEnumerator DealNonSkillDamage(IHero casterHero, IHero targetHero, int nonSkillDamage, int penetrateArmorChance)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            var finalNonSkillDamage = ComputeNonSkillDamage(casterHero,nonSkillDamage);

            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamage.TakeNonSkillDamage(targetHero,finalNonSkillDamage, penetrateArmorChance));

            logicTree.EndSequence();
            yield return null;
        }
        
        #region EVENTS

        private IEnumerator EventBeforeHeroDealsSkillDamage(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            casterHero.HeroLogic.HeroEvents.EventBeforeHeroDealsSkillDamage(casterHero,targetHero);

            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator EventAfterHeroDealsSkillDamage(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //TODO - 2 arguments?
            casterHero.HeroLogic.HeroEvents.EventAfterHeroDealsSkillDamage(casterHero,targetHero);

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
            var allDealDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.AllDealDamageReduction/100f,1);
            
            var dealSingleDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.SingleDealDamageReduction/100f,1);
            
            var dealSkillDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.SkillDealDamageReduction/100f,1);

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
            var allDealDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.AllDealDamageReduction/100f,1);
            
            var dealSingleDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.SingleDealDamageReduction/100f,1);
            
            var dealSkillDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.SkillDealDamageReduction/100f,1);

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
            var allDealDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.AllDealDamageReduction/100f,1);
            
            var dealMultiDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.MultiDealDamageReduction/100f,1);
            
            var dealSkillDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.SkillDealDamageReduction/100f,1);

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
            var allDealDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.AllDealDamageReduction/100f,1);
            
            var dealMultiDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.MultiDealDamageReduction/100f,1);
            
            var dealSkillDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.SkillDealDamageReduction/100f,1);

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
            var allDealDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.AllDealDamageReduction/100f,1);
            
            var dealSkillDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.SkillDealDamageReduction/100f,1);
            
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
            var allDealDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.AllDealDamageReduction/100f,1);
            
            var dealNonSkillDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.NonSkillDealDamageReduction/100f,1);
            
            var damage = (1 - allDealDamageReduction)*(1 - dealNonSkillDamageReduction) * nonAttackSkillDamage;

            var finalDamage = Mathf.RoundToInt(damage);

            return finalDamage;
        }


        #endregion
    }
}
