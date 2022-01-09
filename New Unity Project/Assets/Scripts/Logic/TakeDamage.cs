using System;
using System.Collections;
using UnityEngine;

namespace Logic
{
    public class TakeDamage : MonoBehaviour
    {   
        /// <summary>
        /// Remaining damage after armor is reduced
        /// </summary>
        private int _residualDamage;

        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }


        public IEnumerator TakeSingleAttackDamage(int nonCriticalDamage, int criticalDamage)
        {
            var targetedHero = _heroLogic.Hero;
            var casterHero = targetedHero.HeroLogic.LastHeroTargets.TargetingHero;
            var logicTree = targetedHero.CoroutineTrees.MainLogicTree;
            
            
            
            logicTree.EndSequence();
            yield return null;

        }
        
        public IEnumerator TakeMultiAttackDamage(int nonCriticalDamage, int criticalDamage)
        {
            var targetedHero = _heroLogic.Hero;
            var casterHero = targetedHero.HeroLogic.LastHeroTargets.TargetingHero;
            var logicTree = targetedHero.CoroutineTrees.MainLogicTree;
            
            
            
            logicTree.EndSequence();
            yield return null;

        }
        
        public IEnumerator TakeNonAttackSkillDamage(int nonAttackSkillDamage, int penetrateArmorChance)
        {
            var targetedHero = _heroLogic.Hero;
            var casterHero = targetedHero.HeroLogic.LastHeroTargets.TargetingHero;
            var logicTree = targetedHero.CoroutineTrees.MainLogicTree;
            
            
            
            logicTree.EndSequence();
            yield return null;

        }
        
        public IEnumerator TakeNonSkillDamage(int nonSkillDamage, int penetrateArmorChance)
        {
            var targetedHero = _heroLogic.Hero;
            var casterHero = targetedHero.HeroLogic.LastHeroTargets.TargetingHero;
            var logicTree = targetedHero.CoroutineTrees.MainLogicTree;
            
            
            
            logicTree.EndSequence();
            yield return null;

        }

        #region COMPUTE DAMAGE
        
        /// <summary>
        /// Calculates final single attack take damage
        /// </summary>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        private int ComputeSingleAttackDamage(int nonCriticalDamage, int criticalDamage)
        {
            var allDamageReduction = _heroLogic.DamageAttributes.AllTakeDamageReduction;
            var singleAttackDamageReduction = _heroLogic.DamageAttributes.SingleTakeDamageReduction;
            var skillDamageReduction = _heroLogic.DamageAttributes.SkillTakeDamageReduction;
            var damage = criticalDamage + nonCriticalDamage;

            var floatFinalDamage = (1 - allDamageReduction) * (1 - singleAttackDamageReduction) *
                (1 - skillDamageReduction) * damage / 100f;

            var finalTakeDamage = Mathf.RoundToInt(floatFinalDamage);
            
            return finalTakeDamage;
        }
        
        /// <summary>
        /// Calculates final multi attack take damage
        /// </summary>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        private int ComputeMultiAttackDamage(int nonCriticalDamage, int criticalDamage)
        {
            var allDamageReduction = _heroLogic.DamageAttributes.AllTakeDamageReduction;
            var multiAttackDamageReduction = _heroLogic.DamageAttributes.MultiTakeDamageReduction;
            var skillDamageReduction = _heroLogic.DamageAttributes.SkillTakeDamageReduction;
            var damage = criticalDamage + nonCriticalDamage;

            var floatFinalDamage = (1 - allDamageReduction) * (1 - multiAttackDamageReduction) *
                (1 - skillDamageReduction) * damage / 100f;

            var finalTakeDamage = Mathf.RoundToInt(floatFinalDamage);
            
            return finalTakeDamage;
        }
        
        /// <summary>
        /// Calculates the final non-attack skill damage
        /// </summary>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        private int ComputeNonAttackSkillDamage(int nonCriticalDamage, int criticalDamage)
        {
            var allDamageReduction = _heroLogic.DamageAttributes.AllTakeDamageReduction;
            var skillDamageReduction = _heroLogic.DamageAttributes.SkillTakeDamageReduction;
            var damage = criticalDamage + nonCriticalDamage;

            var floatFinalDamage = (1 - allDamageReduction) * (1 - skillDamageReduction) * damage / 100f;

            var finalTakeDamage = Mathf.RoundToInt(floatFinalDamage);
            
            return finalTakeDamage;
        }
        
        /// <summary>
        /// Calculates the final non-skill damage
        /// </summary>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        private int ComputeNonSkillDamage(int nonCriticalDamage, int criticalDamage)
        {
            var allDamageReduction = _heroLogic.DamageAttributes.AllTakeDamageReduction;
            var nonSkillDamageReduction = _heroLogic.DamageAttributes.NonSkillTakeDamageReduction;
            var damage = criticalDamage + nonCriticalDamage;

            var floatFinalDamage = (1 - allDamageReduction) * (1 - nonSkillDamageReduction) * damage / 100f;

            var finalTakeDamage = Mathf.RoundToInt(floatFinalDamage);
            
            return finalTakeDamage;
        }

        private void ComputeNewArmor(int damage)
        {
            var armor = _heroLogic.HeroAttributes.Armor;

            //No residual damage when armor is greater than damage
            _residualDamage = Mathf.Max(0,damage - armor);
            
            //New armor is zero when damage is greater than armor
            var newArmor = Mathf.Max(0, armor - damage);
            
            //LOGIC: Armor Update
            //TODO: Change this to SetArmor after logic visual separation
            _heroLogic.HeroAttributes.Armor = newArmor;
        }



        #endregion

    }
}
