using Logic;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.SkillTypeAssets
{
    [CreateAssetMenu(fileName = "ActiveSkill", menuName = "Assets/SkillType/ActiveSkill")]
    public class ActiveSkillAsset : SkillTypeAsset
    {
        public override void SkillCooldownTextDisplay(TextMeshProUGUI text)
        {
            text.enabled = true;
        }
        
        public override void ReduceSkillCooldown(ISkill skill, int counter)
        {
            skill.SkillLogic.UpdateSkillCooldown.DecreaseCooldown(counter);
        }   
    }
}
