using System;
using UnityEngine;

namespace Logic
{
    public class DamageAttributes : MonoBehaviour, IDamageAttributes
    {
        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
        
      
        [Header("DEAL DAMAGE FACTORS")] [SerializeField]
        private int criticalDamage = 100;
        /// <summary>
        /// Percent additional damage due to critical attack.
        /// Default value is 100%.
        /// </summary>
        public int CriticalDamage
        {
            get => criticalDamage;
            set => criticalDamage = value;
        }
        
        [Header("TAKE DAMAGE FACTORS")] [SerializeField]
        private int penetrateArmor = 0;
        /// <summary>
        /// Percent of damage that penetrates armor 
        /// </summary>
        public int PenetrateArmor
        {
            get => penetrateArmor;
            set => penetrateArmor = value;
        }
        
        
        [Header("DEAL DAMAGE REDUCTION")] [SerializeField]
        private int allDealDamageReduction;
        /// <summary>
        /// All deal damage types percent reduction
        /// </summary>
        public int AllDealDamageReduction
        {
            get => allDealDamageReduction;
            set => allDealDamageReduction = value;
        }
        
      
        [SerializeField] private int singleDealDamageReduction;
        /// <summary>
        /// Single attack deal damage percent reduction
        /// </summary>
        public int SingleDealDamageReduction
        {
            get => singleDealDamageReduction;
            set => singleDealDamageReduction = value;
        }
        
       
        [SerializeField ]private int multiDealDamageReduction;
        /// <summary>
        /// Multiple attack deal damage percent reduction
        /// </summary>
        public int MultiDealDamageReduction
        {
            get => multiDealDamageReduction;
            set => multiDealDamageReduction = value;
        }

        [SerializeField] private int skillDealDamageReduction;
        /// <summary>
        /// Skill deal damage percent reduction.
        /// </summary>
        public int SkillDealDamageReduction
        {
            get => skillDealDamageReduction;
            set => skillDealDamageReduction = value;
        }
        
        [SerializeField] private int nonSkillDealDamageReduction;
        /// <summary>
        /// NonSkill deal damage percent reduction.
        /// </summary>
        public int NonSkillDealDamageReduction
        {
            get => nonSkillDealDamageReduction;
            set => nonSkillDealDamageReduction = value;
        }
        
        
        [Header("TAKE DAMAGE REDUCTION")] [SerializeField]
        private int allTakeDamageReduction;
        /// <summary>
        /// All take damage types percent reduction
        /// </summary>
        public int AllTakeDamageReduction
        {
            get => allTakeDamageReduction;
            set => allTakeDamageReduction = value;
        }
        
        [SerializeField] private int singleTakeDamageReduction;
        /// <summary>
        /// Single attack take damage percent reduction
        /// </summary>
        public int SingleTakeDamageReduction
        {
            get => singleTakeDamageReduction;
            set => singleTakeDamageReduction = value;
        }
        
        [SerializeField ]private int multiTakeDamageReduction;
        /// <summary>
        /// Multiple attack take damage percent reduction
        /// </summary>
        public int MultiTakeDamageReduction
        {
            get => multiTakeDamageReduction;
            set => multiTakeDamageReduction = value;
        }
        
        [SerializeField] private int skillTakeDamageReduction;
        /// <summary>
        /// Skill take damage percent reduction.
        /// </summary>
        public int SkillTakeDamageReduction
        {
            get => skillTakeDamageReduction;
            set => skillTakeDamageReduction = value;
        }
        
        [SerializeField] private int nonSkillTakeDamageReduction;
        /// <summary>
        /// NonSkill take damage percent reduction.
        /// </summary>
        public int NonSkillTakeDamageReduction
        {
            get => nonSkillTakeDamageReduction;
            set => nonSkillTakeDamageReduction = value;
        }
        
        


    }
}
