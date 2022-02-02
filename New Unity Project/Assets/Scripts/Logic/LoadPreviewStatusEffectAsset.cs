using System;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace Logic
{
    public class LoadPreviewStatusEffectAsset : MonoBehaviour, ILoadPreviewStatusEffectAsset
    {
        /*private IPreviewStatusEffect _previewStatusEffect;

        private void Awake()
        {
            _previewStatusEffect = GetComponent<IPreviewStatusEffect>();
        }*/
        
        /// <summary>
        /// Load status effect preview components
        /// </summary>
        /// <param name="statusEffectAsset"></param>
        /// <param name="statusEffect"></param>
        public void StartAction(IStatusEffectAsset statusEffectAsset, IStatusEffect statusEffect)
        {
            /*_previewStatusEffect.Icon.sprite = statusEffectAsset.Icon;
            _previewStatusEffect.NameText.text = statusEffectAsset.StatusEffectName;
            _previewStatusEffect.DescriptionText.text = statusEffectAsset.Description;*/
            
            statusEffect.PreviewStatusEffect.GraphicIcon.sprite = statusEffectAsset.Icon;
            statusEffect.PreviewStatusEffect.NameText.text = statusEffectAsset.StatusEffectName;
            statusEffect.PreviewStatusEffect.DescriptionText.text = statusEffectAsset.Description;

        }
    }
}
