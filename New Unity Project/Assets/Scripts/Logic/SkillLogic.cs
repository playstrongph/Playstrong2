using ScriptableObjectScripts.SkillEffectAssets;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Logic
{
    /// <summary>
    /// SkillLogic reference 
    /// </summary>
    public class SkillLogic : MonoBehaviour, ISkillLogic
    {
        /// <summary>
        /// Reference to skill 
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkill))]
        private Object skill;
        
        public ISkill Skill
        {
            get => skill as ISkill;
            set => skill = value as Object;
        }
        
        /// <summary>
        /// Skill Effect Reference
        /// </summary>
        [Header("SET IN RUNTIME")]
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkillEffectAsset))]
        private ScriptableObject skillEffect;
        public ISkillEffectAsset SkillEffect
        {
            get => skillEffect as ISkillEffectAsset;
            set => skillEffect = value as ScriptableObject;
        }

        /// <summary>
        /// Contains the skill properties such as cooldown, skill type, etc.
        /// </summary>
        public ISkillAttributes SkillAttributes { get; private set; }
        
        /// <summary>
        /// Loads the skill attributes from the skill asset
        /// </summary>
        public ILoadSkillAttributes LoadSkillAttributes { get; private set; }
        
        /// <summary>
        /// Loads the skill effect from the skill asset
        /// </summary>
        public ILoadSkillEffectAsset LoadSkillEffectAsset { get; private set; }


        /// <summary>
        /// Updates the skill cooldown based on cooldown type
        /// </summary>
        public IUpdateSkillCooldown UpdateSkillCooldown { get; private set; }
        
        /// <summary>
        /// Updates the skill readiness status and executes status actions
        /// </summary>
        public IUpdateSkillReadiness UpdateSkillReadiness { get; private set; }
        
        /// <summary>
        /// Reference to the other skill attributes
        /// </summary>
        public IOtherSkillAttributes OtherSkillAttributes { get; private set; }
        
        /// <summary>
        /// Reference to skill events
        /// </summary>
        public ISkillEvents SkillEvents { get; private set; }

        private void Awake()
        {
            SkillAttributes = GetComponent<ISkillAttributes>();
            LoadSkillAttributes = GetComponent<ILoadSkillAttributes>();
            LoadSkillEffectAsset = GetComponent<ILoadSkillEffectAsset>();
            UpdateSkillCooldown = GetComponent<IUpdateSkillCooldown>();
            UpdateSkillReadiness = GetComponent<IUpdateSkillReadiness>();
            OtherSkillAttributes = GetComponent<IOtherSkillAttributes>();
            SkillEvents = GetComponent<ISkillEvents>();
        }
    }
}