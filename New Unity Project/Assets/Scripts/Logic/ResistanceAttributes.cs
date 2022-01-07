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


    }
}