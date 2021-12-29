using Logic;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.SkillTypeAssets
{   
    /// <summary>
    /// Passive skills with cooldown
    /// </summary>
    [CreateAssetMenu(fileName = "HybridSkill", menuName = "Assets/SkillType/HybridSkill")]
    public class HybridSkillAsset : SkillTypeAsset
    {
        /// <summary>
        /// No Action
        /// </summary>
        /// <param name="skill"></param>
        public override void SkillReadyActions(ISkill skill)
        {
        }
        
        /// <summary>
        /// No Action
        /// </summary>
        /// <param name="skill"></param>
        public override void SkillNotReadyActions(ISkill skill)
        {
        }
    
    }
}
