using System;
using UnityEngine;

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
            
        
    }
}
