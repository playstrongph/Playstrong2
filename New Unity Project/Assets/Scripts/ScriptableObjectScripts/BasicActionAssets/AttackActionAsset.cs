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
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //Check hero inability status before proceeding with attack action
            //this is for counter-attack effects
            casterHero.HeroLogic.HeroInabilityStatus.AttackAction(this, casterHero,targetHero);

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Used by Inability Asset under the interface IAttackHero
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        public void AttackHero(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            logicTree.AddCurrent(NormalOrCriticalAttack(casterHero,targetHero));
        }

        /// <summary>
        /// Determines if attack is a critical strike based on critical chance and resistance
        /// Has to be a coroutine due to events
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        private IEnumerator NormalOrCriticalAttack(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            var criticalChance = casterHero.HeroLogic.ChanceAttributes.CriticalChance + skillCriticalChance;
            var criticalResistance = targetHero.HeroLogic.ResistanceAttributes.CriticalResistance;
            var netChance = criticalChance - criticalResistance;
            var randomChance = Random.Range(1, 101);
            
            
            if(randomChance<=netChance)
                CriticalAttack(casterHero,targetHero);
            else
                NormalAttack(casterHero,targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Critical attack damage is zero
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        private void NormalAttack(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree; 
            var dealDamage = casterHero.HeroLogic.DealDamage;
            var nonCriticalAttackDamage = casterHero.HeroLogic.HeroAttributes.Attack + flatValue;
            var criticalAttackDamage = 0;

            //Attack target based on attack target count type - single or multi attack
            logicTree.AddCurrent(AttackTargetCountType.StartAction(dealDamage,casterHero,targetHero,nonCriticalAttackDamage,criticalAttackDamage));
        }
        
        /// <summary>
        /// Critical attack damaged calculated based on critical factor 
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        private void CriticalAttack(IHero casterHero,IHero targetHero)
        {
           
            var logicTree = casterHero.CoroutineTrees.MainLogicTree; 
            var dealDamage = casterHero.HeroLogic.DealDamage;
            var nonCriticalAttackDamage = casterHero.HeroLogic.HeroAttributes.Attack + flatValue;
            var criticalFactor = casterHero.HeroLogic.DamageAttributes.CriticalDamage + skillCriticalDamage;
            var criticalAttackDamage = Mathf.RoundToInt(criticalFactor*nonCriticalAttackDamage/100f);

            //Attack target based on attack target count type - single or multi attack
            logicTree.AddCurrent(AttackTargetCountType.StartAction(dealDamage,casterHero, targetHero,nonCriticalAttackDamage,criticalAttackDamage));
        }


        #region ATTACK ANIMATION
        
        /// <summary>
        /// Basic action animation
        /// </summary>
        /// <param name="targetedHero"></param>
        /// <returns></returns>
        public override IEnumerator MainAnimation(IHero casterHero, IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var visualTree = casterHero.CoroutineTrees.MainVisualTree;

            visualTree.AddCurrent(BasicAnimation(casterHero,targetHero));
            
            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Attack hero animation
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        private IEnumerator BasicAnimation(IHero casterHero,IHero targetHero)
        {
            var visualTree = casterHero.CoroutineTrees.MainVisualTree;
            
            //var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            var s = DOTween.Sequence();
            var attackAnimationInterval = AttackAnimationAsset.AnimationDuration;
            
            //var damageAnimationInterval = DamageAnimationAsset.AnimationDuration;
            
            //Set the value of the main animation duration
            MainAnimationDuration = attackAnimationInterval;

            s.AppendCallback(() => AttackAnimationAsset.PlayAnimation(casterHero))
                .AppendInterval(attackAnimationInterval)
                .AppendCallback(() => DamageAnimationAsset.PlayAnimation(targetHero))
                //.AppendInterval(damageAnimationInterval)
                .AppendCallback(() => AnimateUpdateArmorAndHealthText(targetHero));

            visualTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Armor and Health text animation
        /// </summary>
        /// <param name="targetHero"></param>
        private void AnimateUpdateArmorAndHealthText(IHero targetHero)
        {
            //Set Armor text
            targetHero.HeroVisual.SetArmorVisual.StartAction();
            //Set health text
            targetHero.HeroVisual.SetHealthVisual.StartAction();
            
            //Animate armor text
            HeroAttributeAnimationAsset.PlayAnimation(targetHero.HeroVisual.ArmorVisual.Text);
            
            //Animate health text only when damage taken is greater than zero
            if(targetHero.HeroLogic.TakeDamage.HealthDamage > 0 )
                HeroAttributeAnimationAsset.PlayAnimation(targetHero.HeroVisual.HealthVisual.Text);
        }


        #endregion



        #region EVENTS
        
        public override IEnumerator PreExecuteActionEvents(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            
            //Pre-skill attack
            //TODO - Do these events need to have double arguments as well?
            casterHero.HeroLogic.HeroEvents.EventBeforeHeroSkillAttacks(casterHero);
            targetHero.HeroLogic.HeroEvents.EventEBeforeHeroIsSkillAttacked(targetHero);
            
            //Pre-attack
            //TODO - Do these events need to have double arguments as well?
            casterHero.HeroLogic.HeroEvents.EventBeforeHeroAttacks(casterHero);
            targetHero.HeroLogic.HeroEvents.EventBeforeHeroIsAttacked(targetHero);
            
            //Pre-Critical
            PreCriticalAttackEvent(casterHero,targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator PostExecuteActionEvents(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            //Post-skill attack
            //TODO - Do these events need to have double arguments as well?
            casterHero.HeroLogic.HeroEvents.EventAfterHeroAttacks(casterHero);
            targetHero.HeroLogic.HeroEvents.EventAfterHeroIsAttacked(targetHero);
            
            //Post-attack
            //TODO - Do these events need to have double arguments as well?
            casterHero.HeroLogic.HeroEvents.EventAfterHeroAttacks(casterHero);
            targetHero.HeroLogic.HeroEvents.EventAfterHeroIsAttacked(targetHero);
            
            //Post-Critical
            PostCriticalAttackEvent(casterHero,targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Determines if Pre-critical attack events are called
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        private void PreCriticalAttackEvent(IHero casterHero,IHero targetHero)
        {
            //var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            var criticalChance = casterHero.HeroLogic.ChanceAttributes.CriticalChance + skillCriticalChance;
            var criticalResistance = targetHero.HeroLogic.ResistanceAttributes.CriticalResistance;
            var netChance = criticalChance - criticalResistance;
            var randomChance = Random.Range(1, 101);


            if (randomChance <= netChance)
            {
                //TODO - Do these events need to have double arguments as well?
                casterHero.HeroLogic.HeroEvents.EventBeforeHeroCriticalStrikes(casterHero);
                targetHero.HeroLogic.HeroEvents.EventBeforeHeroIsDealtCriticalStrike(targetHero);
            }

        }
        
        /// <summary>
        /// Determines if Pre-critical attack events are called
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        /// <returns></returns>
        private void PostCriticalAttackEvent(IHero casterHero,IHero targetHero)
        {
            //var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            var criticalChance = casterHero.HeroLogic.ChanceAttributes.CriticalChance + skillCriticalChance;
            var criticalResistance = targetHero.HeroLogic.ResistanceAttributes.CriticalResistance;
            var netChance = criticalChance - criticalResistance;
            var randomChance = Random.Range(1, 101);


            if (randomChance <= netChance)
            {
                //TODO - Do these events need to have double arguments as well?
                casterHero.HeroLogic.HeroEvents.EventAfterHeroDealsCriticalStrike(casterHero);
                targetHero.HeroLogic.HeroEvents.EventAfterHeroIsDealtCriticalStrike(targetHero);
            }

        }

        #endregion


        #region OLD LOGIC

        #endregion


    }
}
