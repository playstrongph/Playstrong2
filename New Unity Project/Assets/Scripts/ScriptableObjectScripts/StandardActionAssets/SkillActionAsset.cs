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
        /// <param name="targetHero"></param>
        public override void StartAction(IHero targetHero)
        {
            _skillParent.SkillLogic.SkillAttributes.SkillReadiness.SkillStartAction(this,targetHero);

        }
        
        /// <summary>
        /// Executes the base class method StartActionCoroutine
        /// When skill readiness status is 'SkillReady'
        /// </summary>
        /// <param name="hero"></param>
        public void SkillStartAction(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            //TODO - Check if this is still needed - can be void?
            //logicTree.AddCurrent(SetUsingPassiveSkillStatus());

            //TEST
            logicTree.AddCurrent(StartActionCoroutine(hero));
            
            //TODO - Check if this is still needed - can be void?
            //logicTree.AddCurrent(SetHeroUsedPassiveSkill());
        }

    }
}
