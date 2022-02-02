using ScriptableObjectScripts.StatusEffectAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public interface IPreviewStatusEffect
    {
        Image GraphicIcon { get; set; }
        TextMeshProUGUI NameText { get; set; }
        TextMeshProUGUI DescriptionText { get; set; }
        
        /// <summary>
        /// Returns the inheriting class as a game object
        /// </summary>
        GameObject ThisGameObject { get; }

        void UpdatePreviewStatusEffect(IStatusEffectAsset statusEffectAsset);
        
        /// <summary>
        /// Load preview status effect values
        /// </summary>
        ILoadPreviewStatusEffectAsset LoadPreviewStatusEffectAsset { get; }
    }
}