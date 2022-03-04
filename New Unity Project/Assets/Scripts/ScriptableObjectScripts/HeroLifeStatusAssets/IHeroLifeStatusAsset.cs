using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.BasicActionAssets;

namespace ScriptableObjectScripts.HeroLifeStatusAssets
{
    public interface IHeroLifeStatusAsset
    {
        /// <summary>
        /// Target HeroAlive - call hero Caster Action
        /// Target HeroDead - Do nothing
        /// After confirming target is alive, check if caster is alive
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        void TargetMainExecutionAction(IBasicActionAsset basicAction, IHero casterHero, IHero targetHero);

        /// <summary>
        /// HeroAlive - basic action Execute action
        /// HeroDead - Do nothing
        /// After confirming, caster is alive, execute action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        void CasterMainExecutionAction(IBasicActionAsset basicAction, IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// After confirming target is alive, check if caster is alive
        /// before implementing the basic action's pre execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        void TargetPreExecutionAction(IBasicActionAsset basicAction, IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// After confirming the caster is alive, implement the basic action's
        /// pre execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        void CasterPreExecutionAction(IBasicActionAsset basicAction, IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// After confirming target is alive, check if caster is alive
        /// before implementing the basic action's post execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        void TargetPostExecutionAction(IBasicActionAsset basicAction, IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// After confirming the caster is alive, implement the basic action's
        /// post execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        void CasterPostExecutionAction(IBasicActionAsset basicAction, IHero casterHero, IHero targetHero);
        
       /// <summary>
       /// After confirming target is alive, check if caster is still alive
       /// </summary>
       /// <param name="basicAction"></param>
       /// <param name="casterHero"></param>
       ///  <param name="targetHero"></param>
        void TargetMainAnimation(IBasicActionAsset basicAction, IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// After confirming caster is alive, execute main animation action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        void CasterMainAnimation(IBasicActionAsset basicAction, IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// Add living hero to a list
        /// </summary>
        /// <param name="heroes"></param>
        /// <param name="hero"></param>
        void AddToHeroList(List<IHero> heroes, IHero hero);
    }
}