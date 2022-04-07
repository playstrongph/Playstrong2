using ScriptableObjectScripts.SkillReadinessStatusAssets;

namespace Logic
{
    public interface IUpdateSkillLastUsedStatus
    {
        ISkillLastUsedStatusAsset SkillUsedLastTurnAsset { get; set; }
        ISkillLastUsedStatusAsset SkillNotUsedLastTurnAsset { get; set; }
    }
}