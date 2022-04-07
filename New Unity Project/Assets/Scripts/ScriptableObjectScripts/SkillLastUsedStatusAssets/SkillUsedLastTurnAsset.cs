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
        ///  <param name="counter"></param>
        public override void StatusAction(ISkill skill,int counter)
        {
            skill.SkillLogic.UpdateSkillLastUsedStatus.SetNotUsedSkillLastTurn();
        }
        
        

    }
}
