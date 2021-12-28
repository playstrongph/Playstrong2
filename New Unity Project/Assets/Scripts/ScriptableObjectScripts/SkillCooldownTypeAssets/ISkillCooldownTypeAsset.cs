using Logic;

namespace ScriptableObjectScripts.SkillCooldownTypeAssets
{
    public interface ISkillCooldownTypeAsset
    {
        void ReduceCooldown(ISkill skill, int counter);
        void IncreaseCooldown(ISkill skill, int counter);
        void SetCooldownToValue(ISkill skill, int value);
        void ResetCooldownToMax(ISkill skill);
        void RefreshCooldownToZero(ISkill skill);
    }
}