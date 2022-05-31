using System;
using System.Collections.Generic;
using ScriptableObjectScripts.StatusEffectAssets;
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


        [Header("STATUS EFFECT IMMUNITIES")] 
        
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffectAsset))]
        private List<ScriptableObject> immunities = new List<ScriptableObject>();
        
        /// <summary>
        /// "debuffs" scriptable object setter
        /// </summary>
        public List<ScriptableObject> ImmunitiesScriptableObjects => immunities;
        
        public List<IStatusEffectAsset> Immunities
        {
            get
            {
                var newDebuffs = new List<IStatusEffectAsset>();

                foreach (var debuffObject in immunities)
                {
                    var debuff = debuffObject as IStatusEffectAsset;
                    newDebuffs.Add(debuff);
                }
                return newDebuffs;
            }
        }
        
       


        /*[SerializeField ]private int stunEffectsImmunity;
        public int StunEffectsImmunity
        {
            get => stunEffectsImmunity;
            set => stunEffectsImmunity = value;
        }*/

        

    }
}