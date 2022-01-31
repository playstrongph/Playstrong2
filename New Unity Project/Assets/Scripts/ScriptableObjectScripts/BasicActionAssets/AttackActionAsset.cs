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
        
        //TEST
        [SerializeField]
        [RequireInterfaceAttribute.RequireInterface(typeof(IGameAnimationsAsset))]
        private ScriptableObject heroAttributeAnimationAsset;

        private IGameAnimationsAsset HeroAttributeAnimationAsset
        {
            get => heroAttributeAnimationAsset as IGameAnimationsAsset;
            set => heroAttributeAnimationAsset = value as ScriptableObject;
        }

        
        /// <summary>
        /// Called after confirming target and caster hero are still both alive
        /// </summary>
        /// <param name="targetedHero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero targetedHero)
        {
            var logicTree = targetedHero.CoroutineTrees.MainLogicTree;
            
            //Check hero inability status before proceeding with attack action
            targetedHero.HeroLogic.HeroInabilityStatus.AttackAction(this, targetedHero);

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
        
        /// <summary>
        /// Critical attack damage is zero
        /// </summary>
        /// <param name="casterHero"></param>
        private void NormalAttack(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree; 
            var dealDamage = casterHero.HeroLogic.DealDamage;
            var nonCriticalAttackDamage = casterHero.HeroLogic.HeroAttributes.Attack + flatValue;
            var criticalAttackDamage = 0;

            //Attack target based on attack target count type - single or multi attack
            logicTree.AddCurrent(AttackTargetCountType.StartAction(dealDamage,casterHero,nonCriticalAttackDamage,criticalAttackDamage));
        }
        
        /// <summary>
        /// Critical attack damaged calculated based on critical factor 
        /// </summary>
        /// <param name="casterHero"></param>
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
        /// Basic action animation
        /// </summary>
        /// <param name="targetedHero"></param>
        /// <returns></returns>
        public override IEnumerator MainAnimationAction(IHero targetedHero)
        {
            var logicTree = targetedHero.CoroutineTrees.MainLogicTree;
            var visualTree = targetedHero.CoroutineTrees.MainVisualTree;

            visualTree.AddCurrent(BasicActionAnimation(targetedHero));
            
            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Attack hero animation
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        private IEnumerator BasicActionAnimation(IHero casterHero)
        {
            var visualTree = casterHero.CoroutineTrees.MainVisualTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            var s = DOTween.Sequence();
            var attackAnimationInterval = AttackAnimationAsset.AnimationDuration;
            
            //var damageAnimationInterval = DamageAnimationAsset.AnimationDuration;
            
            //Set the value of the main animation duration
            MainAnimationDuration = attackAnimationInterval;

            s.AppendCallback(() => AttackAnimationAsset.PlayAnimation(casterHero))
                .AppendInterval(attackAnimationInterval)
                .AppendCallback(() => DamageAnimationAsset.PlayAnimation(targetedHero))
                //.AppendInterval(damageAnimationInterval)
                .AppendCallback(() => targetedHero.HeroVisual.SetArmorVisual.StartAction())
                .AppendCallback(() => targetedHero.HeroVisual.SetHealthVisual.StartAction())
                .AppendCallback(() => AnimateUpdateArmorAndHealthText(targetedHero));

            visualTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Armor and Health text animation
        /// </summary>
        /// <param name="targetedHero"></param>
        private void AnimateUpdateArmorAndHealthText(IHero targetedHero)
        {
            HeroAttributeAnimationAsset.PlayAnimation(targetedHero.HeroVisual.ArmorVisual.Text);
            
            //Animate health only when damage taken is greater than zero
            if(targetedHero.HeroLogic.TakeDamage.HealthDamage > 0 )
                HeroAttributeAnimationAsset.PlayAnimation(targetedHero.HeroVisual.HealthVisual.Text);
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

        #endregion


        #region OLD LOGIC

        /*/// <summary>
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

        }*/
        
         /*/// <summary>
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
        }*/

        #endregion


    }
}
