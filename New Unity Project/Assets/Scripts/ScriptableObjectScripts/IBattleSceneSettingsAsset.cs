using Logic;

namespace ScriptableObjectScripts
{
    public interface IBattleSceneSettingsAsset
    {
        /// <summary>
        /// Interface access to battle scene manager
        /// </summary>
        IBattleSceneManager BattleSceneManager { get; set; }

    }
}