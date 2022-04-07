using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.StandardActionAssets
{
    [CreateAssetMenu(fileName = "SkillAction", menuName = "Assets/StandardActions/SkillAction")]
    public class SkillActionAsset : StandardActionAsset, ISkillActionAsset
    {
        //The skill containing the skill action asset
        private ISkill _skillParent;
        
        /// <summary>
        /// Initialized during LoadAttributes create unique standard actions
        /// </summary>
        /// <param name="skill"></param>
        public void InitializeSkillReference(ISkill skill)
        {
            _skillParent = skill;
        }
        
        /// <summary>
        /// Checks if skill is Ready before executing skill start action
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="targetHero"></param>
        public override void StartAction(IHero hero,IHero targetHero)
        {
            Debug.Log("Skill Action Asset Override Start Action");
            
            //TODO - check args if correct
            _skillParent.SkillLogic.SkillAttributes.SkillReadiness.SkillStartAction(this,hero,targetHero);

        }
        
        /// <summary>
        /// Checks if skill is Ready before executing skill start action
        /// </summary>
        /// <param name="hero"></param>
        public override void StartAction(IHero hero)
        {
            //Note: caster hero and target hero is the same for single IHero events
            _skillParent.SkillLogic.SkillAttributes.SkillReadiness.SkillStartAction(this,hero,hero);
        }
        
        /// <summary>
        /// Executes the base class method StartActionCoroutine
        /// When skill readiness status is 'SkillReady'
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void SkillStartAction(IHero casterHero,IHero targetHero)
        {
            //Call base class start action
            base.StartAction(casterHero,targetHero);
            
            //TEST - TODO: Reset Skill Cooldown
            _skillParent.SkillLogic.UpdateSkillCooldown.UseSkillResetCooldown();
        }

    }
}
