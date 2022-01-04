using System;
using Logic;
using ScriptableObjectScripts.StandardActionAssets;
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
        
        /// <summary>
        /// Executes skill action's skill start action when skill readiness is in 'SkillReady' state
        /// </summary>
        /// <param name="skillAction"></param>
        /// <param name="hero"></param>
        public virtual void SkillStartAction(ISkillActionAsset skillAction, IHero hero)
        {
            
        }

    }
}
