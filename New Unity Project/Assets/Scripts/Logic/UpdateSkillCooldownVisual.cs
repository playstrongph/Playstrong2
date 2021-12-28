using System;
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
        /// <param name="value"></param>
        public void StartAction(int value)
        {
            //Update skill cooldown text
            _skillVisual.CooldownText.text = value.ToString();
            
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

            foreach (var displaySkill in displaySkills)
            {
                if (displaySkill.SkillName == skill.SkillName)
                    displaySkill.SkillVisual.CooldownText.text = _skillVisual.CooldownText.text;
            }
        }

    }
}
