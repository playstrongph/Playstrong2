using UnityEngine;

namespace Logic
{
    public class InitializeAllSkillEffects : MonoBehaviour, IInitializeAllSkillEffects
    {
        private ITurnController _turnController;
        
        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
        }
        
        /// <summary>
        /// Subscribe all skills for all heroes for all players at the start of the game
        /// </summary>
        public void StartAction()
        {
            var mainPlayerAllHeroesSkills = _turnController.BattleSceneManager.MainPlayer.SkillsAllHeroes.AllHeroesSkills;
            var enemyPlayerAllHeroesSkills =_turnController.BattleSceneManager.EnemyPlayer.SkillsAllHeroes.AllHeroesSkills;
            
            foreach (var skill in mainPlayerAllHeroesSkills)
            {
                skill.SkillLogic.SkillEffect.SubscribeSkillEffect(skill);
                
                skill.SkillLogic.SkillEffect.SubscribeSkillEffect(skill.CasterHero);
                
                //TEST
                InitializeSkillEvent(skill);
            }
            
            foreach (var skill in enemyPlayerAllHeroesSkills)
            {
                skill.SkillLogic.SkillEffect.SubscribeSkillEffect(skill);
                
                skill.SkillLogic.SkillEffect.SubscribeSkillEffect(skill.CasterHero);
                
                //TEST
                InitializeSkillEvent(skill);
            }
            
        }
        
        /// <summary>
        /// Calls Initialize Skill Event
        /// Note that caster and target hero are just the same, to avoid creating
        /// another delegate type in skill events
        /// </summary>
        private void InitializeSkillEvent(ISkill skill)
        {
            var skillHero = skill.CasterHero;
            
            skill.SkillLogic.SkillEvents.EventInitializeSkill(skillHero,skillHero);
            
            
        }
    }
}
