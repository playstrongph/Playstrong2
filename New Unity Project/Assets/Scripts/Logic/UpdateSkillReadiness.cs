﻿using System.Collections;
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
        private ISkillReadinessStatusAsset SkillReadyAsset
        {
            get => skillReadyAsset as ISkillReadinessStatusAsset;
            set => skillReadyAsset = value as ScriptableObject;
        }
        
        /// <summary>
        /// Skill not ready asset reference
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkillReadinessStatusAsset))]
        private ScriptableObject skillNotReadyAsset;
        private ISkillReadinessStatusAsset SkillNotReadyAsset
        {
            get => skillNotReadyAsset as ISkillReadinessStatusAsset;
            set => skillNotReadyAsset = value as ScriptableObject;
        }
        
        private ISkillLogic _skillLogic;
        
        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
        }
        
        /// <summary>
        /// Set skill readiness to 'Ready' or 'Not Ready' depending on skill type
        /// </summary>
        public void StartAction()
        {
            var skillCooldown = _skillLogic.SkillAttributes.Cooldown;

            if (skillCooldown <= 0)
                SetSkillReady();
            else
                SetSkillNotReady();
        }
        
        /// <summary>
        /// Coroutine version for sequential logic
        /// Set skill readiness to 'Ready' or 'Not Ready' depending on skill type
        /// </summary>
        public IEnumerator StartActionCoroutine()
        {
            var logicTree = _skillLogic.Skill.CoroutineTrees.MainLogicTree;
            
            StartAction();
            
            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Set skill status to 'Ready' and execute status actions
        /// </summary>
        private void SetSkillReady()
        {
            _skillLogic.SkillAttributes.SkillReadiness = SkillReadyAsset;
            _skillLogic.SkillAttributes.SkillReadiness.StatusAction(_skillLogic.Skill);
        }
        
        /// <summary>
        /// Set skill status to 'Not Ready' and execute status actions
        /// </summary>
        private void SetSkillNotReady()
        {
            _skillLogic.SkillAttributes.SkillReadiness = SkillNotReadyAsset;
            _skillLogic.SkillAttributes.SkillReadiness.StatusAction(_skillLogic.Skill);
        }



    }
}
