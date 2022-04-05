using System.Collections;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.GameAnimationAssets;
using ScriptableObjectScripts.StandardActionAssets;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "DisableActiveSkillsAction", menuName = "Assets/BasicActions/D/DisableActiveSkillsAction")]
    public class DisableActiveSkillsActionAsset : BasicActionAsset
    {   
       

        /// <summary>
        /// The specific logic-visual sequence for basic action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        protected override IEnumerator MainBasicActionPhase(IHero casterHero, IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            //base class method that calls execute action after checking life status and inability status
            logicTree.AddCurrent(MainAction(casterHero));

            logicTree.EndSequence();
            yield return null;
        }


        /// <summary>
        /// Increase attack logic execution
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            
            DisableActiveSkills(targetHero);
           
            
            logicTree.EndSequence();
            yield return null;
        }

        private void DisableActiveSkills(IHero hero)
        {
            var skills = hero.HeroSkills.AllSkills;
            var displaySkills = hero.DisplayHeroSkills.AllSkills;

            foreach (var skill in skills)
            {
                skill.SkillLogic.UpdateSkillEnableStatus.DisableActiveSkill();
            }
            
            foreach (var skill in displaySkills)
            {
                skill.SkillLogic.UpdateSkillEnableStatus.DisableActiveSkill();
            }
        }

        public override IEnumerator UndoExecuteAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            
            EnableActiveSkills(targetHero);

            logicTree.EndSequence();
            yield return null;
        }
        
        private void EnableActiveSkills(IHero hero)
        {
            var skills = hero.HeroSkills.AllSkills;
            var displaySkills = hero.DisplayHeroSkills.AllSkills;

            foreach (var skill in skills)
            {
                skill.SkillLogic.UpdateSkillEnableStatus.EnableActiveSkill();
            }
            
            foreach (var skill in displaySkills)
            {
                skill.SkillLogic.UpdateSkillEnableStatus.EnableActiveSkill();
            }
        }

    }
}
