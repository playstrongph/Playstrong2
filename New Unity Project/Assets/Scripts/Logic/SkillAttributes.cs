using ScriptableObjectScripts.SkillTargetsAssets;
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
        [Header("SET IN RUNTIME")]
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

    }
}