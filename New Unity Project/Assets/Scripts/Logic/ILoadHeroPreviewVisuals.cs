using AssetsScriptableObjects;

namespace Logic
{
    public interface ILoadHeroPreviewVisuals
    {
        void StartAction(IHeroAsset heroAsset, int xCompensation);
    }
}