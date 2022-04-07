using Logic;
using ScriptableObjectScripts.SkillReadinessStatusAssets;
using UnityEngine;

namespace ScriptableObjectScripts.SkillLastUsedStatusAssets
{
    [CreateAssetMenu(fileName = "SkillUsedLastTurn", menuName = "Assets/SkillLastUsedStatus/SkillUsedLastTurn")]
    public class SkillUsedLastTurnAsset : SkillLastUsedStatusAsset
    {
        /// <summary>
        /// Allows skill cooldown reduction next turn
        /// </summary>
        /// <param name="skill"></param>
        public override void StatusAction(ISkill skill)
        {
            //TODO: Switch status to NotUsedLastTurn
        }
        
        

    }
}
