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
            var skillCooldown = skillAttributes.Cooldown;
            var maxSkillCooldown = skillAttributes.BaseCooldown;
            
            skillAttributes.Cooldown -= counter;
            skillAttributes.Cooldown = Mathf.Clamp(skillAttributes.Cooldown, 0, maxSkillCooldown);
            
            //TODO: UpdateSkillReadinessStatus
            
            //TODO: Update Visual Skill Cooldown Text
        }
       
    }
}
