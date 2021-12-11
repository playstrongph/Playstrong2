using System;
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

        public void StartAction(IHeroAsset heroAsset)
        {
            var heroAttributes = _heroPreview.Hero.HeroLogic.HeroAttributes;
            var baseAttackText = heroAttributes.BaseAttack.ToString();
            var baseHealthText = heroAttributes.BaseHealth.ToString();
            var baseSpeedText = heroAttributes.BaseSpeed.ToString();
            var baseChanceText = heroAttributes.BaseChance.ToString();
            var previewPosition = _heroPreview.Hero.Player.BattleSceneManager.BattleSceneSettings.HeroPreviewPosition;

            _heroPreview.HeroPreviewGraphic.HeroImage.sprite = heroAsset.HeroSprite;
            _heroPreview.HeroPreviewName.PreviewText.text = heroAsset.HeroName;
            _heroPreview.HeroPreviewAttack.PreviewText.text = baseAttackText;
            _heroPreview.HeroPreviewHealth.PreviewText.text = baseHealthText;
            _heroPreview.HeroPreviewSpeed.PreviewText.text = baseSpeedText;
            _heroPreview.HeroPreviewChance.PreviewText.text = baseChanceText;
        }

      



    }
}
