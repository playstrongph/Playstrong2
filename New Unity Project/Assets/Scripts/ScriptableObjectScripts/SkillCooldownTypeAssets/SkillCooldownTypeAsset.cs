using System.Collections;
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
        
        //TEST
        /// <summary>
        /// Visual reduction of skill cooldown
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        protected IEnumerator UpdateSkillCooldownVisual(ISkill skill)
        {
            var visualTree = skill.CoroutineTrees.MainVisualTree;
            
            skill.SkillVisual.UpdateSkillCooldownVisual.StartAction();
            
            visualTree.EndSequence();
            yield return null;
        }
        
        

    }
}
