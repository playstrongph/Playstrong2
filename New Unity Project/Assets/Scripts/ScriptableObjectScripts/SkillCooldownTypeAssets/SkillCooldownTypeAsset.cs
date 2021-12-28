using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillCooldownTypeAssets
{
    public abstract class SkillCooldownTypeAsset : ScriptableObject, ISkillCooldownTypeAsset
    {
        public virtual void ReduceCooldown(ISkill skill, int counter)
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
        
        

    }
}
