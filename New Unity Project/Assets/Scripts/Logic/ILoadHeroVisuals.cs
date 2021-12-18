using AssetsScriptableObjects;

namespace Logic
{
    public interface ILoadHeroVisuals
    {
        /// <summary>
        /// Load hero visuals
        /// </summary>
        /// <param name="heroAsset"></param>
        void StartAction(IHeroAsset heroAsset);
    }
}