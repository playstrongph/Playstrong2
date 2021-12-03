using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Logic
{
    public class HeroPreviewText : MonoBehaviour, IHeroPreviewText
    {
        [SerializeField] private TextMeshProUGUI previewText;
        
        public TextMeshProUGUI PreviewText { get => previewText; set => previewText = value; }
    }
}
