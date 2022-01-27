using ScriptableObjectScripts.StatusEffectAssets;

namespace Logic
{
    public interface ILoadPreviewStatusEffectAsset
    {
        /// <summary>
        /// Load status effect preview components
        /// </summary>
        /// <param name="statusEffectAsset"></param>
        void StartAction(IStatusEffectAsset statusEffectAsset);
    }
}