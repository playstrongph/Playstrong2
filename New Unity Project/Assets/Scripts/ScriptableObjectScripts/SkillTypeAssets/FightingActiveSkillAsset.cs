using Logic;
using ScriptableObjectScripts.SkillEnableStatusAssets;
using ScriptableObjectScripts.SkillReadinessStatusAssets;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.SkillTypeAssets
{
    [CreateAssetMenu(fileName = "FightingActiveSkill", menuName = "Assets/SkillType/FightingActiveSkill")]
    public class FightingActiveSkillAsset : SkillTypeAsset
    {

        /// <summary>
        /// Displays skill glow and enables hero skill targeting
        /// </summary>
        /// <param name="skill"></param>
        public override void SkillReadyActions(ISkill skill)
        {
            var visualTree = skill.CoroutineTrees.MainVisualTree;
            
            //Enable get skill target actions - show valid targets glow
            skill.SkillTargetCollider.GetSkillTargets.EnableGetSkillTargetActions();
            
            //Enable select drag target actions - set hero targets and use hero skill
            skill.SkillTargetCollider.SelectDragTarget.EnableSelectDragTargetActions();
            
            //Show skill glows
            visualTree.AddCurrent(ShowSkillGlowDisplayVisual(skill));
        }
        
        /// <summary>
        /// Hides skill glow and disables hero skill targeting
        /// </summary>
        /// <param name="skill"></param>
        public override void SkillNotReadyActions(ISkill skill)
        {
            var visualTree = skill.CoroutineTrees.MainVisualTree;
            
            //Enable get skill target actions - show valid targets glow
            skill.SkillTargetCollider.GetSkillTargets.DisableGetSkillTargetsActions();
            
            //Enable select drag target actions - set hero targets and use hero skill
            skill.SkillTargetCollider.SelectDragTarget.DisableSelectDragTargetActions();
            
            //Show skill glows
            visualTree.AddCurrent(HideSkillGlowDisplayVisual(skill));
        }
        
        public override void DisableActiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset)
        {
            //Set skill enable status to SkillDisabled
            skill.SkillLogic.SkillAttributes.SkillEnableStatus = skillEnableStatusAsset;
            
            //Execute skill disabled status action
            skill.SkillLogic.SkillAttributes.SkillEnableStatus.StatusAction(skill);
            
            //TODO:TEST
            var visualTree = skill.CoroutineTrees.MainVisualTree;
            visualTree.AddCurrent(DisableSkillVisual(skill));

        }
        
        public override void EnableActiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset)
        {
            //Set skill enable status to SkillDisabled
            skill.SkillLogic.SkillAttributes.SkillEnableStatus = skillEnableStatusAsset;
            
            //Execute skill disabled status action
            skill.SkillLogic.SkillAttributes.SkillEnableStatus.StatusAction(skill);
            
            //TODO:TEST
            var visualTree = skill.CoroutineTrees.MainVisualTree;
            visualTree.AddCurrent(EnableSkillVisual(skill));
        }
        
        /// <summary>
        /// No Action
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="skillEnableStatusAsset"></param>
        public override void DisablePassiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset)
        {
        }
        
        /// <summary>
        /// No Action
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="skillEnableStatusAsset"></param>
        public override void EnablePassiveSkill(ISkill skill, ISkillEnableStatusAsset skillEnableStatusAsset)
        {
        }
        
        
        /// <summary>
        /// Check if hero has enough fighting spirit on top of cooldown readiness
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="updateSkillReadiness"></param>
        public override void UpdateSkillReadiness(ISkill skill, IUpdateSkillReadiness updateSkillReadiness)
        {
            var skillCooldown = skill.SkillLogic.SkillAttributes.Cooldown;
            var fightingSpiritCost = skill.SkillLogic.SkillAttributes.FightingSpiritCost;

            var heroFightingSpirit = skill.CasterHero.HeroLogic.HeroAttributes.FightingSpirit;

            if (skillCooldown <= 0 && heroFightingSpirit >= fightingSpiritCost)
                updateSkillReadiness.SetSkillReady();
            else
                updateSkillReadiness.SetSkillNotReady();
        }
        
        /// <summary>
        /// Consumes fighting spirit after using a fight active skill
        /// </summary>
        /// <param name="skill"></param>
        public override void ConsumeFightingSpirit(ISkill skill)
        {
            var spiritCost = skill.SkillLogic.SkillAttributes.FightingSpiritCost;
            var heroSpirit = skill.CasterHero.HeroLogic.HeroAttributes.FightingSpirit;

            var netSpirit = heroSpirit - spiritCost;
            
            //Negative result is clamped to zero
            netSpirit = Mathf.Max(0, netSpirit);
            
            skill.CasterHero.HeroLogic.SetFightingSpirit.StartAction(netSpirit);
        }
        


    }
}
