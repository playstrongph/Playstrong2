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
            var skillPrefab = _hero.Player.BattleSceneManager.BattleSceneSettings.SkillPrefab.ThisGameObject;
            var heroSkillsTransform = _hero.Player.SkillsAllHeroes.ThisGameObject.transform;
            var skillAssets = heroAsset.HeroSkillAssets;

            //Create Hero Skills Panel
            var heroSkillsObject = Instantiate(heroSkillsPrefab, heroSkillsTransform);
            var heroSkills = heroSkillsObject.GetComponent<IHeroSkills>();
            heroSkillsObject.name = heroAsset.HeroName + "Skills";
            
            //Set Hero all skills reference
            _hero.HeroSkills = heroSkills;
            
            //Create Hero Skills and set values using skillAssets
            foreach (var skillAsset in skillAssets)
            {
                //Create skill game object
                var skillObject = Instantiate(skillPrefab, heroSkillsObject.transform);
                var skill = skillObject.GetComponent<ISkill>();
                
                //Set skill name
                skillObject.name = skillAsset.SkillName;
                skill.SkillName = skillAsset.SkillName;
                
                //Set hero reference
                skill.Hero = _hero;
                
                
                //Add to hero skills objects list
                heroSkills.AllSkillsObjects().Add(skillObject);
                
                //TODO: Skill.LoadSkillAttributes
                
                //TODO: Skill.LoadSkillVisuals

            }
            

        }
    }
}
