using AssetsScriptableObjects;
using Logic;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicConditionAssets
{
    [CreateAssetMenu(fileName = "SkillNotReadyCondition", menuName = "Assets/BasicConditions/S/SkillNotReadyCondition")]
    public class SkillNotReadyConditionAsset : BasicConditionAsset
    {
        [SerializeField] private ScriptableObject skillAsset;

        private ISkillAsset SkillAsset
        {
            get => skillAsset as ISkillAsset;
            set => skillAsset = value as ScriptableObject;
        }

        private ISkill _skillTarget;
        
        

        protected override int CheckConditionValue(IHero hero)
        {
            var value = 0;
            var skills = hero.HeroSkills.AllSkills;
            var notReady = skills[0].SkillLogic.UpdateSkillReadiness.SkillNotReadyAsset;
            
            //Get skill target
            foreach (var skill in skills)
            {
                if (skill.SkillName == SkillAsset.SkillName)
                    _skillTarget = skill;
            }
            
            //Check skill readiness status is "Not Ready"
            value = _skillTarget.SkillLogic.SkillAttributes.SkillReadiness == notReady ? 1 : 0;

            return value;
        }
    }
}
