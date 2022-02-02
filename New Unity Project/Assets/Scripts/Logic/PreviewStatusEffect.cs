using System;
using ScriptableObjectScripts.StatusEffectAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public class PreviewStatusEffect : MonoBehaviour, IPreviewStatusEffect
    {
        /// <summary>
        /// StatusEffect preview graphic
        /// </summary>
        [SerializeField] private Image graphicIcon;

        private Image GraphicIcon
        {
            get => graphicIcon;
            set => graphicIcon = value;
        }
        
        /// <summary>
        /// StatusEffect name text  
        /// </summary>
        [SerializeField] private TextMeshProUGUI nameText;

        private TextMeshProUGUI NameText
        {
            get => nameText;
            set => nameText = value;
        }
        
        /// <summary>
        /// StatusEffect description text  
        /// </summary>
        [SerializeField] private TextMeshProUGUI descriptionText;
        

        private TextMeshProUGUI DescriptionText
        {
            get => descriptionText;
            set => descriptionText = value;
        }
        
        /// <summary>
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;
        
        /// <summary>
        /// Updates the preview status effect game object details from the status effect asset 
        /// </summary>
        /// <param name="statusEffectAsset"></param>
        public void UpdatePreviewStatusEffect(IStatusEffectAsset statusEffectAsset)
        {
            GraphicIcon.sprite = statusEffectAsset.Icon;
            NameText.text = statusEffectAsset.StatusEffectName;
            DescriptionText.text = statusEffectAsset.Description;
        }


    }
}