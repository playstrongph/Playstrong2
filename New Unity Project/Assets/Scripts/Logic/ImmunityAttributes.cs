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
      
        
        [SerializeField ]private int stunEffectsImmunity;
        public int StunEffectsImmunity
        {
            get => stunEffectsImmunity;
            set => stunEffectsImmunity = value;
        }

        

    }
}