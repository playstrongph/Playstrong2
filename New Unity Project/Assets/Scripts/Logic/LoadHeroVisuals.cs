using AssetsScriptableObjects;
using UnityEngine;

namespace Logic
{
    public class LoadHeroVisuals : MonoBehaviour, ILoadHeroVisuals
    {
        /// <summary>
        /// Hero logic reference
        /// </summary>
        private IHeroVisual _heroVisual;

        private void Awake()
        {
            _heroVisual = GetComponent<IHeroVisual>();
        }
        
        /// <summary>
        /// Load hero visuals
        /// </summary>
        /// <param name="heroAsset"></param>
        public void StartAction(IHeroAsset heroAsset)
        {
            _heroVisual.HeroGraphic.HeroImage.sprite = heroAsset.HeroSprite;
        }

    }
}