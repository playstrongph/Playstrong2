using ScriptableObjectScripts.StatusEffectAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public interface IPreviewStatusEffect
    {
        /// <summary>
        /// Returns the inheriting class as a game object
        /// </summary>
        GameObject ThisGameObject { get;}
        
        /// <summary>
        /// Updates the preview status effect game object details from the status effect asset 
        /// </summary>
        /// <param name="statusEffectAsset"></param>
        void UpdatePreviewStatusEffect(IStatusEffectAsset statusEffectAsset);
    }
}