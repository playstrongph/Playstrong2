using Logic;

namespace ScriptableObjectScripts.StandardActionAssets
{
    public interface IStatusEffectActionAsset
    {
        /// <summary>
        /// Executes the base class method StartActionCoroutine
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void StatusEffectStartAction(IHero casterHero,IHero targetHero);
        
        /// <summary>
        /// Undoes the status effect start action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void UndoStatusEffectStartAction(IHero casterHero,IHero targetHero);
        
        /// <summary>
        /// Subscribes the standard action to an event
        /// </summary>
        /// <param name="hero"></param>
        void SubscribeStandardAction(IHero hero);
        
        /// <summary>
        /// Unsubscribes the standard action to an event
        /// </summary>
        /// <param name="hero"></param>
        void UnsubscribeStandardAction(IHero hero);
    }
}