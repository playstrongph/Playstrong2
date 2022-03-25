using System;
using System.Collections;
using ScriptableObjectScripts.GameAnimationAssets;
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
        /// Damage dealt to health, used in health text animation
        /// </summary>
        public int HealthDamage { get; private set; }
        
        /// <summary>
        /// Damage dealt to armor, used in armor text animation
        /// </summary>
        public int ArmorDamage { get; private set; }
        
        
        
        [Header("ANIMATIONS")]
        [SerializeField]
        [RequireInterfaceAttribute.RequireInterface(typeof(IGameAnimationsAsset))]
        private ScriptableObject damageAnimationAsset;
        /// <summary>
        /// Damage animation asset
        /// </summary>
        private IGameAnimationsAsset DamageAnimationAsset
        {
            get => damageAnimationAsset as IGameAnimationsAsset;
            set => damageAnimationAsset = value as ScriptableObject;
        }
        
        [SerializeField]
        [RequireInterfaceAttribute.RequireInterface(typeof(IGameAnimationsAsset))]
        private ScriptableObject criticalDamageAnimationAsset;
        /// <summary>
        /// Damage animation asset
        /// </summary>
        private IGameAnimationsAsset CriticalDamageAnimationAsset
        {
            get => criticalDamageAnimationAsset as IGameAnimationsAsset;
            set => criticalDamageAnimationAsset = value as ScriptableObject;
        }
        
        

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        /// <summary>
        /// Take single attack damage 
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        public IEnumerator TakeSingleAttackDamage(IHero casterHero,IHero targetHero,int nonCriticalDamage, int criticalDamage)
        {
            //var targetedHero = _heroLogic.Hero;
            //var casterHero = targetedHero.HeroLogic.LastHeroTargets.TargetingHero;
            
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            //Penetrate armor calculation
            var chance = casterHero.HeroLogic.ChanceAttributes.PenetrateArmorChance;
            var resistance = targetHero.HeroLogic.ResistanceAttributes.PenetrateArmorResistance;
            var netChance = chance - resistance;
            var randomChance = Random.Range(1, 101);
            
            logicTree.AddCurrent(BeforeHeroTakesSkillDamageEvent(casterHero,targetHero));
            
            //Single Attack Type Damage
            logicTree.AddCurrent(ComputeSingleAttackDamage(targetHero,nonCriticalDamage, criticalDamage));

            //Apply take damage
            logicTree.AddCurrent(randomChance <= netChance
                ? HeroTakesDamageIgnoreArmor(targetHero,FinalDamageTaken,criticalDamage)
                : HeroTakesDamage(targetHero,FinalDamageTaken,criticalDamage));

            logicTree.AddCurrent(AfterHeroTakesSkillDamageEvent(casterHero,targetHero));
            
            //Check if hero dies
            logicTree.AddCurrent(CheckIfHeroDies(targetHero));
            

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Take multi attack damage
        /// </summary>
        ///  <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        public IEnumerator TakeMultiAttackDamage(IHero casterHero, IHero targetHero, int nonCriticalDamage, int criticalDamage)
        {
            //var targetedHero = _heroLogic.Hero;
            //var casterHero = targetedHero.HeroLogic.LastHeroTargets.TargetingHero;
            
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            //Penetrate armor calculation
            var chance = casterHero.HeroLogic.ChanceAttributes.PenetrateArmorChance;
            var resistance = targetHero.HeroLogic.ResistanceAttributes.PenetrateArmorResistance;
            var netChance = chance - resistance;
            var randomChance = Random.Range(1, 101);
            
            logicTree.AddCurrent(BeforeHeroTakesSkillDamageEvent(casterHero,targetHero));
            
            //Multi Attack Type Damage
            logicTree.AddCurrent(ComputeMultiAttackDamage(targetHero,nonCriticalDamage, criticalDamage));

            //Apply take damage
            logicTree.AddCurrent(randomChance <= netChance
                ? HeroTakesDamageIgnoreArmor(targetHero,FinalDamageTaken,criticalDamage)
                : HeroTakesDamage(targetHero,FinalDamageTaken,criticalDamage));

            logicTree.AddCurrent(AfterHeroTakesSkillDamageEvent(casterHero,targetHero));
            
            //Check if hero dies
            logicTree.AddCurrent(CheckIfHeroDies(targetHero));

            logicTree.EndSequence();
            yield return null;

        }
        
        /// <summary>
        /// Non-attack skill damage - e.g. passive skill damage
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="nonAttackSkillDamage"></param>
        /// <param name="penetrateArmorChance"></param>
        /// <returns></returns>
        public IEnumerator TakeNonAttackSkillDamage(IHero casterHero, IHero targetHero, int nonAttackSkillDamage, int penetrateArmorChance)
        {
            //var targetedHero = _heroLogic.Hero;
            //var casterHero = targetedHero.HeroLogic.LastHeroTargets.TargetingHero;
            
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            //Penetrate armor calculation
            var chance = casterHero.HeroLogic.ChanceAttributes.PenetrateArmorChance + penetrateArmorChance;
            var resistance = targetHero.HeroLogic.ResistanceAttributes.PenetrateArmorResistance;
            var netChance = chance - resistance;
            var randomChance = Random.Range(1, 101);
            
            logicTree.AddCurrent(BeforeHeroTakesSkillDamageEvent(casterHero,targetHero));
            
            //Non-attack skill damage
            logicTree.AddCurrent(ComputeNonAttackSkillDamage(targetHero,nonAttackSkillDamage,0));

            //Apply take damage
            logicTree.AddCurrent(randomChance <= netChance
                ? HeroTakesDamageIgnoreArmor(targetHero,FinalDamageTaken,0)
                : HeroTakesDamage(targetHero,FinalDamageTaken,0));
            
            logicTree.AddCurrent(AfterHeroTakesSkillDamageEvent(casterHero,targetHero));
            
            //Check if hero dies
            logicTree.AddCurrent(CheckIfHeroDies(targetHero));

            logicTree.EndSequence();
            yield return null;

        }
        
        /// <summary>
        /// Non-skill damage - e.g. status effect damage, weapon damage
        /// TODO:  caster Hero not required, for cleanup. 
        /// </summary>
        /// <param name="targetHero"></param>
        /// <param name="nonSkillDamage"></param>
        /// <param name="penetrateArmorChance"></param>
        /// <returns></returns>
        public IEnumerator TakeNonSkillDamage(IHero targetHero,int nonSkillDamage, int penetrateArmorChance)
        {
            //var targetedHero = _heroLogic.Hero;
            
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            //Penetrate armor calculation
            var resistance = targetHero.HeroLogic.ResistanceAttributes.PenetrateArmorResistance;
            var netChance = penetrateArmorChance - resistance;
            var randomChance = Random.Range(1, 101);
            
            
            logicTree.AddCurrent(BeforeHeroTakesNonSkillDamageEvent());
            
            //Non-skill Damage
            logicTree.AddCurrent(ComputeNonSkillDamage(targetHero,nonSkillDamage,0));

            //Apply take damage
            logicTree.AddCurrent(randomChance <= netChance
                ? HeroTakesDamageIgnoreArmor(targetHero,FinalDamageTaken,0)
                : HeroTakesDamage(targetHero,FinalDamageTaken,0));
            
            logicTree.AddCurrent(AfterHeroTakesNonSkillDamageEvent());
            
            //Check if hero dies
            logicTree.AddCurrent(CheckIfHeroDies(targetHero));

            logicTree.EndSequence();
            yield return null;

        }
        
        private IEnumerator CheckIfHeroDies(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            
            targetHero.HeroLogic.HeroDies.CheckFatalDamage(targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Computes damage to armor and health
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="finalDamage"></param>
        /// /// <param name="criticalDamage"></param>
        /// <returns></returns>
        private IEnumerator HeroTakesDamage(IHero hero,int finalDamage, int criticalDamage)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            var visualTree = hero.CoroutineTrees.MainVisualTree;

            ComputeNewArmor(hero,finalDamage);
            ComputeNewHealth(hero,_residualDamage);

            visualTree.AddCurrent(criticalDamage > 0 ? PlayCriticalDamageAnimation(hero) : PlayDamageAnimation(hero));

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Direct health damage, ignores hero armor
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="finalDamage"></param>
        ///  /// <param name="criticalDamage"></param>
        /// <returns></returns>
        private IEnumerator HeroTakesDamageIgnoreArmor(IHero hero,int finalDamage, int criticalDamage)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            var visualTree = hero.CoroutineTrees.MainVisualTree;
            
            ComputeNewHealth(hero,finalDamage);

            visualTree.AddCurrent(criticalDamage > 0 ? PlayCriticalDamageAnimation(hero) : PlayDamageAnimation(hero));

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Damage animation when hero takes damage
        /// </summary>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        private IEnumerator PlayDamageAnimation(IHero targetHero)
        {
            var visualTree = targetHero.CoroutineTrees.MainVisualTree;
            
            DamageAnimationAsset.PlayAnimation(targetHero);  
            
            visualTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Critical Damage animation when hero takes damage
        /// </summary>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        private IEnumerator PlayCriticalDamageAnimation(IHero targetHero)
        {
            var visualTree = targetHero.CoroutineTrees.MainVisualTree;
            
            CriticalDamageAnimationAsset.PlayAnimation(targetHero);  
            
            visualTree.EndSequence();
            yield return null;
        }



        #region COMPUTE DAMAGE
        
        /// <summary>
        /// Calculates final single attack take damage
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        private IEnumerator ComputeSingleAttackDamage(IHero hero,int nonCriticalDamage, int criticalDamage)
        {
            
            
            var allDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.AllTakeDamageReduction/100f,1);
            
            var singleAttackDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.SingleTakeDamageReduction/100f,1);
            
            var skillDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.SkillTakeDamageReduction/100f,1);
            
            var damage = criticalDamage + nonCriticalDamage;

            var floatFinalDamage = (1 - allDamageReduction) * (1 - singleAttackDamageReduction) *
                (1 - skillDamageReduction) * damage;

            FinalDamageTaken = Mathf.RoundToInt(floatFinalDamage);
            
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            logicTree.EndSequence();
            yield return null;

        }
        
        /// <summary>
        /// Calculates final multi attack take damage
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        private IEnumerator ComputeMultiAttackDamage(IHero hero,int nonCriticalDamage, int criticalDamage)
        {
            var allDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.AllTakeDamageReduction/100f,1);
            
            var multiAttackDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.MultiTakeDamageReduction/100f,1);
            
            var skillDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.SkillTakeDamageReduction/100f,1);
            
            var damage = criticalDamage + nonCriticalDamage;

            var floatFinalDamage = (1 - allDamageReduction) * (1 - multiAttackDamageReduction) *
                (1 - skillDamageReduction) * damage;

            FinalDamageTaken = Mathf.RoundToInt(floatFinalDamage);
            
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Calculates the final non-attack skill damage
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        private IEnumerator ComputeNonAttackSkillDamage(IHero hero,int nonCriticalDamage, int criticalDamage)
        {
            var allDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.AllTakeDamageReduction/100f,1);
            
            var skillDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.SkillTakeDamageReduction/100f,1);
            
            var damage = criticalDamage + nonCriticalDamage;

            var floatFinalDamage = (1 - allDamageReduction) * (1 - skillDamageReduction) * damage;

            FinalDamageTaken = Mathf.RoundToInt(floatFinalDamage);
            
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Calculates the final non-skill damage
        /// </summary>
        ///  <param name="hero"></param>
        /// <param name="nonCriticalDamage"></param>
        /// <param name="criticalDamage"></param>
        /// <returns></returns>
        private IEnumerator ComputeNonSkillDamage(IHero hero,int nonCriticalDamage, int criticalDamage)
        {
            var allDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.AllTakeDamageReduction/100f,1);
            
            var nonSkillDamageReduction = Mathf.Min(hero.HeroLogic.DamageAttributes.NonSkillTakeDamageReduction/100f,1);
            
            var damage = criticalDamage + nonCriticalDamage;

            var floatFinalDamage = (1 - allDamageReduction) * (1 - nonSkillDamageReduction) * damage;

            FinalDamageTaken = Mathf.RoundToInt(floatFinalDamage);
            
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Calculates the value of the new armor
        /// and residual damage
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="damage"></param>
        private void ComputeNewArmor(IHero hero, int damage)
        {
            var armor = hero.HeroLogic.HeroAttributes.Armor;

            ArmorDamage = damage;

            //No residual damage when armor is greater than damage
            _residualDamage = Mathf.Max(0,damage - armor);
            
            //New armor is zero when damage is greater than armor
            var newArmor = Mathf.Max(0, armor - damage);
            
            //Update armor attribute
            hero.HeroLogic.SetArmor.StartAction(newArmor);

        }
        
        /// <summary>
        /// Calculates the value of new health
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="damage"></param>
        private void ComputeNewHealth(IHero hero,int damage)
        {
            var health = hero.HeroLogic.HeroAttributes.Health;
            var newHealth = health - damage;
            
            //Used by visual updates to check if there is health damage
            HealthDamage = damage;
            
            hero.HeroLogic.SetHealth.StartAction(newHealth);
        }


        //TODO: Visual Updates

        #endregion

        #region EVENTS
        
        /// <summary>
        /// Before targeted hero takes skill damage
        /// TODO: make public and transfer to basic action
        /// </summary>
        /// <returns></returns>
        private IEnumerator BeforeHeroTakesSkillDamageEvent(IHero casterHero,IHero targetHero)
        {
            var logicTree = _heroLogic.Hero.CoroutineTrees.MainLogicTree;
            
           _heroLogic.HeroEvents.EventBeforeHeroTakesSkillDamage(casterHero,targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// After targeted hero takes skill damage
        ///  TODO: make public and transfer to basic action
        /// </summary>
        /// <returns></returns>
        private IEnumerator AfterHeroTakesSkillDamageEvent(IHero casterHero,IHero targetHero)
        {
            var logicTree = _heroLogic.Hero.CoroutineTrees.MainLogicTree;
            
            _heroLogic.HeroEvents.EventAfterHeroTakesSkillDamage(casterHero,targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Before targeted hero takes non-skill damage
        ///  TODO: make public and transfer to basic action
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
        /// TODO: make public and transfer to basic action
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
