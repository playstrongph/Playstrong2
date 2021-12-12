using System;
using System.Collections;
using UnityEngine;

namespace Logic
{
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

        public IEnumerator StartAction()
        {
            var logicTree = _hero.CoroutineTrees.MainLogicTree;
            var portraits = _hero.Player.Portraits;
            var portraitPrefab = _hero.Player.BattleSceneManager.BattleSceneSettings.HeroPortrait.ThisGameObject;
            
            //Create hero portrait
            var heroPortraitObject = Instantiate(portraitPrefab, portraits.ThisGameObject.transform);
            var heroPortrait = heroPortraitObject.GetComponent<IHeroPortrait>();
            
            //Set portrait Inspector name
            heroPortraitObject.name = _hero.ThisGameObject.name + "Portrait";
            
            //Set Portrait Image
            heroPortrait.PortraitImage.sprite = _hero.HeroVisual.HeroGraphic.HeroImage.sprite;
            
            //Hide hero portrait
            heroPortrait.TogglePortraitDisplay.HidePortrait();

            //Set hero's portrait reference
            _hero.HeroPortrait = heroPortrait;

            logicTree.EndSequence();
            yield return null;
        }


    }
}
