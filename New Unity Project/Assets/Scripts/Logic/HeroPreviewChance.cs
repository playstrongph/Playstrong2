using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroPreviewChance : MonoBehaviour, IHeroPreviewChance
{
    [SerializeField] private TextMeshProUGUI previewText;
        
    public TextMeshProUGUI PreviewText { get => previewText; set => previewText = value; }
}