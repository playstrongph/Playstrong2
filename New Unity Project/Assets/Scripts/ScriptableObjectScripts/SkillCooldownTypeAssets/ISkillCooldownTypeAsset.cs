using Logic;

namespace ScriptableObjectScripts.SkillCooldownTypeAssets
{
    public interface ISkillCooldownTypeAsset
    {
        void DecreaseCooldown(ISkill skill, int counter);
        void IncreaseCooldown(ISkill skill, int counter);
        void SetCooldownToValue(ISkill skill, int value);
        void ResetCooldownToMax(ISkill skill);
        void RefreshCooldownToZero(ISkill skill);

        void TurnControllerReduceCooldown(ISkill skill, int counter = 1);
        void UseSkillResetCooldown(ISkill skill);

        void UpdateSkillReadiness(ISkill skill);
    }
}