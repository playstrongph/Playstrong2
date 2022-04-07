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
        ///  <param name="counter"></param>
        public override void StatusAction(ISkill skill,int counter)
        {
            skill.SkillLogic.SkillAttributes.Cooldown -= counter;
            skill.SkillLogic.SkillAttributes.Cooldown = Mathf.Max( skill.SkillLogic.SkillAttributes.Cooldown, 0);
        }
        
        

    }
}
