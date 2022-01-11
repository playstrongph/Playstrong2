using System.Collections;
using Logic;
using ScriptableObjectScripts.AttackTargetCountTypeAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "AttackAction", menuName = "Assets/BasicActions/A/AttackAction")]
    public class AttackActionAsset : BasicActionAsset, IAttackHero
    {
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
            
            //Before hero attacks events
            logicTree.AddCurrent(PreSkillAttackEvents(hero));
            logicTree.AddCurrent(PreAttackEvents(hero));

            logicTree.AddCurrent(NormalOrCriticalAttack(hero));
            
            //After hero attacks events
            logicTree.AddCurrent(PostAttackEvents(hero));
            logicTree.AddCurrent(PostSkillAttackEvents(hero));
            
            //logicTree.EndSequence();
            //yield return null;
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
            
            
            logicTree.AddCurrent(PreCriticalAttackEvents(casterHero));
            
            //Attack target based on attack target count type - single or multi attack
            logicTree.AddCurrent(AttackTargetCountType.StartAction(dealDamage,casterHero,nonCriticalAttackDamage,criticalAttackDamage));

            logicTree.AddCurrent(PostCriticalAttackEvents(casterHero));
            
        }
        
        

        #region EVENTS
        
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
