using System.Collections;
using Logic;
using ScriptableObjectScripts.BasicActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.HeroLifeStatusAssets
{
    public abstract class HeroLifeStatusAsset : ScriptableObject, IHeroLifeStatusAsset
    {
        /// <summary>
        /// After confirming target is alive, check if caster is alive
        /// before implementing the basic action's main execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public virtual void TargetMainExecutionAction(IBasicActionAsset basicAction, IHero hero)
        {
            
        }
        
        /// <summary>
        /// After confirming the caster is alive, implement the basic action's
        /// main execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public virtual void CasterMainExecutionAction(IBasicActionAsset basicAction, IHero hero)
        {
            
        }

        /// <summary>
        /// After confirming target is alive, check if caster is alive
        /// before implementing the basic action's pre execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public virtual void TargetPreExecutionAction(IBasicActionAsset basicAction, IHero hero)
        {
            
        }
        
        /// <summary>
        /// After confirming the caster is alive, implement the basic action's
        /// pre execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public virtual void CasterPreExecutionAction(IBasicActionAsset basicAction, IHero hero)
        {
            
        }
        
        /// <summary>
        /// After confirming target is alive, check if caster is alive
        /// before implementing the basic action's post execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public virtual void TargetPostExecutionAction(IBasicActionAsset basicAction, IHero hero)
        {
            
        }
        
        /// <summary>
        /// After confirming the caster is alive, implement the basic action's
        /// post execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public virtual void CasterPostExecutionAction(IBasicActionAsset basicAction, IHero hero)
        {
            
        }
        
       /// <summary>
       ///  After confirming target is alive, check if caster is alive
       /// before implementing the basic action's main animation action
       /// </summary>
       /// <param name="basicAction"></param>
       /// <param name="hero"></param>
        public virtual void TargetMainAnimation(IBasicActionAsset basicAction, IHero hero)
        {
            
        }
        
        /// <summary>
        ///  After confirming the caster is alive, implement the basic action's
        ///  main animation action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public virtual void CasterMainAnimation(IBasicActionAsset basicAction, IHero hero)
        {
            
        }
        
        /// <summary>
        /// Update the caster hero's target hero - in the case of multiple targets
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        protected IEnumerator SetTargetHero(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            var casterHero = hero.HeroLogic.LastHeroTargets.TargetingHero;
            
            casterHero.HeroLogic.LastHeroTargets.SetTargetedHero(hero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        

    }
}
