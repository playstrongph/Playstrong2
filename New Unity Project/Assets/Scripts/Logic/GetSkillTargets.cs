using System;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class GetSkillTargets : MonoBehaviour, IGetSkillTargets
    {
        
        private ISkillTargetCollider _skillTargetCollider;

        private void Awake()
        {
            _skillTargetCollider = GetComponent<ISkillTargetCollider>();
        }
        
        /// <summary>
        /// Returns a list of valid skill target heroes
        /// </summary>
        /// <returns></returns>
        public List<IHero> GetValidTargets()
        {
            var skill = _skillTargetCollider.Skill;
            var hero = _skillTargetCollider.Skill.CasterHero;

            var validTargets = skill.SkillLogic.SkillAttributes.SkillTargets.HeroTargets(hero);

            return validTargets;
        }


        private void OnMouseDown()
        {
            ShowTargetsGlow();
        }

        private void OnMouseUp()
        {
            HideTargetsGlow();
        }


        /// <summary>
        /// Displays hero glow on mouse down
        /// </summary>
        private void ShowTargetsGlow()
        {
            var skill = _skillTargetCollider.Skill;
            
            foreach (var hero in GetValidTargets())
            {
                skill.SkillLogic.SkillAttributes.SkillTargets.ShowHeroGlow(hero);
            }
        }
        
        
        /// <summary>
        /// Hides hero glow on mouse up
        /// </summary>
        private void HideTargetsGlow()
        {
            var skill = _skillTargetCollider.Skill;
            
            foreach (var hero in GetValidTargets())
            {
                skill.SkillLogic.SkillAttributes.SkillTargets.HideHeroGlow(hero);
            }
        }
    }
}
