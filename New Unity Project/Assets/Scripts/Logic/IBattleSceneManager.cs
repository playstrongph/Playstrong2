using ScriptableObjectScripts;

namespace Logic
{
    public interface IBattleSceneManager
    {
        /// <summary>
        /// Interface access to battle scene settings asset
        /// </summary>
        IBattleSceneSettingsAsset BattleSceneSettings { get; set; }
    }
}