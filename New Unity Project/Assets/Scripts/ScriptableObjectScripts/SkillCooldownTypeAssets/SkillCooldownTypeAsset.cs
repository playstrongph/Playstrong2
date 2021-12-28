using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillCooldownTypeAssets
{
    public abstract class SkillCooldownTypeAsset : ScriptableObject, ISkillCooldownTypeAsset
    {
        public virtual void DecreaseCooldown(ISkill skill, int counter)
        {
        }

        public virtual void IncreaseCooldown(ISkill skill, int counter)
        {
        }
        
        public virtual void SetCooldownToValue(ISkill skill, int value)
        {
        }

        public virtual void ResetCooldownToMax(ISkill skill)
        {
        }

        public virtual void RefreshCooldownToZero(ISkill skill)
        {
        }
        
        public virtual void TurnControllerReduceCooldown(ISkill skill, int counter = 1)
        {
        }
        
        public virtual void UseSkillResetCooldown(ISkill skill)
        {
        }
        
        

    }
}
