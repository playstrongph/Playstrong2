using AssetsScriptableObjects;

namespace Logic
{
    public interface ILoadSkillEffectAsset
    {
        /// <summary>
        /// Create a unique skill effect, standard action/s and all its child components, and unique basic conditions.
        /// Required due to same heroes that can exist across teams
        /// </summary>
        void StartAction(ISkillAsset skillAsset);
    }
}