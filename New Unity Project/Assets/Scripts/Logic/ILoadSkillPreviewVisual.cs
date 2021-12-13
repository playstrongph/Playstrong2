using AssetsScriptableObjects;

namespace Logic
{
    public interface ILoadSkillPreviewVisual
    {
        /// <summary>
        /// Sets the skill preview details - icon, cooldown text, name, description, etc.
        /// </summary>
        /// <param name="skillAsset"></param>
        void StartAction(ISkillAsset skillAsset);
    }
}