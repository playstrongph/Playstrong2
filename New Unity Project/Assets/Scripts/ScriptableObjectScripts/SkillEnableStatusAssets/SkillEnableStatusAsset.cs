using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillEnableStatusAssets
{
    public abstract class SkillEnableStatusAsset : ScriptableObject, ISkillEnableStatusAsset
    {
        /// <summary>
        /// Enabled/Disabled skills status action
        /// </summary>
        /// <param name="skill"></param>
        public virtual void StatusAction(ISkill skill)
        {
            
        }
        
        

       

    }
}
