using System;
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
        [SerializeField] private int skillCooldown;
        public int SkillCooldown
        {
            get => skillCooldown;
            set => skillCooldown = value;
        }
    }
}
