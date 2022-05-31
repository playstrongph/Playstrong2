using System.Collections.Generic;
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
        /// Requires a unique instance of the skill action asset to set the reference
        /// Reference is set in LoadSkillEffectAsset.cs
        /// </summary>
        public IHero SkillCasterHero { get; set; }
        
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
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void StartAction(IHero casterHero,IHero targetHero)
        {
            //TODO - check args if correct
            _skillParent.SkillLogic.SkillAttributes.SkillReadiness.SkillStartAction(this,casterHero,targetHero);
        }
        
        /// <summary>
        /// Checks if skill is Ready before executing skill start action
        /// </summary>
        /// <param name="casterHero"></param>
        public override void StartAction(IHero casterHero)
        {
            //Note: caster hero and target hero is the same for single IHero events
            _skillParent.SkillLogic.SkillAttributes.SkillReadiness.SkillStartAction(this,casterHero,casterHero);
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
            
            //TODO: Transfer this to skill effect, inside a logic tree
            //Reset Skill Cooldown after skill use
            _skillParent.SkillLogic.UpdateSkillCooldown.UseSkillResetCooldown();
            
            //TODO: Transfer this to skill effect, inside a logic tree
            //Set skillLastUsedStatus to used last turn
            _skillParent.SkillLogic.UpdateSkillLastUsedStatus.SetUsedSkillLastTurn();
        }
        
        /// <summary>
        /// Check target life status
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="heroes"></param>
        public override void SetTargetHeroes(IHero hero, List<IHero> heroes)
        {
            hero.HeroLogic.HeroLifeStatus.AddToHeroTargetsList(heroes,hero);
        }  
        
        /// <summary>
        /// Check caster life and inability status
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="heroes"></param>
        public override void SetCasterHeroes(IHero hero, List<IHero> heroes)
        {
            hero.HeroLogic.HeroLifeStatus.AddToHeroCastersList(heroes,hero);
        }
        
    }
}
