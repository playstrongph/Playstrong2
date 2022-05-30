using System.Collections.Generic;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace Logic
{
    public interface IImmunityAttributes
    {

        List<ScriptableObject> DebuffScriptableObjects { get; }

        List<IStatusEffectAsset> Debuffs { get; }
        
        List<ScriptableObject> BuffScriptableObjects { get; }

        List<IStatusEffectAsset> Buffs { get; }
        
        List<ScriptableObject> UniqueStatusEffectsScriptableObjects { get; }

        List<IStatusEffectAsset> UniqueStatusEffects { get; }
        

        int StunEffectsImmunity { get; set; }
    }
}