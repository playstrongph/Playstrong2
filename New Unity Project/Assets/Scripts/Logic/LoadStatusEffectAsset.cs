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
           
        }
    }
}
