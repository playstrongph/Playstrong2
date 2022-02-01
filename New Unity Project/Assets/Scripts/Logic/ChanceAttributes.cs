﻿using UnityEngine;

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

        [SerializeField] private int buffChance = 100;
        /// <summary>
        /// Probability for hero to inflict buff, default value is 100
        /// </summary>
        public int BuffChance
        {
            get => buffChance;
            set => buffChance = value;
        }


    }
}
