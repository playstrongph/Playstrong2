using System;
using System.Collections;
using ScriptableObjectScripts.SkillReadinessStatusAssets;
using UnityEngine;

namespace Logic
{
    public class UpdateSkillReadiness : MonoBehaviour, IUpdateSkillReadiness
    {   
        /// <summary>
        /// Skill ready asset reference
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkillReadinessStatusAsset))]
        private ScriptableObject skillReadyAsset;
        public ISkillReadinessStatusAsset SkillReadyAsset
        {
            get => skillReadyAsset as ISkillReadinessStatusAsset;
            set => skillReadyAsset = value as ScriptableObject;
        }
        
        /// <summary>
        /// Skill not ready asset reference
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkillReadinessStatusAsset))]
        private ScriptableObject skillNotReadyAsset;
        public ISkillReadinessStatusAsset SkillNotReadyAsset
        {
            get => skillNotReadyAsset as ISkillReadinessStatusAsset;
            set => skillNotReadyAsset = value as ScriptableObject;
        }
        
        private ISkillLogic _skillLogic;

        private Action _startAction;
        
        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
            
            //_startAction initialized with default action
            _startAction = StartActionLogic;
        }
        
        /// <summary>
        /// Set skill readiness to 'Ready' or 'Not Ready' depending on skill type
        /// when skill is enabled.  No action when skill is disabled.
        /// </summary>
        public void StartAction()
        {
            _startAction();
        }
        
        /// <summary>
        /// Sets skill readiness start action back to default 
        /// </summary>
        public void EnableSkillReadiness()
        {
            //Returns the default skill readiness status action
            _startAction = StartActionLogic;
            
            //Re-updates the skill with its current skill readiness status action based on skill cooldown
            _startAction();
        }
        
        /// <summary>
        /// Sets the skill readiness start action to no action
        /// </summary>
        public void DisableSkillReadiness()
        {
            //Disables the skill readiness status action
            _startAction = NoAction;
            
            //Sets the disabled skill to "Not Ready" status
            SetSkillNotReady();
        }


        /// <summary>
        /// Set skill readiness to 'Ready' or 'Not Ready' depending on skill type
        /// </summary>
        private void StartActionLogic()
        {

            //Condition for set skill ready here should be based on skill type, special consideration for fighting active skill 
            _skillLogic.SkillAttributes.SkillType.UpdateSkillReadiness(_skillLogic.Skill,this);
            
        }

        /// <summary>
        /// Set skill status to 'Ready' and execute status actions
        /// </summary>
        public void SetSkillReady()
        {
            _skillLogic.SkillAttributes.SkillReadiness = SkillReadyAsset;
            _skillLogic.SkillAttributes.SkillReadiness.StatusAction(_skillLogic.Skill);
        }
        
        /// <summary>
        /// Set skill status to 'Not Ready' and execute status actions
        /// </summary>
        public void SetSkillNotReady()
        {
            _skillLogic.SkillAttributes.SkillReadiness = SkillNotReadyAsset;
            _skillLogic.SkillAttributes.SkillReadiness.StatusAction(_skillLogic.Skill);
        }
        
        /// <summary>
        /// Do nothing when skill is disabled
        /// </summary>
        private void NoAction()
        {
        }





    }
}
