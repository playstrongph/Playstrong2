using ScriptableObjectScripts.StatusEffectAssets;

namespace Logic
{
    public interface ILoadStatusEffectAsset
    {
        /// <summary>
        /// Load status effect asset values to status effect and create unique instances
        /// </summary>
        /// <param name="targetHero"></param>
        /// <param name="casterHero"></param>
        /// <param name="statusEffectAsset"></param>
        /// <param name="counters"></param>
        void StartAction(IHero targetHero, IHero casterHero, IStatusEffectAsset statusEffectAsset, int counters);
    }
}