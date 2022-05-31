using System.Collections.Generic;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace Logic
{
    public interface IImmunityAttributes
    {
        
        List<ScriptableObject> ImmunitiesScriptableObjects { get; }
        
        List<IStatusEffectAsset> Immunities { get; }


        //int StunEffectsImmunity { get; set; }
    }
}