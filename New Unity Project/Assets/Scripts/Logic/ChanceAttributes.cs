using UnityEngine;

namespace Logic
{
    public class ChanceAttributes : MonoBehaviour, IChanceAttributes
    {
        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
        
        [SerializeField] private int criticalChance = 0;
        /// <summary>
        /// Probability for a hero to deal critical strike
        /// </summary>
        public int CriticalChance
        {
            get => criticalChance;
            set => criticalChance = value;
        }

        [SerializeField] private int penetrateArmorChance = 0;
        /// <summary>
        /// Probability for damage to ignore armor
        /// </summary>
        public int PenetrateArmorChance
        {
            get => penetrateArmorChance;
            set => penetrateArmorChance = value;
        }
        
        [SerializeField] private int healChance = 0;
        /// <summary>
        /// Probability for hero to cast healing
        /// </summary>
        public int HealChance
        {
            get => healChance;
            set => healChance = value;
        }

        [SerializeField] private int buffChance = 0;
        /// <summary>
        /// Additional chance to inflict a buff.  Default buff chance is set in the AddStatusEffect action default chance
        /// </summary>
        public int BuffChance
        {
            get => buffChance;
            set => buffChance = value;
        }
        
        [SerializeField] private int debuffChance = 0;
        /// <summary>
        /// Additional chance to inflict a debuff.  Default debuff chance is set in the AddStatusEffect action default chance
        /// </summary>
        public int DebuffChance
        {
            get => debuffChance;
            set => debuffChance = value;
        }
        
       


    }
}
