using AssetsScriptableObjects;
using ScriptableObjectScripts.ActionTargetAssets;
using ScriptableObjectScripts.BasicConditionAssets;
using ScriptableObjectScripts.SkillEffectAssets;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;


namespace Logic
{
    public class LoadSkillEffectAsset : MonoBehaviour, ILoadSkillEffectAsset
    {
        private ISkillLogic _skillLogic;

        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
        }
        
        /// <summary>
        /// Create a unique skill effect, standard action/s and all its child components, and unique basic conditions.
        /// Required due to same heroes that can exist across teams
        /// </summary>
        public void StartAction(ISkillAsset skillAsset)
        {
            //Order is important - skill effect needs to be 1st
            InitializeUniqueSkillEffect(skillAsset);
            
            //Standard actions - second
            InitializeUniqueStandardActions();
            
            //Basic conditions - last
            InitializeUniqueBasicConditions();

            //Event used by passive skills
            InitializeSkillEvent();
        }
        
        /// <summary>
        /// Create a unique skill effect
        /// </summary>
        /// <param name="skillAsset"></param>
        private void InitializeUniqueSkillEffect(ISkillAsset skillAsset)
        {
            _skillLogic.SkillEffect = Instantiate(skillAsset.SkillEffectAsset as ScriptableObject) as ISkillEffectAsset;
        }

        
        /// <summary>
        /// Create unique standard action/s and its child components - action targets,
        /// </summary>
        private void InitializeUniqueStandardActions()
        {
            var i = 0;
            foreach(var standardActionAsset in  _skillLogic.SkillEffect.StandardActions)
            {
                var standardActionClone = Instantiate(standardActionAsset as ScriptableObject);

                //Crate a unique standard action in skill effect
                _skillLogic.SkillEffect.StandardActionsScriptableObjects[i] = standardActionClone;
                var standardAction = _skillLogic.SkillEffect.StandardActions[i]; 

                //Create unique basic action targets and set skill parent reference
                standardAction.BasicActionTargets = Instantiate(standardAction.BasicActionTargets as ScriptableObject) as IActionHeroesAsset;
                
                //TODO:TEST cleanup - action targets will not be generic if referencing such as these are used
                //standardAction.BasicActionTargets?.InitializeSkillCasterHero(_skillLogic.Skill);
                
                //Create unique basic condition targets and set skill parent reference
                standardAction.BasicConditionTargets = Instantiate(standardAction.BasicConditionTargets as ScriptableObject) as IActionHeroesAsset;
                
                //TODO:TEST cleanup- action targets will not be generic if referencing such as these are used
                //standardAction.BasicConditionTargets?.InitializeSkillCasterHero(_skillLogic.Skill);
                
                //Create unique basic event subscribers and initialize skill parent reference
                standardAction.Subscribers = Instantiate(standardAction.Subscribers as ScriptableObject) as IActionHeroesAsset;
                
                //TODO:TEST cleanup- action targets will not be generic if referencing such as these are used
                //standardAction.Subscribers?.InitializeSkillCasterHero(_skillLogic.Skill);
                
                //Cast standard action as skill standard action
                var skillStandardActionClone = standardActionClone as ISkillActionAsset;
                skillStandardActionClone?.InitializeSkillReference(_skillLogic.Skill);
                
                
                //Set Skill Caster Reference, used by Action Target Hero: SkillCasterHeroAsset
                if (skillStandardActionClone != null)
                    skillStandardActionClone.SkillCasterHero = _skillLogic.Skill.CasterHero;

                i++;

            }
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
        
        /// <summary>
        /// Calls Initialize Skill Event
        /// Note that caster and target hero are just the same, to avoid creating
        /// another delegate type in skill events
        /// </summary>
        private void InitializeSkillEvent()
        {
            var skillHero = _skillLogic.Skill.CasterHero;
            
            _skillLogic.SkillEvents.EventInitializeSkill(skillHero,skillHero);
        }



    }
}
