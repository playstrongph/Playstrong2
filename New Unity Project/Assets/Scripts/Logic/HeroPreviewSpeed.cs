using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Logic
{
    public class HeroPreviewSpeed : MonoBehaviour, IHeroPreviewSpeed
    {
        [SerializeField] private TextMeshProUGUI previewText;
        
        public TextMeshProUGUI PreviewText { get => previewText; set => previewText = value; }
    }
}
