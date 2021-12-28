using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillCooldownTypeAssets
{
    
    [CreateAssetMenu(fileName = "NormalCooldown", menuName = "Assets/SkillCooldownType/NormalCooldown")]
    public class NormalCooldownAsset : SkillCooldownTypeAsset
    {
        public override void ReduceCooldown(ISkill skill, int counter)
        {
            var skillAttributes = skill.SkillLogic.SkillAttributes;
            var maxSkillCooldown = skillAttributes.BaseCooldown;
            
            skillAttributes.Cooldown -= counter;
            skillAttributes.Cooldown = Mathf.Clamp(skillAttributes.Cooldown, 0, maxSkillCooldown);
            
            //TODO: UpdateSkillReadinessStatus
            
            //Update the skill and display skill visual cooldown text
            skill.SkillVisual.UpdateSkillCooldownVisual.StartAction(skillAttributes.Cooldown);
        }
       
    }
}
