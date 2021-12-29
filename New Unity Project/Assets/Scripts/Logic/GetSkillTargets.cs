using System;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class GetSkillTargets : MonoBehaviour, IGetSkillTargets
    {
        
        private ISkillTargetCollider _skillTargetCollider;
        
        /// <summary>
        /// When Enabled, assigned ShowTargetsGlow
        /// When Disabled, assigned No Action
        /// </summary>
        private Action _showTargetsGlow;

        private void Awake()
        {
            _skillTargetCollider = GetComponent<ISkillTargetCollider>();
            
            //Default setting for _showTargets glow is NoAction
            _showTargetsGlow = NoAction;
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
        
        /// <summary>
        /// Target glows are enabled by skill readiness 'Ready' status action
        /// </summary>
        public void EnableGetSkillTargetActions()
        {
            _showTargetsGlow = ShowTargetsGlow;
        }
        
        /// <summary>
        /// Target glows are disabled by skill readiness 'NotReady' status action
        /// </summary>
        public void DisableGetSkillTargetsActions()
        {
            _showTargetsGlow = NoAction;
        }

        private void OnMouseDown()
        {
            _showTargetsGlow();
        }

        private void OnMouseUp()
        {
            HideTargetsGlow();
        }


        /// <summary>
        /// Displays hero glow on mouse down after skill readiness 'ready'
        /// status action
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
        
        /// <summary>
        /// Dummy method assigned to _showTargetsGlow when it is disabled
        /// </summary>
        private void NoAction()
        {
        }
    }
}
