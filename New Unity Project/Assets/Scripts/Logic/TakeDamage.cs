using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Logic
{
    public class TakeDamage : MonoBehaviour, ITakeDamage
    {
        [Header("SET IN RUNTIME")][SerializeField]private int finalDamageTaken;
        /// <summary>
        /// Final damage taken by targeted hero, also same as
        /// final damage dealt by targeting hero.
        /// </summary>
        public int FinalDamageTaken
        {
            get => finalDamageTaken;
            private set => finalDamageTaken = value;
        }

        /// <summary>
        /// Remaining damage after armor is reduced
        /// </summary>
        private int _residualDamage;

        private IHeroLogic _heroLogic;
        
        /// <summary>
        /// Damage dealt to health
        /// </summary>
        public int HealthDamage { get; private set; }

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        /// <summary>
        /// Take single attack damage 
        /// </summary>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        public IEnumerator TakeSingleAttackDamage(int nonCriticalDamage, int criticalDamage)
        {
            var targetedHero = _heroLogic.Hero;
            var casterHero = targetedHero.HeroLogic.LastHeroTargets.TargetingHero;
            var logicTree = targetedHero.CoroutineTrees.MainLogicTree;

            //Penetrate armor calculation
            var chance = casterHero.HeroLogic.ChanceAttributes.PenetrateArmorChance;
            var resistance = _heroLogic.ResistanceAttributes.PenetrateArmorResistance;
            var netChance = chance - resistance;
            var randomChance = Random.Range(1, 101);
            
            //Single Attack Type Damage
            FinalDamageTaken = ComputeSingleAttackDamage(nonCriticalDamage, criticalDamage);

            logicTree.AddCurrent(BeforeHeroTakesSkillDamageEvent());

            //Apply take damage
            logicTree.AddCurrent(randomChance <= netChance
                ? HeroTakesDamageIgnoreArmor(FinalDamageTaken)
                : HeroTakesDamage(FinalDamageTaken));

            logicTree.AddCurrent(AfterHeroTakesSkillDamageEvent());
            
            //TODO: Check Hero Death

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Take multi attack damage
        /// </summary>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        public IEnumerator TakeMultiAttackDamage(int nonCriticalDamage, int criticalDamage)
        {
            var targetedHero = _heroLogic.Hero;
            var casterHero = targetedHero.HeroLogic.LastHeroTargets.TargetingHero;
            var logicTree = targetedHero.CoroutineTrees.MainLogicTree;

            //Penetrate armor calculation
            var chance = casterHero.HeroLogic.ChanceAttributes.PenetrateArmorChance;
            var resistance = _heroLogic.ResistanceAttributes.PenetrateArmorResistance;
            var netChance = chance - resistance;
            var randomChance = Random.Range(1, 101);
            
            //Multi Attack Type Damage
            FinalDamageTaken = ComputeMultiAttackDamage(nonCriticalDamage, criticalDamage);

            logicTree.AddCurrent(BeforeHeroTakesSkillDamageEvent());

            //Apply take damage
            logicTree.AddCurrent(randomChance <= netChance
                ? HeroTakesDamageIgnoreArmor(FinalDamageTaken)
                : HeroTakesDamage(FinalDamageTaken));

            logicTree.AddCurrent(AfterHeroTakesSkillDamageEvent());
            
            //TODO: Check Hero Death

            logicTree.EndSequence();
            yield return null;

        }
        
        public IEnumerator TakeNonAttackSkillDamage(int nonAttackSkillDamage, int penetrateArmorChance)
        {
            var targetedHero = _heroLogic.Hero;
            var casterHero = targetedHero.HeroLogic.LastHeroTargets.TargetingHero;
            var logicTree = targetedHero.CoroutineTrees.MainLogicTree;

            //Penetrate armor calculation
            var chance = casterHero.HeroLogic.ChanceAttributes.PenetrateArmorChance + penetrateArmorChance;
            var resistance = _heroLogic.ResistanceAttributes.PenetrateArmorResistance;
            var netChance = chance - resistance;
            var randomChance = Random.Range(1, 101);
            
            //Non-attack skill damage
            FinalDamageTaken = ComputeNonAttackSkillDamage(nonAttackSkillDamage,0);
            
            logicTree.AddCurrent(BeforeHeroTakesSkillDamageEvent());
            
            //Apply take damage
            logicTree.AddCurrent(randomChance <= netChance
                ? HeroTakesDamageIgnoreArmor(FinalDamageTaken)
                : HeroTakesDamage(FinalDamageTaken));
            
            logicTree.AddCurrent(AfterHeroTakesSkillDamageEvent());
            
            //TODO: Check Hero Death

            logicTree.EndSequence();
            yield return null;

        }
        
        public IEnumerator TakeNonSkillDamage(int nonSkillDamage, int penetrateArmorChance)
        {
            var targetedHero = _heroLogic.Hero;
            var logicTree = targetedHero.CoroutineTrees.MainLogicTree;

            //Penetrate armor calculation
            var resistance = _heroLogic.ResistanceAttributes.PenetrateArmorResistance;
            var netChance = penetrateArmorChance - resistance;
            var randomChance = Random.Range(1, 101);
            
            //Non-skill Damage
            FinalDamageTaken = ComputeNonSkillDamage(nonSkillDamage,0);

            logicTree.AddCurrent(BeforeHeroTakesNonSkillDamageEvent());
            
            //Apply take damage
            logicTree.AddCurrent(randomChance <= netChance
                ? HeroTakesDamageIgnoreArmor(FinalDamageTaken)
                : HeroTakesDamage(FinalDamageTaken));
            
            logicTree.AddCurrent(AfterHeroTakesNonSkillDamageEvent());
            
            //TODO: Check Hero Death

            logicTree.EndSequence();
            yield return null;

        }

        private IEnumerator HeroTakesDamage(int finalDamage)
        {
            var logicTree = _heroLogic.Hero.CoroutineTrees.MainLogicTree;
            
            ComputeNewArmor(finalDamage);
            ComputeNewHealth(_residualDamage);

            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator HeroTakesDamageIgnoreArmor(int finalDamage)
        {
            var logicTree = _heroLogic.Hero.CoroutineTrees.MainLogicTree;
            
            ComputeNewHealth(finalDamage);
            
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
            var allDamageReduction = Mathf.Min(_heroLogic.DamageAttributes.AllTakeDamageReduction/100f,1);
            
            var singleAttackDamageReduction = Mathf.Min(_heroLogic.DamageAttributes.SingleTakeDamageReduction/100f,1);
            
            var skillDamageReduction = Mathf.Min(_heroLogic.DamageAttributes.SkillTakeDamageReduction/100f,1);
            
            var damage = criticalDamage + nonCriticalDamage;

            var floatFinalDamage = (1 - allDamageReduction) * (1 - singleAttackDamageReduction) *
                (1 - skillDamageReduction) * damage;

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
            var allDamageReduction = Mathf.Min(_heroLogic.DamageAttributes.AllTakeDamageReduction/100f,1);
            
            var multiAttackDamageReduction = Mathf.Min(_heroLogic.DamageAttributes.MultiTakeDamageReduction/100f,1);
            
            var skillDamageReduction = Mathf.Min(_heroLogic.DamageAttributes.SkillTakeDamageReduction/100f,1);
            
            var damage = criticalDamage + nonCriticalDamage;

            var floatFinalDamage = (1 - allDamageReduction) * (1 - multiAttackDamageReduction) *
                (1 - skillDamageReduction) * damage;

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
            var allDamageReduction = _heroLogic.DamageAttributes.AllTakeDamageReduction/100f;
            var skillDamageReduction = _heroLogic.DamageAttributes.SkillTakeDamageReduction/100f;
            var damage = criticalDamage + nonCriticalDamage;

            var floatFinalDamage = (1 - allDamageReduction) * (1 - skillDamageReduction) * damage;

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
            var allDamageReduction = _heroLogic.DamageAttributes.AllTakeDamageReduction/100f;
            var nonSkillDamageReduction = _heroLogic.DamageAttributes.NonSkillTakeDamageReduction/100f;
            var damage = criticalDamage + nonCriticalDamage;

            var floatFinalDamage = (1 - allDamageReduction) * (1 - nonSkillDamageReduction) * damage;

            var finalTakeDamage = Mathf.RoundToInt(floatFinalDamage);
            
            return finalTakeDamage;
        }
        
        /// <summary>
        /// Calculates the value of the new armor
        /// and residual damage
        /// </summary>
        /// <param name="damage"></param>
        private void ComputeNewArmor(int damage)
        {
            var armor = _heroLogic.HeroAttributes.Armor;

            //No residual damage when armor is greater than damage
            _residualDamage = Mathf.Max(0,damage - armor);
            
            //New armor is zero when damage is greater than armor
            var newArmor = Mathf.Max(0, armor - damage);
            
            //Update armor attribute
            _heroLogic.SetArmor.StartAction(newArmor);
        }
        
        /// <summary>
        /// Calculates the value of new health
        /// </summary>
        /// <param name="damage"></param>
        private void ComputeNewHealth(int damage)
        {
            var health = _heroLogic.HeroAttributes.Health;
            var newHealth = health - damage;
            
            //Used by visual updates to check if there is health damage
            HealthDamage = damage;
            
            _heroLogic.SetHealth.StartAction(newHealth);
            
            
        }
        
        
        //TODO: Visual Updates

        #endregion

        #region EVENTS
        
        /// <summary>
        /// Before targeted hero takes skill damage
        /// </summary>
        /// <returns></returns>
        private IEnumerator BeforeHeroTakesSkillDamageEvent()
        {
            var logicTree = _heroLogic.Hero.CoroutineTrees.MainLogicTree;
            
           _heroLogic.HeroEvents.EventBeforeHeroTakesSkillDamage(_heroLogic.Hero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// After targeted hero takes skill damage
        /// </summary>
        /// <returns></returns>
        private IEnumerator AfterHeroTakesSkillDamageEvent()
        {
            var logicTree = _heroLogic.Hero.CoroutineTrees.MainLogicTree;
            
            _heroLogic.HeroEvents.EventAfterHeroTakesSkillDamage(_heroLogic.Hero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Before targeted hero takes non-skill damage
        /// </summary>
        /// <returns></returns>
        private IEnumerator BeforeHeroTakesNonSkillDamageEvent()
        {
            var logicTree = _heroLogic.Hero.CoroutineTrees.MainLogicTree;
            
            _heroLogic.HeroEvents.EventBeforeHeroTakesNonSkillDamage(_heroLogic.Hero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// After targeted hero takes non-skill damage
        /// </summary>
        /// <returns></returns>
        private IEnumerator AfterHeroTakesNonSkillDamageEvent()
        {
            var logicTree = _heroLogic.Hero.CoroutineTrees.MainLogicTree;
            
            _heroLogic.HeroEvents.EventAfterHeroTakesNonSkillDamage(_heroLogic.Hero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        




        #endregion

    }
}
