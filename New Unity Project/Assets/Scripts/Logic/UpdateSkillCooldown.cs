using UnityEngine;

namespace Logic
{
    public class UpdateSkillCooldown : MonoBehaviour, IUpdateSkillCooldown
    {
        private ISkillLogic _skillLogic;
        private ISkill _skill;

        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
            _skill = _skillLogic.Skill;
        }

        /// <summary>
        /// Decreases cooldown based on the skill cooldown type
        /// </summary>
        /// <param name="counter"></param>
        public void DecreaseCooldown(int counter)
        {
            _skillLogic.SkillAttributes.SkillCooldownType.DecreaseCooldown(_skill,counter);
        }
        
        /// <summary>
        /// Increases cooldown based on the skill cooldown type
        /// </summary>
        /// <param name="counter"></param>
        public void IncreaseCooldown(int counter)
        {
            _skillLogic.SkillAttributes.SkillCooldownType.IncreaseCooldown(_skill,counter);
        }
        
        /// <summary>
        /// Set cooldown to value based on the skill cooldown type
        /// </summary>
        /// <param name="value"></param>
        public void SetCooldownToValue(int value)
        {
            _skillLogic.SkillAttributes.SkillCooldownType.SetCooldownToValue(_skill,value);
        }
        
        /// <summary>
        /// Set cooldown to max value based on the skill cooldown type
        /// </summary>
        public void ResetCooldownToMax()
        {
            _skillLogic.SkillAttributes.SkillCooldownType.ResetCooldownToMax(_skill);
        }
        
        /// <summary>
        /// Refreshes cooldown based on the skill cooldown type
        /// </summary>
        public void RefreshCooldownToZero()
        {
            _skillLogic.SkillAttributes.SkillCooldownType.RefreshCooldownToZero(_skill);
        }
        
        /// <summary>
        /// Reduces skill cooldown at the end of the turn,
        /// except for passive skills (with no cooldown)
        /// </summary>
        /// <param name="counter"></param>
        public void TurnControllerReduceCooldown(int counter = 1)
        {
            _skillLogic.SkillAttributes.SkillCooldownType.TurnControllerReduceCooldown(_skill,counter);
        }
        
        /// <summary>
        /// Resets the cooldown after skill use
        /// except for passive skills (with no cooldown)
        /// </summary>
        public void UseSkillResetCooldown()
        {
            _skillLogic.SkillAttributes.SkillCooldownType.UseSkillResetCooldown(_skill);
        }
        
        





    }
}
