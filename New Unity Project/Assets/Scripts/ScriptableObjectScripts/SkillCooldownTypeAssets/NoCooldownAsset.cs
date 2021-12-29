using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillCooldownTypeAssets
{
    
    [CreateAssetMenu(fileName = "NoCooldown", menuName = "Assets/SkillCooldownType/NoCooldown")]
    public class NoCooldownAsset : SkillCooldownTypeAsset
    {
        public override void DecreaseCooldown(ISkill skill, int counter)
        {
        }

        public override void IncreaseCooldown(ISkill skill, int counter)
        {
        }
        
        public override void SetCooldownToValue(ISkill skill, int value)
        {
        }

        public override void ResetCooldownToMax(ISkill skill)
        {
        }

        public override void RefreshCooldownToZero(ISkill skill)
        {
        }
        
        public override void TurnControllerReduceCooldown(ISkill skill, int counter = 1)
        {
        }
        
        public override void UseSkillResetCooldown(ISkill skill)
        {
        }
    }
}
