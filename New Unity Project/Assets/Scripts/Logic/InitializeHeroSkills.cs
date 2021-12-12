using System;
using System.Collections;
using AssetsScriptableObjects;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Creates Hero Skills and Display Hero Skills
    /// </summary>
    public class InitializeHeroSkills : MonoBehaviour, IInitializeHeroSkills
    {
        private IHero _hero;

        private void Awake()
        {
            _hero = GetComponent<IHero>();
        }

        public void StartAction(IHeroAsset heroAsset)
        {
            var heroSkillsPrefab = _hero.Player.BattleSceneManager.BattleSceneSettings.HeroSkills.ThisGameObject;
            var heroSkillsTransform = _hero.Player.SkillsAllHeroes.ThisGameObject.transform;
            
            //Create Hero Skills Panel
            var heroSkillsObject = Instantiate(heroSkillsPrefab, heroSkillsTransform);
            heroSkillsObject.name = heroAsset.HeroName + "Skills";
            
            //Set Hero all skills reference
            _hero.HeroSkills = heroSkillsObject.GetComponent<IHeroSkills>();

        }
    }
}
