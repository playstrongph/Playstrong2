using System;
using System.Collections;
using UnityEngine;

namespace Logic
{
    
    /// <summary>
    /// Initializes hero portrait and display portrait
    /// </summary>
    public class InitializeHeroPortrait : MonoBehaviour, IInitializeHeroPortrait
    {
        /// <summary>
        /// Hero reference
        /// </summary>
        private IHero _hero;

        private void Awake()
        {
            _hero = GetComponent<IHero>();
        }

        public void StartAction()
        {
            
            var portraits = _hero.Player.Portraits;
            var displayPortraits = _hero.Player.DisplayPortraits;
            var portraitPrefab = _hero.Player.BattleSceneManager.BattleSceneSettings.HeroPortrait.ThisGameObject;

            //Create hero portrait
            var heroPortraitObject = Instantiate(portraitPrefab, portraits.ThisGameObject.transform);
            var heroPortrait = heroPortraitObject.GetComponent<IHeroPortrait>();
            
            //Create hero displayPortrait
            var displayHeroPortraitObject = Instantiate(portraitPrefab, displayPortraits.ThisGameObject.transform);
            var displayHeroPortrait = displayHeroPortraitObject.GetComponent<IHeroPortrait>();
            
            //Set portrait and display portrait inspector name
            heroPortraitObject.name = _hero.ThisGameObject.name + "Portrait";
            displayHeroPortraitObject.name = _hero.ThisGameObject.name + "DisplayPortrait";
            
            //Set portrait and display portrait graphic image
            heroPortrait.PortraitImage.sprite = _hero.HeroVisual.HeroGraphic.HeroImage.sprite;
            displayHeroPortrait.PortraitImage.sprite = _hero.HeroVisual.HeroGraphic.HeroImage.sprite;
            
            //Hide hero and display portrait
            heroPortrait.TogglePortraitDisplay.HidePortrait();
            //displayHeroPortrait.TogglePortraitDisplay.HidePortrait();

            //Set hero's portrait reference
            _hero.HeroPortrait = heroPortrait;
            _hero.DisplayHeroPortrait = displayHeroPortrait;

           
        }


    }
}
