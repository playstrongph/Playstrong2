using AssetsScriptableObjects;
using ScriptableObjectScripts.BasicConditionAssets;
using UnityEngine;

namespace Logic
{
    public class LoadSkillAttributes : MonoBehaviour, ILoadSkillAttributes
    {
        private ISkillLogic _skillLogic;

        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
        }

        public void StartAction(ISkillAsset skillAsset)
        {
            var skillAttributes = _skillLogic.SkillAttributes;

            skillAttributes.BaseCooldown = skillAsset.BaseCooldown;
            skillAttributes.Cooldown = skillAsset.BaseCooldown;
            
            //SET SKILL PROPERTIES AND STATUSES
            skillAttributes.SkillType = skillAsset.SkillTypeAsset;
            skillAttributes.SkillTargets = skillAsset.SkillTargetsAsset;
            skillAttributes.SkillCooldownType = skillAsset.SkillCooldownTypeAsset;
            skillAttributes.SkillReadiness = skillAsset.SkillTypeAsset.StartingSkillReadiness;
            skillAttributes.SkillEnableStatus = skillAsset.SkillTypeAsset.StartingSkillEnableStatus;

        }
        
        
        
        
        /// <summary>
        /// Creates unique 'OR' and 'AND' basic conditions inside the standard action
        /// </summary>
        private void InitializeUniqueBasicConditions()
        {
            foreach (var standardAction in _skillLogic.SkillEffect.StandardActions)
            {
                var j = 0;
                foreach (var basicCondition in standardAction.OrBasicConditions)
                {
                    var basicConditionCloneObject = Instantiate(basicCondition as ScriptableObject);
                    var basicConditionClone = basicConditionCloneObject as IBasicConditionAsset;
                    
                    //create unique 'OR' basic condition in the standard action 
                    standardAction.OrBasicConditionsScriptableObjects[j] = basicConditionCloneObject;
                    
                    //set basic condition skill reference
                    basicConditionClone?.InitializeSkillParent(_skillLogic.Skill);
                    
                    j++;
                }

                var k = 0;
                foreach (var basicCondition in standardAction.AndBasicConditions)
                {
                    var basicConditionCloneObject = Instantiate(basicCondition as ScriptableObject);
                    var basicConditionClone = basicConditionCloneObject as IBasicConditionAsset;
                    
                    //create unique 'AND' basic condition in the standard action
                    standardAction.AndBasicConditionsScriptableObjects[k] = basicConditionCloneObject;
                    
                    //set basic condition skill reference
                    basicConditionClone?.InitializeSkillParent(_skillLogic.Skill);
                    
                    k++;
                }
            }
        }
        
    }
}