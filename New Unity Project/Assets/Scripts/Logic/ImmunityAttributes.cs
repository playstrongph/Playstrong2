using System;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Status Effect Immunities
    /// </summary>
    public class ImmunityAttributes : MonoBehaviour, IImmunityAttributes
    {
        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
        
        
        [Header("Debuff Immunities")]

        [SerializeField ]private int sleepImmunity;
        public int SleepImmunity
        {
            get => sleepImmunity;
            set => sleepImmunity = value;
        }
        
        [SerializeField ]private int stunImmunity;
        public int StunImmunity
        {
            get => stunImmunity;
            set => stunImmunity = value;
        }

        

    }
}