using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroPreviewAttack : MonoBehaviour, IHeroPreviewAttack
{
    [SerializeField] private TextMeshProUGUI previewText;
        
    public TextMeshProUGUI PreviewText { get => previewText; set => previewText = value; }
}