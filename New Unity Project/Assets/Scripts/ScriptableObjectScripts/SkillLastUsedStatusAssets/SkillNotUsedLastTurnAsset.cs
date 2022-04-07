using Logic;
using ScriptableObjectScripts.SkillReadinessStatusAssets;
using UnityEngine;

namespace ScriptableObjectScripts.SkillLastUsedStatusAssets
{
    [CreateAssetMenu(fileName = "SkillNotUsedLastTurn", menuName = "Assets/SkillLastUsedStatus/SkillNotUsedLastTurn")]
    public class SkillNotUsedLastTurnAsset : SkillLastUsedStatusAsset
    {
        /// <summary>
        /// Allows skill cooldown reduction next turn
        /// </summary>
        /// <param name="skill"></param>
        public override void StatusAction(ISkill skill)
        {
            //TODO: Switch allow turn cooldown reduction
        }
        
        

    }
}
