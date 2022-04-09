using Logic;

namespace ScriptableObjectScripts.StandardActionAssets
{
    public interface IStatusEffectActionAsset
    {
        /// <summary>
        /// Requires a unique instance of the status effect action asset to set the reference
        /// </summary>
        IHero StatusEffectCasterHero { get; set; }
        
        /// <summary>
        /// Requires a unique instance of the status effect action asset to set the reference
        /// </summary>
        IHero StatusEffectTargetHero { get; set; }

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