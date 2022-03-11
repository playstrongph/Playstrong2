using System;
using UnityEngine;

namespace Logic
{
    public class ResistanceAttributes : MonoBehaviour, IResistanceAttributes
    {
        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }


        /// <summary>
        /// Value greater than zero means the hero can't be targeted directly by attack type skills.
        /// Used by stealth, taunt, and similar effects.
        /// </summary>
        [SerializeField ]private int targetAttackResistance;
        public int TargetAttackResistance
        {
            get => targetAttackResistance;
            set => targetAttackResistance = value;
        }

        [SerializeField] private int criticalResistance;
        
        /// <summary>
        /// Probability for a hero to resist critical strike
        /// </summary>
        public int CriticalResistance
        {
            get => criticalResistance;
            set => criticalResistance = value;
        }

        [SerializeField] private int penetrateArmorResistance;
        /// <summary>
        /// Probability for hero to resist ignore armor 
        /// </summary>
        public int PenetrateArmorResistance
        {
            get => penetrateArmorResistance;
            set => penetrateArmorResistance = value;
        }
        
        [SerializeField] private int inabilityResistance;
        /// <summary>
        /// Probability for a hero to resist stun, sleep, and other inability effects
        /// </summary>
        public int InabilityResistance
        {
            get => inabilityResistance;
            set => inabilityResistance = value;
        }

        [SerializeField] private int buffResistance;
        /// <summary>
        /// Probability for a hero to resist buff effects
        /// </summary>
        public int BuffResistance
        {
            get => buffResistance;
            set => buffResistance = value;
        }
        
        [SerializeField] private int debuffResistance;
        /// <summary>
        /// Probability for a hero to resist debuff effects
        /// </summary>
        public int DebuffResistance
        {
            get => debuffResistance;
            set => debuffResistance = value;
        }

    }
}