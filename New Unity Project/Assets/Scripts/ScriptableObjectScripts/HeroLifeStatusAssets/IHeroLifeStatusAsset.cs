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
        /// <param name="hero"></param>
        void TargetMainExecutionAction(IBasicActionAsset basicAction, IHero hero);

        /// <summary>
        /// HeroAlive - basic action Execute action
        /// HeroDead - Do nothing
        /// After confirming, caster is alive, execute action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        void CasterMainExecutionAction(IBasicActionAsset basicAction, IHero hero);
        
        /// <summary>
        /// After confirming target is alive, check if caster is alive
        /// before implementing the basic action's pre execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        void TargetPreExecutionAction(IBasicActionAsset basicAction, IHero hero);
        
        /// <summary>
        /// After confirming the caster is alive, implement the basic action's
        /// pre execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        void CasterPreExecutionAction(IBasicActionAsset basicAction, IHero hero);
        
        /// <summary>
        /// After confirming target is alive, check if caster is alive
        /// before implementing the basic action's post execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        void TargetPostExecutionAction(IBasicActionAsset basicAction, IHero hero);
        
        /// <summary>
        /// After confirming the caster is alive, implement the basic action's
        /// post execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        void CasterPostExecutionAction(IBasicActionAsset basicAction, IHero hero);
        
        //TEST
        void TargetMainAnimation(IBasicActionAsset basicAction, IHero hero);

        void CasterMainAnimation(IBasicActionAsset basicAction, IHero hero);
    }
}