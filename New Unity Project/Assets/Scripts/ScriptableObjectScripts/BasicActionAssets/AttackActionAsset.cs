﻿using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "AttackAction", menuName = "Assets/BasicActions/A/AttackAction")]
    public class AttackActionAsset : BasicActionAsset
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
        [SerializeField] private int flatValue;

        //TODO: CalculatedValue
        
        //TODO: Attack animation
        
        //TODO: AttackType - SingleTarget or MultiTarget attack

        public override IEnumerator ExecuteAction(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            //TODO: Check inability chance at HeroLogic.OtherAttributes
            AttackHero(hero);

            logicTree.EndSequence();
            yield return null;
        }
        
        private void AttackHero(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            //Before hero attacks events
            logicTree.AddCurrent(PreSkillAttackEvents(hero));
            logicTree.AddCurrent(PreAttackEvents(hero));

            logicTree.AddCurrent(NormalOrCriticalAttack(hero));
            
            //After hero attacks events
            logicTree.AddCurrent(PostAttackEvents(hero));
            logicTree.AddCurrent(PostSkillAttackEvents(hero));
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
            //TODO: DealDamage 
        }
        
        private void CriticalAttack(IHero casterHero)
        {
            //TODO: DealDamage
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
            targetedHero.HeroLogic.HeroEvents.EventBeforeHeroIsAttacked(casterHero);
            
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
        
        

        #endregion
        
       



    }
}