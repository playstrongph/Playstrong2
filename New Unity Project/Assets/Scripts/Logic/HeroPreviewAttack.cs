using TMPro;
using UnityEngine;

namespace Logic
{
    public class HeroPreviewAttack : MonoBehaviour, IHeroPreviewAttack
    {
        [SerializeField] private TextMeshProUGUI previewText;
        
        public TextMeshProUGUI PreviewText { get => previewText; set => previewText = value; }
    }
}