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



    }
}
