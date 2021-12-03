using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Logic
{
    public class HeroPreviewHealth : MonoBehaviour, IHeroPreviewHealth
    {
        [SerializeField] private TextMeshProUGUI previewText;
        
        public TextMeshProUGUI PreviewText { get => previewText; set => previewText = value; }
    }
}
