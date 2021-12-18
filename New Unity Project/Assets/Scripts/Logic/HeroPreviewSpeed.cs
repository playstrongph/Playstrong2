using TMPro;
using UnityEngine;

namespace Logic
{
    public class HeroPreviewSpeed : MonoBehaviour, IHeroPreviewSpeed
    {
        [SerializeField] private TextMeshProUGUI previewText;
        
        public TextMeshProUGUI PreviewText { get => previewText; set => previewText = value; }
    }
}