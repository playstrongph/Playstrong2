using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroPreviewSpeed : MonoBehaviour, IHeroPreviewSpeed
{
    [SerializeField] private TextMeshProUGUI previewText;
        
    public TextMeshProUGUI PreviewText { get => previewText; set => previewText = value; }
}