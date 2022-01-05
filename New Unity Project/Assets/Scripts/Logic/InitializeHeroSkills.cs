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
            var heroSkillsPrefab = _hero.Player.BattleSceneManager.BattleSceneSettings.HeroSkillsPrefab.ThisGameObject;
            var skillPrefab = _hero.Player.BattleSceneManager.BattleSceneSettings.SkillPrefab.ThisGameObject;
            var heroSkillsTransform = _hero.Player.SkillsAllHeroes.ThisGameObject.transform;
            var displaySkillsTransform = _hero.Player.DisplaySkills.ThisGameObject.transform;
            
            var skillAssets = heroAsset.HeroSkillAssets;

            //Create Hero Skills and Display skills Panel
            var heroSkillsObject = Instantiate(heroSkillsPrefab, heroSkillsTransform);
            var displaySkillsObject = Instantiate(heroSkillsPrefab, displaySkillsTransform);
            
            var heroSkills = heroSkillsObject.GetComponent<IHeroSkills>();
            var displaySkills = displaySkillsObject.GetComponent<IHeroSkills>();

            //all skills of all heroes of the player
            var playerSkillsAllHeroes = _hero.Player.SkillsAllHeroes;
            
            heroSkillsObject.name = heroAsset.HeroName + "Skills";
            displaySkillsObject.name = heroAsset.HeroName + "DisplaySkills";
            
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
                skill.CasterHero = _hero;
                displaySkill.CasterHero = _hero;

                //Add to hero skills objects list
                heroSkills.AllSkillsObjects().Add(skillObject);
                displaySkills.AllSkillsObjects().Add(displaySkillObject);
                
                //Disable display skill target collider canvas gameObject
                displaySkill.SkillTargetCollider.TargetCanvas.gameObject.SetActive(false);

                //Loads the skill attributes from the skill asset to the skill attributes component
                skill.SkillLogic.LoadSkillAttributes.StartAction(skillAsset);
                displaySkill.SkillLogic.LoadSkillAttributes.StartAction(skillAsset);
                
                //Loads the skill visuals from the skill asset to the skill visual component
                skill.SkillVisual.LoadSkillVisual.StartAction(skillAsset);
                displaySkill.SkillVisual.LoadSkillVisual.StartAction(skillAsset);
                
                //Loads the skill and skill preview visual details
                skill.SkillPreview.LoadSkillPreviewVisual.StartAction(skillAsset);
                displaySkill.SkillPreview.LoadSkillPreviewVisual.StartAction(skillAsset);
                
                //Initialize skill cooldown text visuals
                skill.SkillVisual.UpdateSkillCooldownVisual.StartAction();
                displaySkill.SkillVisual.UpdateSkillCooldownVisual.StartAction();

                //Skill Glows - based on skill type and skill readiness
                skill.SkillLogic.SkillAttributes.SkillReadiness.StatusAction(skill);
                displaySkill.SkillLogic.SkillAttributes.SkillReadiness.StatusAction(displaySkill);
                
                //Load unique skill effect assets
                skill.SkillLogic.LoadSkillEffectAsset.StartAction(skillAsset);
                
                //add skills to playerSkillsAllHeroes list
                playerSkillsAllHeroes.AllHeroesSkills.Add(skill);
                
            }
            
            //Hide hero skills and display skills
            heroSkills.HideHeroSkills();
            displaySkills.HideHeroSkills();

        }
    }
}