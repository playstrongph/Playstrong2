using Logic;

namespace ScriptableObjectScripts.StandardActionAssets
{
    public interface IStatusEffectActionAsset
    {
        /// <summary>
        /// The status effect's caster 
        /// </summary>
        IHero StatusEffectCasterHero { get; set; }

        /// <summary>
        /// Executes the base class method StartActionCoroutine
        /// </summary>
        /// <param name="hero"></param>
        void StatusEffectStartAction(IHero hero);
        
        /// <summary>
        /// Undoes the status effect start action
        /// </summary>
        /// <param name="hero"></param>
        void UndoStatusEffectStartAction(IHero hero);
        
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