using UnityEngine;
using UnityEngine.UI;


namespace Logic
{
    public class HeroGraphic : MonoBehaviour, IHeroGraphic
    {
        [SerializeField] private Image heroImage;
        public Image HeroImage { get => heroImage; set => heroImage = value; }
    }
}
