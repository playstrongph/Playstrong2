using System.Collections;
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
            //Before hero attacks events
            PreSkillAttackEvents(hero);
            PreAttackEvents(hero);
            
            //TODO: private set normal or critical attack
            
            //After hero attacks events
            PostAttackEvents(hero);
            PostSkillAttackEvents(hero);
            
        }

        #region EVENTS
        
        /// <summary>
        /// Before hero skill attacks event
        /// </summary>
        /// <param name="casterHero"></param>
        private void PreSkillAttackEvents(IHero casterHero)
        {
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            casterHero.HeroLogic.HeroEvents.EventBeforeHeroSkillAttacks(casterHero);
            targetedHero.HeroLogic.HeroEvents.EventEBeforeHeroIsSkillAttacked(targetedHero);
        }
        
        private void PreAttackEvents(IHero casterHero)
        {
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            casterHero.HeroLogic.HeroEvents.EventBeforeHeroAttacks(casterHero);
            targetedHero.HeroLogic.HeroEvents.EventBeforeHeroIsAttacked(casterHero);
        }
        
        private void PostAttackEvents(IHero casterHero)
        {
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            casterHero.HeroLogic.HeroEvents.EventAfterHeroAttacks(casterHero);
            targetedHero.HeroLogic.HeroEvents.EventAfterHeroIsAttacked(targetedHero);
        }
        
        private void PostSkillAttackEvents(IHero casterHero)
        {
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            casterHero.HeroLogic.HeroEvents.EventAfterHeroSkillAttacks(casterHero);
            targetedHero.HeroLogic.HeroEvents.EventAfterHeroIsSkillAttacked(targetedHero);

        }
        
        

        #endregion
        
       



    }
}
