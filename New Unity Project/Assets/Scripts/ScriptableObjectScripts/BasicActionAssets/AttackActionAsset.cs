using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.AttackTargetCountTypeAssets;
using ScriptableObjectScripts.GameAnimationAssets;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "AttackAction", menuName = "Assets/BasicActions/A/AttackAction")]
    public class AttackActionAsset : BasicActionAsset
    {

        #region VARIABLES
        
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

        [Header("ANIMATIONS")]

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

        /// <summary>
        /// TEST
        /// Pre attack animation
        /// </summary>
        [SerializeField]
        [RequireInterfaceAttribute.RequireInterface(typeof(IGameAnimationsAsset))]
        private ScriptableObject preActionAnimationAsset;
        /// <summary>
        /// Attack animation asset
        /// </summary>
        private IGameAnimationsAsset PreActionAnimationAsset
        {
            get => preActionAnimationAsset as IGameAnimationsAsset;
            set => preActionAnimationAsset = value as ScriptableObject;
        }
        
        [SerializeField]
        [RequireInterfaceAttribute.RequireInterface(typeof(IGameAnimationsAsset))]
        private ScriptableObject criticalStrikeAnimationAsset;
        /// <summary>
        /// Critical Attack animation asset
        /// </summary>
        private IGameAnimationsAsset CriticalStrikeAnimationAsset
        {
            get => preActionAnimationAsset as IGameAnimationsAsset;
            set => preActionAnimationAsset = value as ScriptableObject;
        }
        

        #endregion

        #region EXECUTION

         
        /// <summary>
        /// The specific logic-visual sequence for basic action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        protected override IEnumerator MainBasicActionPhase(IHero casterHero, IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //Pure attack animation
            //TODO: transfer this to execute action
            logicTree.AddCurrent(AttackVisualAction(casterHero));

            //base class method that calls execute action after checking life status and inability status
            logicTree.AddCurrent(MainAction(casterHero));

            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Calls the basic action's specific effects
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            AttackHero(casterHero,targetHero);

            logicTree.EndSequence();
            yield return null;
        }
        

        /// <summary>
        /// Used by Inability Asset under the interface IAttackHero
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        private void AttackHero(IHero casterHero,IHero targetHero)
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
            //Calls DealDamage, TakeDamage, and checks for hero deaths
            logicTree.AddCurrent(AttackTargetCountType.StartAction(dealDamage,casterHero,targetHero,nonCriticalAttackDamage,criticalAttackDamage));
            
            //TODO: Check if DealDamage and TakeDamage need to be isolated in the future because of its events

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
            //Calls deal damage and take damage
            logicTree.AddCurrent(AttackTargetCountType.StartAction(dealDamage,casterHero, targetHero,nonCriticalAttackDamage,criticalAttackDamage));
            
        }
        
        

        #endregion

        #region ANIMATION
        
         /// <summary>
        /// This is the attack animation and its delay interval
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        private IEnumerator AttackVisualAction(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var visualTree = casterHero.CoroutineTrees.MainVisualTree;
            
            //Parallel animation processing for multiple targets
            foreach (var hero in ExecuteActionTargetHeroes)
            {
                visualTree.AddCurrent(AttackAnimationVisual(casterHero,hero));
            }
            
            //Single delay interval for parallel animations.  Don't call if there are no heroes alive 
            if(ExecuteActionTargetHeroes.Count > 0)
                visualTree.AddCurrent(AttackAnimationInterval(casterHero));
           
            logicTree.EndSequence(); 
            yield return null;
        }
        
         /// <summary>
         /// Attack animation
         /// </summary>
         /// <param name="casterHero"></param>
         /// <param name="targetHero"></param>
         /// <returns></returns>
        private IEnumerator AttackAnimationVisual(IHero casterHero, IHero targetHero)
        {
             var visualTree = casterHero.CoroutineTrees.MainVisualTree;

             AttackAnimationAsset.PlayAnimation(casterHero, targetHero); 
             
             visualTree.EndSequence();
             yield return null;
        }

         /// <summary>
         /// Attack animation delay interval
         /// </summary>
         /// <param name="casterHero"></param>
         /// <returns></returns>
         private IEnumerator AttackAnimationInterval(IHero casterHero)
         {
             var visualTree = casterHero.CoroutineTrees.MainVisualTree;
             var sequence = DOTween.Sequence();
             var attackAnimationInterval = AttackAnimationAsset.AnimationDuration;

             
             sequence
                 .AppendInterval(attackAnimationInterval)
                 //This is the animation delay interval
                 .AppendCallback(() => visualTree.EndSequence());
             
             yield return null;
         }


         protected override IEnumerator PreActionAnimation(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var visualTree = casterHero.CoroutineTrees.MainVisualTree;
            
            visualTree.AddCurrent(PreActionVisualAnimation(casterHero));
            
            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Pre-action visuals
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        private IEnumerator PreActionVisualAnimation(IHero casterHero)
        {
            var visualTree = casterHero.CoroutineTrees.MainVisualTree;
            
            PreActionAnimationAsset.PlayAnimation(casterHero);
            
            visualTree.EndSequence();
            yield return null;
        }

      

        #endregion

        #region EVENTS
        
        /// <summary>
        /// All events before main basic action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator CallPreBasicActionEvents(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            //Pre-skill attack
            casterHero.HeroLogic.HeroEvents.EventBeforeHeroSkillAttacks(casterHero);
            targetHero.HeroLogic.HeroEvents.EventEBeforeHeroIsSkillAttacked(targetHero);
            
            //Pre-attack
            casterHero.HeroLogic.HeroEvents.EventBeforeHeroAttacks(casterHero);
            targetHero.HeroLogic.HeroEvents.EventBeforeHeroIsAttacked(targetHero);
            
            //Pre-Critical
            PreCriticalAttackEvent(casterHero,targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// All events after main basic action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator CallPostBasicActionEvents(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            //Post-skill attack
            casterHero.HeroLogic.HeroEvents.EventAfterHeroSkillAttacks(casterHero);
            targetHero.HeroLogic.HeroEvents.EventAfterHeroIsSkillAttacked(targetHero);
            
            //Post-attack
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

    }
}
