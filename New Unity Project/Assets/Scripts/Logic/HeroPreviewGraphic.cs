using UnityEngine;
using UnityEngine.UI;

public class HeroPreviewGraphic : MonoBehaviour, IHeroPreviewGraphic
{
    [SerializeField] private Image heroImage;
        
    public Image HeroImage { get => heroImage; set => heroImage = value; }
}