using System;
using ScriptableObjectScripts.SkillEnableStatusAssets;
using ScriptableObjectScripts.SkillReadinessStatusAssets;
using UnityEngine;

namespace Logic
{
    public class UpdateSkillLastUsedStatus : MonoBehaviour, IUpdateSkillLastUsedStatus
    {
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkillLastUsedStatusAsset))]
        private ScriptableObject skillUsedLastTurnAsset;

        public ISkillLastUsedStatusAsset SkillUsedLastTurnAsset
        {
            get => skillUsedLastTurnAsset as ISkillLastUsedStatusAsset;
            set => skillUsedLastTurnAsset = value as ScriptableObject;
        }
        
        
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkillLastUsedStatusAsset))]
        private ScriptableObject skillNotUsedLastTurnAsset;

        public ISkillLastUsedStatusAsset SkillNotUsedLastTurnAsset
        {
            get => skillNotUsedLastTurnAsset as ISkillLastUsedStatusAsset;
            set => skillNotUsedLastTurnAsset = value as ScriptableObject;
        }
        
        

        private ISkillLogic _skillLogic;
        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
        }
        
      



    }
}
