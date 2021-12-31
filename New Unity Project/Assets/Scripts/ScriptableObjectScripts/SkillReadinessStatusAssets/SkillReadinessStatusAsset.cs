using System;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillReadinessStatusAssets
{
    public abstract class SkillReadinessStatusAsset : ScriptableObject, ISkillReadinessStatusAsset
    {
        /// <summary>
        /// Executes skill readiness actions based on skill type
        /// </summary>
        /// <param name="skill"></param>
        public virtual void StatusAction(ISkill skill)
        {
            
        }

    }
}
