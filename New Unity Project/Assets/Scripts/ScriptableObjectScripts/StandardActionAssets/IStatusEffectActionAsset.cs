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
    }
}