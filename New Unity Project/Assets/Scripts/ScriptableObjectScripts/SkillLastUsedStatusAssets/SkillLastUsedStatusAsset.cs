using Logic;
using ScriptableObjectScripts.SkillReadinessStatusAssets;
using UnityEngine;

namespace ScriptableObjectScripts.SkillLastUsedStatusAssets
{
    public abstract class SkillLastUsedStatusAsset : ScriptableObject, ISkillLastUsedStatusAsset
    {
        /// <summary>
        /// Allows skill cooldown reduction next turn
        /// </summary>
        /// <param name="skill"></param>
        ///   /// <param name="counter"></param>
        public virtual void StatusAction(ISkill skill,int counter)
        {
            
        }
        
        

    }
}
