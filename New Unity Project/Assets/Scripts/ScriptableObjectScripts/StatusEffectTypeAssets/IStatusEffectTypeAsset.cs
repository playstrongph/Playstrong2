using Logic;
using ScriptableObjectScripts.StatusEffectAssets;

namespace ScriptableObjectScripts.StatusEffectTypeAssets
{
    public interface IStatusEffectTypeAsset
    {
        /// <summary>
        /// Add to the specific status effect list - i.e. buff, debuff, unique status effects
        /// </summary>
        /// <param name="heroStatusEffects"></param>
        /// <param name="heroStatusEffect"></param>
        void AddToStatusEffectsList(IHeroStatusEffects heroStatusEffects, IStatusEffect heroStatusEffect);

        /// <summary>
        /// Remove from the specific status effect list - i.e. buff, debuff, unique status effects
        /// </summary>
        /// <param name="heroStatusEffects"></param>
        /// <param name="heroStatusEffect"></param>
        void RemoveFromStatusEffectsList(IHeroStatusEffects heroStatusEffects, IStatusEffect heroStatusEffect);

        int AddStatusEffectNetChance(IHero casterHero, IHero targetHero, int defaultChance);

    }
}