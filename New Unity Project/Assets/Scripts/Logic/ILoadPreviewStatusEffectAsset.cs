using ScriptableObjectScripts.StatusEffectAssets;

namespace Logic
{
    public interface ILoadPreviewStatusEffectAsset
    {
        /// <summary>
        /// Load status effect preview components
        /// </summary>
        /// <param name="statusEffectAsset"></param>
        ///  /// <param name="statusEffect"></param>
        //void StartAction(IStatusEffectAsset statusEffectAsset);


        void StartAction(IStatusEffectAsset statusEffectAsset, IStatusEffect statusEffect);
    }
}