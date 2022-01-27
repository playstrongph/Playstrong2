using System;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace Logic
{
    public class LoadPreviewStatusEffectAsset : MonoBehaviour, ILoadPreviewStatusEffectAsset
    {
        private IPreviewStatusEffect _previewStatusEffect;

        private void Awake()
        {
            _previewStatusEffect = GetComponent<IPreviewStatusEffect>();
        }
        
        /// <summary>
        /// Load status effect preview components
        /// </summary>
        /// <param name="statusEffectAsset"></param>
        public void StartAction(IStatusEffectAsset statusEffectAsset)
        {
            _previewStatusEffect.Icon.sprite = statusEffectAsset.Icon;
            _previewStatusEffect.NameText.text = statusEffectAsset.StatusEffectName;
            _previewStatusEffect.DescriptionText.text = statusEffectAsset.Description;

        }
    }
}
