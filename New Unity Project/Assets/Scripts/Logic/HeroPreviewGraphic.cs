using UnityEngine;
using UnityEngine.UI;


namespace Logic
{
    public class HeroPreviewGraphic : MonoBehaviour, IHeroPreviewGraphic
    {
        [SerializeField] private Image heroImage;
        
        public Image HeroImage { get => heroImage; set => heroImage = value; }
    }
}
