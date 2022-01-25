using System;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace Logic
{
    public class LoadStatusEffectAsset : MonoBehaviour
    {

        private IStatusEffect _statusEffect;

        private void Awake()
        {
            _statusEffect = GetComponent<IStatusEffect>();
        }

        private void StartAction(IHero targetHero, IHero casterHero, IStatusEffectAsset statusEffectAsset, int counters)
        {
            _statusEffect.StatusEffectName = statusEffectAsset.StatusEffectName;
            _statusEffect.StatusEffectDescription = statusEffectAsset.Description;
            _statusEffect.CountersValue = statusEffectAsset.CountersValue;
            _statusEffect.Icon.sprite = statusEffectAsset.Icon;
            
            _statusEffect.StatusEffectCasterHero = casterHero;
            _statusEffect.StatusEffectTargetHero = targetHero;

            //STATUS EFFECT ATTRIBUTES
            
            //Types - buff, debuff, unique status effect
            _statusEffect.StatusEffectType = statusEffectAsset.StatusEffectType;
            
            //Counters timing update - start or end turn
            _statusEffect.StatusEffectCounterUpdateType = statusEffectAsset.StatusEffectCounterUpdateType;
            
            //Instance types - singe or multiple
            _statusEffect.StatusEffectInstanceType = statusEffectAsset.StatusEffectInstanceType;
            
            //Change counters type - normal, immutable, no change
            _statusEffect.StatusEffectCounterType = statusEffectAsset.StatusEffectCounterType;
        }
    }
}
