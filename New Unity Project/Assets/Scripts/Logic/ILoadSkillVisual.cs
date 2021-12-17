using AssetsScriptableObjects;

public interface ILoadSkillVisual
{
    /// <summary>
    /// Sets the skill's icon and cooldown text
    /// </summary>
    /// <param name="skillAsset"></param>
    void StartAction(ISkillAsset skillAsset);
}