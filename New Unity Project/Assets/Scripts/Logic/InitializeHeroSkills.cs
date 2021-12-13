﻿using System;
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
            var displaySkillsTransform = _hero.Player.DisplaySkills.ThisGameObject.transform;
            
            var skillAssets = heroAsset.HeroSkillAssets;

            //Create Hero Skills and Display skills Panel
            var heroSkillsObject = Instantiate(heroSkillsPrefab, heroSkillsTransform);
            var displaySkillsObject = Instantiate(heroSkillsPrefab, displaySkillsTransform);
            
            var heroSkills = heroSkillsObject.GetComponent<IHeroSkills>();
            var displaySkills = displaySkillsObject.GetComponent<IHeroSkills>();
            
            heroSkillsObject.name = heroAsset.HeroName + "Skills";
            displaySkillsObject.name = heroAsset.HeroName + "Skills";
            
            //Set Hero  skills and display Skills reference
            _hero.HeroSkills = heroSkills;
            _hero.DisplayHeroSkills = displaySkills;
            
            //Create Hero Skills and set values using skillAssets
            foreach (var skillAsset in skillAssets)
            {
                //Create skill game object
                var skillObject = Instantiate(skillPrefab, heroSkillsObject.transform);
                var displaySkillObject = Instantiate(skillPrefab, displaySkillsObject.transform);
                var skill = skillObject.GetComponent<ISkill>();
                var displaySkill = displaySkillObject.GetComponent<ISkill>();
               
                
                //Set skill name
                skillObject.name = skillAsset.SkillName;
                displaySkillObject.name = skillAsset.SkillName;
                skill.SkillName = skillAsset.SkillName;
                displaySkill.SkillName = skillAsset.SkillName;
                
                //Set hero reference
                skill.Hero = _hero;
                displaySkill.Hero = _hero;

                //Add to hero skills objects list
                heroSkills.AllSkillsObjects().Add(skillObject);
                displaySkills.AllSkillsObjects().Add(skillObject);
                
                //TODO: Skill.LoadSkillAttributes
                skill.SkillLogic.LoadSkillAttributes.StartAction(skillAsset);
                displaySkill.SkillLogic.LoadSkillAttributes.StartAction(skillAsset);
                
                //TODO: Skill.LoadSkillVisuals

            }
            

        }
    }
}