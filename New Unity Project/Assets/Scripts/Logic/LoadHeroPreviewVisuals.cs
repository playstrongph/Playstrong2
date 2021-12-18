using AssetsScriptableObjects;
using UnityEngine;

namespace Logic
{
    public class LoadHeroPreviewVisuals : MonoBehaviour, ILoadHeroPreviewVisuals
    {
        private IHeroPreview _heroPreview;

        private void Awake()
        {
            _heroPreview = GetComponent<IHeroPreview>();
            
        }
        
        /// <summary>
        /// Loads hero preview details and sets the preview board location
        /// </summary>
        /// <param name="heroAsset"></param>
        public void StartAction(IHeroAsset heroAsset)
        {
            var heroAttributes = _heroPreview.Hero.HeroLogic.HeroAttributes;
            var baseAttackText = heroAttributes.BaseAttack.ToString();
            var baseHealthText = heroAttributes.BaseHealth.ToString();
            var baseSpeedText = heroAttributes.BaseSpeed.ToString();
            var baseChanceText = heroAttributes.BaseChance.ToString();
            var heroPreviewTransform = _heroPreview.Hero.Player.HeroAndSkillPreviews.ThisGameObject.transform;

            _heroPreview.HeroPreviewGraphic.HeroImage.sprite = heroAsset.HeroSprite;
            _heroPreview.HeroPreviewName.PreviewText.text = heroAsset.HeroName;
            
            //BASIC ATTRIBUTES
            _heroPreview.HeroPreviewAttack.PreviewText.text = baseAttackText;
            _heroPreview.HeroPreviewHealth.PreviewText.text = baseHealthText;
            _heroPreview.HeroPreviewSpeed.PreviewText.text = baseSpeedText;
            _heroPreview.HeroPreviewChance.PreviewText.text = baseChanceText;
            
            //REPOSITION HERO PREVIEWS
            _heroPreview.ThisGameObject.transform.SetParent(heroPreviewTransform);
            _heroPreview.ThisGameObject.transform.localPosition = Vector3.zero;
        }

      



    }
}