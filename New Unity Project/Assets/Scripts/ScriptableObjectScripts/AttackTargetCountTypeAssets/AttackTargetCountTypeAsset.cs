using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.AttackTargetCountTypeAssets
{
    public abstract class AttackTargetCountTypeAsset : ScriptableObject, IAttackTargetCountTypeAsset
    {
        public virtual IEnumerator StartAction(IDealDamage dealDamage, IHero casterHero, IHero targetHero, int nonCriticalDamage, int criticalDamage,int percentPenetrateArmor)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            Debug.Log("For Overload");
            
            logicTree.EndSequence();
            yield return null;
        }

        #region EVENTS

        /// <summary>
        /// Before hero deals singe attack events
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        protected IEnumerator PreSingleAttackEvents(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            //var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            //TODO: Events double argument?
            casterHero.HeroLogic.HeroEvents.EventBeforeHeroDealsSingleTargetAttack(casterHero);
            targetHero.HeroLogic.HeroEvents.EventBeforeHeroTakesSingleTargetAttack(targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// After hero deals singe attack events
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        protected IEnumerator PostSingleAttackEvents(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            //TODO: Events double argument?
            casterHero.HeroLogic.HeroEvents.EventAfterHeroDealsSingleTargetAttack(casterHero);
            targetHero.HeroLogic.HeroEvents.EventAfterHeroTakesSingleTargetAttack(targetHero);
            
         
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Before hero deals multi attack events
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        protected IEnumerator PreMultiAttackEvents(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            //TODO: Events double argument?
            casterHero.HeroLogic.HeroEvents.EventBeforeHeroDealsMultiTargetAttack(casterHero);
            targetHero.HeroLogic.HeroEvents.EventBeforeHeroTakesMultiTargetAttack(targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// After hero deals multi attack events
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        protected IEnumerator PostMultiAttackEvents(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;
            
            //TODO: Events double argument?
            casterHero.HeroLogic.HeroEvents.EventAfterHeroDealsMultiTargetAttack(casterHero);
            targetHero.HeroLogic.HeroEvents.EventAfterHeroTakesMultiTargetAttack(targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        #endregion


    }
}
