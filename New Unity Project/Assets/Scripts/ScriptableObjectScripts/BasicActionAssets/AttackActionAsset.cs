using System.Collections;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.AttackTargetCountTypeAssets;
using ScriptableObjectScripts.GameAnimationAssets;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "AttackAction", menuName = "Assets/BasicActions/A/AttackAction")]
    public class AttackActionAsset : BasicActionAsset, IAttackHero
    {
        
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IAttackTargetCountTypeAsset))] 
        private ScriptableObject attackTargetCountType;
        /// <summary>
        /// Indicates how many attack targets 
        /// </summary>
        private IAttackTargetCountTypeAsset AttackTargetCountType
        {
            get => attackTargetCountType as IAttackTargetCountTypeAsset;
            set => attackTargetCountType = value as ScriptableObject;
        }
        
        
        /// <summary>
        /// Skill critical strike chance.  This is additional to other
        /// critical strike factors.
        /// </summary>
        [Header("CRITICAL FACTORS")]
        [SerializeField] private int skillCriticalChance = 0;
        
        /// <summary>
        /// Additional critical damage added to other/default critical
        /// damage factors
        /// </summary>
        [SerializeField] private int skillCriticalDamage = 0;

        /// <summary>
        /// Additional flat value added to the attack damage
        /// </summary>
        [Header("ADDITIONAL DAMAGE FACTORS")] 
        [SerializeField] private int flatValue = 0;

        //TODO: CalculatedValue
        
        
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
        private ScriptableObject attackAnimationAsset;
        /// <summary>
        /// Attack animation asset
        /// </summary>
        private IGameAnimationsAsset AttackAnimationAsset
        {
            get => attackAnimationAsset as IGameAnimationsAsset;
            set => attackAnimationAsset = value as ScriptableObject;
        }



        public override IEnumerator ExecuteAction(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            //Check hero inability status before proceeding with attack action
            hero.HeroLogic.HeroInabilityStatus.AttackAction(this, hero);

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Used by Inability Asset under the interface IAttackHero
        /// </summary>
        /// <param name="hero"></param>
        public void AttackHero(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;

            logicTree.AddCurrent(NormalOrCriticalAttack(hero));
            
            //TEST - VISUAL
            //logicTree.AddCurrent(AttackHeroAnimation(hero));
        }

        /// <summary>
        /// Determines if attack is a critical strike based on critical chance and resistance
        /// Has to be a coroutine due to events
        /// </summary>
        /// <param name="casterHero"></param>
        private IEnumerator NormalOrCriticalAttack(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            var criticalChance = casterHero.HeroLogic.ChanceAttributes.CriticalChance + skillCriticalChance;
            var criticalResistance = targetedHero.HeroLogic.ResistanceAttributes.CriticalResistance;
            var netChance = criticalChance - criticalResistance;
            var randomChance = Random.Range(1, 101);
            
            
            if(randomChance<=netChance)
                CriticalAttack(casterHero);
            else
                NormalAttack(casterHero);
            
            logicTree.EndSequence();
            yield return null;
        }

        private void NormalAttack(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree; 
            var dealDamage = casterHero.HeroLogic.DealDamage;
            var nonCriticalAttackDamage = casterHero.HeroLogic.HeroAttributes.Attack + flatValue;
            var criticalAttackDamage = 0;

            //Attack target based on attack target count type - single or multi attack
            logicTree.AddCurrent(AttackTargetCountType.StartAction(dealDamage,casterHero,nonCriticalAttackDamage,criticalAttackDamage));
        }
        
        private void CriticalAttack(IHero casterHero)
        {
           
            var logicTree = casterHero.CoroutineTrees.MainLogicTree; 
            var dealDamage = casterHero.HeroLogic.DealDamage;
            var nonCriticalAttackDamage = casterHero.HeroLogic.HeroAttributes.Attack + flatValue;
            var criticalFactor = casterHero.HeroLogic.DamageAttributes.CriticalDamage + skillCriticalDamage;
            var criticalAttackDamage = Mathf.RoundToInt(criticalFactor*nonCriticalAttackDamage/100f);

            //Attack target based on attack target count type - single or multi attack
            logicTree.AddCurrent(AttackTargetCountType.StartAction(dealDamage,casterHero,nonCriticalAttackDamage,criticalAttackDamage));
        }


        #region ATTACK ANIMATION
        
        
        /// <summary>
        /// Logic tree wrapper for visual tree command
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        private IEnumerator AttackHeroAnimation(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var visualTree = casterHero.CoroutineTrees.MainVisualTree;
            
            visualTree.AddCurrent(VisualAttackHeroAnimation(casterHero));
            
            logicTree.EndSequence();
            yield return null;

        }

        /// <summary>
        /// Attack hero animation
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        private IEnumerator VisualAttackHeroAnimation(IHero casterHero)
        {
            var visualTree = casterHero.CoroutineTrees.MainVisualTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            //TODO: Temporary tween sequence here, to be moved to base class later?

            var s = DOTween.Sequence();

            var attackAnimationInterval = AttackAnimationAsset.AnimationDuration;

            var damageAnimationInterval = DamageAnimationAsset.AnimationDuration;

            s.AppendCallback(() => AttackAnimation(casterHero))
                .AppendInterval(attackAnimationInterval)
                .AppendCallback(() => DamageAnimation(targetedHero))
                .AppendInterval(damageAnimationInterval);
            
            visualTree.EndSequence();
            
            yield return null;
        }
        
        /// <summary>
        /// Damage animation played from GameAnimationsAsset
        /// </summary>
        /// <param name="targetedHero"></param>
        private void DamageAnimation(IHero targetedHero)
        {
            DamageAnimationAsset.PlayAnimation(targetedHero);
        }
        
        /// <summary>
        /// Attack animation played from GameAnimationAsset
        /// </summary>
        /// <param name="casterHero"></param>
        private void AttackAnimation(IHero casterHero)
        {
           AttackAnimationAsset.PlayAnimation(casterHero);    
        }
        
        
        //TEST
        public override IEnumerator MainAnimation(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var visualTree = casterHero.CoroutineTrees.MainVisualTree;
            
            visualTree.AddCurrent(VisualAttackHeroAnimation(casterHero));
            
            logicTree.EndSequence();
            yield return null;
        }

        #endregion



        #region EVENTS
        
        public override IEnumerator PreExecuteActionEvents(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            
            //Pre-skill attack
            casterHero.HeroLogic.HeroEvents.EventBeforeHeroSkillAttacks(casterHero);
            targetedHero.HeroLogic.HeroEvents.EventEBeforeHeroIsSkillAttacked(targetedHero);
            
            //Pre-attack
            casterHero.HeroLogic.HeroEvents.EventBeforeHeroAttacks(casterHero);
            targetedHero.HeroLogic.HeroEvents.EventBeforeHeroIsAttacked(targetedHero);
            
            //Pre-Critical
            PreCriticalAttackEvent(casterHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator PostExecuteActionEvents(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            //Post-skill attack
            casterHero.HeroLogic.HeroEvents.EventAfterHeroAttacks(casterHero);
            targetedHero.HeroLogic.HeroEvents.EventAfterHeroIsAttacked(targetedHero);
            
            //Post-attack
            casterHero.HeroLogic.HeroEvents.EventAfterHeroAttacks(casterHero);
            targetedHero.HeroLogic.HeroEvents.EventAfterHeroIsAttacked(targetedHero);
            
            //Post-Critical
            PostCriticalAttackEvent(casterHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Determines if Pre-critical attack events are called
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        private void PreCriticalAttackEvent(IHero casterHero)
        {
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            var criticalChance = casterHero.HeroLogic.ChanceAttributes.CriticalChance + skillCriticalChance;
            var criticalResistance = targetedHero.HeroLogic.ResistanceAttributes.CriticalResistance;
            var netChance = criticalChance - criticalResistance;
            var randomChance = Random.Range(1, 101);


            if (randomChance <= netChance)
            {
                casterHero.HeroLogic.HeroEvents.EventBeforeHeroCriticalStrikes(casterHero);
                targetedHero.HeroLogic.HeroEvents.EventBeforeHeroIsDealtCriticalStrike(targetedHero);
            }

        }
        
        /// <summary>
        /// Determines if Pre-critical attack events are called
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        private void PostCriticalAttackEvent(IHero casterHero)
        {
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            var criticalChance = casterHero.HeroLogic.ChanceAttributes.CriticalChance + skillCriticalChance;
            var criticalResistance = targetedHero.HeroLogic.ResistanceAttributes.CriticalResistance;
            var netChance = criticalChance - criticalResistance;
            var randomChance = Random.Range(1, 101);


            if (randomChance <= netChance)
            {
                casterHero.HeroLogic.HeroEvents.EventAfterHeroDealsCriticalStrike(casterHero);
                targetedHero.HeroLogic.HeroEvents.EventAfterHeroIsDealtCriticalStrike(targetedHero);
            }

        }
        
        
        /// <summary>
        /// Before hero skill attacks event
        /// </summary>
        /// <param name="casterHero"></param>
        private IEnumerator PreSkillAttackEvents(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;

            casterHero.HeroLogic.HeroEvents.EventBeforeHeroSkillAttacks(casterHero);
            targetedHero.HeroLogic.HeroEvents.EventEBeforeHeroIsSkillAttacked(targetedHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Before hero attacks event
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        private IEnumerator PreAttackEvents(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            casterHero.HeroLogic.HeroEvents.EventBeforeHeroAttacks(casterHero);
            targetedHero.HeroLogic.HeroEvents.EventBeforeHeroIsAttacked(targetedHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// After hero attacks event
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        private IEnumerator PostAttackEvents(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            casterHero.HeroLogic.HeroEvents.EventAfterHeroAttacks(casterHero);
            targetedHero.HeroLogic.HeroEvents.EventAfterHeroIsAttacked(targetedHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// After hero skill attacks event
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        private IEnumerator PostSkillAttackEvents(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            casterHero.HeroLogic.HeroEvents.EventAfterHeroSkillAttacks(casterHero);
            targetedHero.HeroLogic.HeroEvents.EventAfterHeroIsSkillAttacked(targetedHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Before hero deals critical strike attack event
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        private IEnumerator PreCriticalAttackEvents(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            casterHero.HeroLogic.HeroEvents.EventBeforeHeroCriticalStrikes(casterHero);
            targetedHero.HeroLogic.HeroEvents.EventBeforeHeroIsDealtCriticalStrike(targetedHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// After hero deals critical strike attack event
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        private IEnumerator PostCriticalAttackEvents(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            casterHero.HeroLogic.HeroEvents.EventAfterHeroDealsCriticalStrike(casterHero);
            targetedHero.HeroLogic.HeroEvents.EventAfterHeroIsDealtCriticalStrike(targetedHero);
            
            logicTree.EndSequence();
            yield return null;
        }



        #endregion
        
       



    }
}
