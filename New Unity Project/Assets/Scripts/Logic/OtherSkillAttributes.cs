using System;
using AssetsScriptableObjects;
using UnityEngine;

namespace Logic
{
    public class OtherSkillAttributes : MonoBehaviour, IOtherSkillAttributes
    {
        private ISkillLogic _skillLogic;

        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
        }
        
        /// <summary>
        /// If value is less than or equal to zero, skill can't be used
        /// Used by disable skill effects such as silence and seal
        /// </summary>
        [Header("SKILL FACTORS")] [SerializeField]
        private int usableSkillFactor;
        public int UsableSkillFactor
        {
            get => usableSkillFactor; 
            set => usableSkillFactor = value;
        }
        
        /// <summary>
        /// Special counters used in specific skills
        /// </summary>
        [SerializeField] private int skillCounters;
        public int SkillCounters
        {
            get => skillCounters;
            set => skillCounters = value;
        }
    }
}
