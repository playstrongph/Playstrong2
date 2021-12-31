using ScriptableObjectScripts.SkillCooldownTypeAssets;
using ScriptableObjectScripts.SkillEnableStatusAssets;
using ScriptableObjectScripts.SkillReadinessStatusAssets;
using ScriptableObjectScripts.SkillTargetsAssets;
using ScriptableObjectScripts.SkillTypeAssets;
using UnityEngine;

namespace Logic
{
    public class SkillAttributes : MonoBehaviour, ISkillAttributes
    {
        private ISkillLogic _skillLogic;

        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
        }
        
        
        /// <summary>
        /// Skill cooldown reference
        /// </summary>
        [Header("ALL SET IN RUNTIME")]
        [SerializeField] private int cooldown;
        public int Cooldown
        {
            get => cooldown;
            set => cooldown = value;
        }
        
        /// <summary>
        /// Base skill cooldown reference
        /// </summary>
        [SerializeField] private int baseCooldown;
        public int BaseCooldown
        {
            get => baseCooldown;
            set => baseCooldown = value;
        }



        [Header("SKILL STATUSES")]
        [SerializeReference]
        [RequireInterfaceAttribute.RequireInterface(typeof(ISkillEnableStatusAsset))]
        private ScriptableObject skillEnableStatus;
        /// <summary>
        /// Skill Enabled Status
        /// </summary>
        public ISkillEnableStatusAsset SkillEnableStatus
        {
            get => skillEnableStatus as ISkillEnableStatusAsset;
            set => skillEnableStatus = value as ScriptableObject;
        }



        [SerializeField]
        [RequireInterfaceAttribute.RequireInterface(typeof(ISkillReadinessStatusAsset))]
        private ScriptableObject skillReadiness;
        /// <summary>
        /// Skill 'Ready' or 'Not Ready' readiness status 
        /// </summary>
        public ISkillReadinessStatusAsset SkillReadiness
        {
            get => skillReadiness as ISkillReadinessStatusAsset;
            set => skillReadiness = value as ScriptableObject;
        }


        /// <summary>
        /// Skill type reference
        /// </summary>
        [Header("SKILL PROPERTIES")]
        [SerializeField]
        [RequireInterfaceAttribute.RequireInterface(typeof(ISkillTypeAsset))]
        private ScriptableObject skillType;

        public ISkillTypeAsset SkillType
        {
            get => skillType as ISkillTypeAsset;
            set => skillType = value as ScriptableObject;
        }


        /// <summary>
        /// Skill valid targets - allies, enemies, other allies, or none (passive skills))
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkillTargetsAsset))]
        private ScriptableObject skillTargets;
        public ISkillTargetsAsset SkillTargets
        {
            get => skillTargets as ISkillTargetsAsset;
            set => skillTargets = value as ScriptableObject;
        }
        
        /// <summary>
        /// Skill cooldown types - normal, immutable, and no cooldown
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkillCooldownTypeAsset))]
        private ScriptableObject skillCooldownType;
        public ISkillCooldownTypeAsset SkillCooldownType
        {
            get => skillCooldownType as ISkillCooldownTypeAsset;
            set => skillCooldownType = value as ScriptableObject;
        }
        
        

    }
}