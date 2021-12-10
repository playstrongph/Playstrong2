using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Logic
{
    public class HeroPreviewName : MonoBehaviour, IHeroPreviewName
    {
        [SerializeField] private TextMeshProUGUI previewName;
        
        public TextMeshProUGUI PreviewText { get => previewName; set => previewName = value; }
    }
}
