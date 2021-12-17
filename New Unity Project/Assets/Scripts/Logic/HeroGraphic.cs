using UnityEngine;
using UnityEngine.UI;

public class HeroGraphic : MonoBehaviour, IHeroGraphic
{
    [SerializeField] private Image heroImage;
    public Image HeroImage { get => heroImage; set => heroImage = value; }
}