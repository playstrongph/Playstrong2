using System;
using ScriptableObjectScripts.SkillCooldownTypeAssets;
using ScriptableObjectScripts.SkillTargetsAssets;
using ScriptableObjectScripts.SkillTypeAssets;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AssetsScriptableObjects   
{
    /// <summary>
    /// New skill asset 
    /// </summary>
    [CreateAssetMenu(fileName = "NewSkill", menuName = "Assets/NewSkill")]
    public class SkillAsset : ScriptableObject, ISkillAsset
    {
        /// <summary>
        /// Reference to name of the skill
        /// </summary>
        [Header("Skill Name")] 
        [SerializeField]
        private string skillName;

        public String SkillName
        {
            get => skillName;
            private set => skillName = value;
        }

        /// <summary>
        /// Reference to the skill ability text
        /// </summary>
        [TextArea(2, 3)] [SerializeField] 
        private string skillDescription;

        public String SkillDescription
        {
            get => skillDescription;
            private set => skillDescription = value;

        }
        
        /// <summary>
        /// Reference to the skill graphic icon
        /// </summary>
        [Header("Skill Graphic")] 
        [SerializeField]
        private Sprite skillIcon;

        public Sprite SkillIcon
        {
            get => skillIcon;
            private set => skillIcon = value;

        }

        /// <summary>
        /// Skill type asset
        /// </summary>
        [Header("Skill Type")] [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkillTypeAsset))]
        private ScriptableObject skillTypeAsset;
        public ISkillTypeAsset SkillTypeAsset
        {
            get => skillTypeAsset as ISkillTypeAsset;
            set => skillTypeAsset = value as ScriptableObject;
        }



        /// <summary>
        /// Reference to the skill cooldown
        /// </summary>
        [Header("Skill Cooldown")] 
        [SerializeField]
        private int baseCooldown;

        public int BaseCooldown
        {
            get => baseCooldown;
            private set => baseCooldown = value;
        }
        
        /// <summary>
        /// Skill Targets 
        /// </summary>
        [Header("Skill Targets")] [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkillTargetsAsset))]
        private ScriptableObject skillTargetsAsset;
        public ISkillTargetsAsset SkillTargetsAsset
        {
            get => skillTargetsAsset as ISkillTargetsAsset;
            private set => skillTargetsAsset = value as ScriptableObject;
        }
        
        /// <summary>
        /// Skill Cooldown Type - Normal, Immutable, No cooldown
        /// </summary>
        [Header("Skill Cooldown Type")]
        [SerializeField]
        [RequireInterfaceAttribute.RequireInterface(typeof(ISkillCooldownTypeAsset))]
        private ScriptableObject skillCooldownTypeAsset;

        public ISkillCooldownTypeAsset SkillCooldownTypeAsset
        {
            get => skillCooldownTypeAsset as ISkillCooldownTypeAsset;
            private set => skillCooldownTypeAsset = value as ScriptableObject;
        }



    }
}
