using Logic;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.SkillTypeAssets
{
    [CreateAssetMenu(fileName = "PassiveSkill", menuName = "Assets/SkillType/PassiveSkill")]
    public class PassiveSkillAsset : SkillTypeAsset
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
