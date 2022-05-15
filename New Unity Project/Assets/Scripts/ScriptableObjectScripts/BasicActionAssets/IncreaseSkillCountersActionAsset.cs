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
    [CreateAssetMenu(fileName = "IncreaseSkillCountersAction", menuName = "Assets/BasicActions/I/IncreaseSkillCountersAction")]
    public class IncreaseSkillCountersActionAsset : BasicActionAsset
    {
        /// <summary>
        /// Target skill
        /// </summary>
        [SerializeField] private ScriptableObject skillAsset;
        
        /// <summary>
        /// Skill counters increase amount
        /// </summary>
        [SerializeField] private int countersValue = 0;

        private ISkillAsset SkillAsset
        {
            get => skillAsset as ISkillAsset;
            set => skillAsset = value as ScriptableObject;
        }
        
        /// <summary>
        /// Skill to increase counters of
        /// </summary>
        private ISkill _targetSkill;
        

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

            IncreaseSkillCounters(targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }

        private void IncreaseSkillCounters(IHero targetHero)
        {
            var allSkills = targetHero.HeroSkills.AllSkills;

            foreach (var skill in allSkills)
            {
                if (SkillAsset.SkillName == skill.SkillName)
                    _targetSkill = skill;
            }

            if (_targetSkill != null)
            {
                _targetSkill.SkillLogic.OtherSkillAttributes.SkillCounters += countersValue;
                
                //Clamp to a minimum of zero
                _targetSkill.SkillLogic.OtherSkillAttributes.SkillCounters =
                    Mathf.Max(_targetSkill.SkillLogic.OtherSkillAttributes.SkillCounters, 0);
            }

            

        }




        public override IEnumerator UndoExecuteAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            logicTree.EndSequence();
            yield return null;
        }

    }
}
