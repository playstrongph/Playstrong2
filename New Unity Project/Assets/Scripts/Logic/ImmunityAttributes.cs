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
        private List<ScriptableObject> debuffs = new List<ScriptableObject>();
        
        /// <summary>
        /// "debuffs" scriptable object setter
        /// </summary>
        public List<ScriptableObject> DebuffScriptableObjects => debuffs;
        
        public List<IStatusEffectAsset> Debuffs
        {
            get
            {
                var newDebuffs = new List<IStatusEffectAsset>();

                foreach (var debuffObject in debuffs)
                {
                    var debuff = debuffObject as IStatusEffectAsset;
                    newDebuffs.Add(debuff);
                }

                return newDebuffs;
            }
        }
        
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffectAsset))]
        private List<ScriptableObject> buffs = new List<ScriptableObject>();
        
        /// <summary>
        /// "Buffs" scriptable object setter
        /// </summary>
        public List<ScriptableObject> BuffScriptableObjects => buffs;

        public List<IStatusEffectAsset> Buffs
        {
            get
            {
                var newBuffs = new List<IStatusEffectAsset>();

                foreach (var buffObject in buffs)
                {
                    var buff = buffObject as IStatusEffectAsset;
                    newBuffs.Add(buff);
                }

                return newBuffs;
            }
        }
        
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffectAsset))]
        private List<ScriptableObject> uniqueStatusEffects = new List<ScriptableObject>();
        
        /// <summary>
        /// "uniqueStatusEffects" scriptable object setter
        /// </summary>
        public List<ScriptableObject> UniqueStatusEffectsScriptableObjects => uniqueStatusEffects;

        public List<IStatusEffectAsset> UniqueStatusEffects
        {
            get
            {
                var newUniqueStatusEffects = new List<IStatusEffectAsset>();

                foreach (var uniqueStatusEffectObject in uniqueStatusEffects)
                {
                    var uniqueStatusEffect = uniqueStatusEffectObject as IStatusEffectAsset;
                    newUniqueStatusEffects.Add(uniqueStatusEffect);
                }
                
                return newUniqueStatusEffects;
            }
        }



        [SerializeField ]private int stunEffectsImmunity;
        public int StunEffectsImmunity
        {
            get => stunEffectsImmunity;
            set => stunEffectsImmunity = value;
        }

        

    }
}