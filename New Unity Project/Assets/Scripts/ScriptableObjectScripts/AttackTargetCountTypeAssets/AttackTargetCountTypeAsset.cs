using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.AttackTargetCountTypeAssets
{
    public abstract class AttackTargetCountTypeAsset : ScriptableObject, IAttackTargetCountTypeAsset
    {
        public virtual IEnumerator StartAction(IDealDamage dealDamage, IHero hero, int nonCriticalDamage, int criticalDamage)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            Debug.Log("For Overload");
            
            logicTree.EndSequence();
            yield return null;
        }

        #region EVENTS

        /// <summary>
        /// Before hero deals singe attack events
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        protected IEnumerator PreSingleAttackEvents(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            casterHero.HeroLogic.HeroEvents.EventBeforeHeroDealsSingleTargetAttack(casterHero);
            targetedHero.HeroLogic.HeroEvents.EventBeforeHeroTakesSingleTargetAttack(targetedHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// After hero deals singe attack events
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        protected IEnumerator PostSingleAttackEvents(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            casterHero.HeroLogic.HeroEvents.EventAfterHeroDealsSingleTargetAttack(casterHero);
            targetedHero.HeroLogic.HeroEvents.EventAfterHeroTakesSingleTargetAttack(targetedHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Before hero deals multi attack events
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        protected IEnumerator PreMultiAttackEvents(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            casterHero.HeroLogic.HeroEvents.EventBeforeHeroDealsMultiTargetAttack(casterHero);
            targetedHero.HeroLogic.HeroEvents.EventBeforeHeroTakesMultiTargetAttack(targetedHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// After hero deals multi attack events
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        protected IEnumerator PostMultiAttackEvents(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            casterHero.HeroLogic.HeroEvents.EventAfterHeroDealsMultiTargetAttack(casterHero);
            targetedHero.HeroLogic.HeroEvents.EventAfterHeroTakesMultiTargetAttack(targetedHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        #endregion


    }
}
