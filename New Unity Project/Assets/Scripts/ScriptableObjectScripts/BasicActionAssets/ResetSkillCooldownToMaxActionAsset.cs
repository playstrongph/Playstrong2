using System.Collections;
using AssetsScriptableObjects;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.GameAnimationAssets;
using ScriptableObjectScripts.StandardActionAssets;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "ResetSkillCooldownToMaxAction", menuName = "Assets/BasicActions/R/ResetSkillCooldownToMaxAction")]
    public class ResetSkillCooldownToMaxActionAsset : BasicActionAsset
    {
        /// <summary>
        /// Target skill
        /// </summary>
        [SerializeField] private ScriptableObject skillAsset;
        private ISkillAsset SkillAsset
        {
            get => skillAsset as ISkillAsset;
            set => skillAsset = value as ScriptableObject;
        }
        
        /// <summary>
        /// Skill to increase counters of
        /// </summary>
        private ISkill targetSkill;
        

        /// <summary>
        /// The specific logic-visual sequence for basic action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        protected override IEnumerator MainBasicActionPhase(IHero casterHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            //base class method that calls execute action after checking life status and inability status
            logicTree.AddCurrent(MainAction(targetHero));

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

            ResetSkillCooldown(targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }

        private void ResetSkillCooldown(IHero targetHero)
        {
            var allSkills = targetHero.HeroSkills.AllSkills;

            foreach (var skill in allSkills)
            {
                if (SkillAsset.SkillName == skill.SkillName)
                    targetSkill = skill;
            }

            if (targetSkill != null)
            {
                targetSkill.SkillLogic.UpdateSkillCooldown.ResetCooldownToMax();
            }

        }




        public override IEnumerator UndoExecuteAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            
            //There is no undo action

            logicTree.EndSequence();
            yield return null;
        }

    }
}
