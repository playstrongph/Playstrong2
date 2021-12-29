using System;
using TMPro;
using UnityEngine;

namespace Logic
{
    public class UpdateSkillCooldownVisual : MonoBehaviour, IUpdateSkillCooldownVisual
    {
        private ISkillVisual _skillVisual;

        private void Awake()
        {
            _skillVisual = GetComponent<ISkillVisual>();
        }
        
        /// <summary>
        /// Updates the skill and display skill cooldown text
        /// </summary>
        public void StartAction()
        {
            var skill = _skillVisual.Skill;
            var skillCooldown = skill.SkillLogic.SkillAttributes.Cooldown;
            
            //Update skill cooldown text
            _skillVisual.CooldownText.text = skillCooldown.ToString();
            
            HideOrShowText(skillCooldown,_skillVisual.CooldownText);

            //Update corresponding display skill
            UpdateDisplayPanelSkill();
        }
        
        /// <summary>
        /// Searches for the corresponding display skill and
        /// updates the cooldown value
        /// </summary>
        private void UpdateDisplayPanelSkill()
        {
            var skill = _skillVisual.Skill;
            var displaySkills = skill.CasterHero.DisplayHeroSkills.AllSkills;
            var skillCooldown = skill.SkillLogic.SkillAttributes.Cooldown;

            foreach (var displaySkill in displaySkills)
            {
                if (displaySkill.SkillName == skill.SkillName)
                {
                    displaySkill.SkillVisual.CooldownText.text = _skillVisual.CooldownText.text;
                    
                    HideOrShowText(skillCooldown,displaySkill.SkillVisual.CooldownText);
                }
            }
        }
        
        //TEST
        
        /// <summary>
        /// Hide text if cooldown is less or equal to zero
        /// Display text if cooldown is more than zero
        /// </summary>
        /// <param name="cooldown"></param>
        /// <param name="text"></param>
        private void HideOrShowText(int cooldown, TextMeshProUGUI text)
        {
            text.enabled = cooldown > 0;
        }

    }
}
