using System;
using ScriptableObjectScripts.SkillEnableStatusAssets;
using ScriptableObjectScripts.SkillLastUsedStatusAssets;
using ScriptableObjectScripts.SkillReadinessStatusAssets;
using UnityEngine;

namespace Logic
{
    public class UpdateSkillLastUsedStatus : MonoBehaviour, IUpdateSkillLastUsedStatus
    {
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkillLastUsedStatusAsset))]
        private ScriptableObject skillUsedLastTurnAsset;

        private ISkillLastUsedStatusAsset SkillUsedLastTurnAsset
        {
            get => skillUsedLastTurnAsset as ISkillLastUsedStatusAsset;
            set => skillUsedLastTurnAsset = value as ScriptableObject;
        }
        
        
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkillLastUsedStatusAsset))]
        private ScriptableObject skillNotUsedLastTurnAsset;

        private ISkillLastUsedStatusAsset SkillNotUsedLastTurnAsset
        {
            get => skillNotUsedLastTurnAsset as ISkillLastUsedStatusAsset;
            set => skillNotUsedLastTurnAsset = value as ScriptableObject;
        }

        private ISkillLogic _skillLogic;
        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
        }
        
        /// <summary>
        /// Set status to skill used last turn
        /// </summary>
        public void SetUsedSkillLastTurn()
        {
            _skillLogic.SkillAttributes.SkillLastUsedStatus = SkillUsedLastTurnAsset;
        }
        
        /// <summary>
        /// Set status to skill not used last turn
        /// </summary>
        public void SetNotUsedSkillLastTurn()
        {
            _skillLogic.SkillAttributes.SkillLastUsedStatus = SkillNotUsedLastTurnAsset;
        }
        
      



    }
}
