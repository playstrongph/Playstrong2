using TMPro;
using UnityEngine;

namespace Logic
{
    public class HeroPreviewChance : MonoBehaviour, IHeroPreviewChance
    {
        [SerializeField] private TextMeshProUGUI previewText;
        
        public TextMeshProUGUI PreviewText { get => previewText; set => previewText = value; }
    }
}