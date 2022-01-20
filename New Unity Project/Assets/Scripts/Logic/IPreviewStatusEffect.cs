using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public interface IPreviewStatusEffect
    {
        Image Icon { get; set; }
        TextMeshProUGUI NameText { get; set; }
        TextMeshProUGUI DescriptionText { get; set; }
        
        /// <summary>
        /// Returns the inheriting class as a game object
        /// </summary>
        GameObject ThisGameObject { get; }
    }
}