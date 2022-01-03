using Logic;

namespace ScriptableObjectScripts.BasicConditionAssets
{
    public interface IBasicConditionAsset
    {
        /// <summary>
        /// If Check condition logic is met, returns 1
        /// If Check condition logic is not met, returns 0
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        int ConditionValue(IHero hero);

        /// <summary>
        /// Set the skill parent during initialization
        /// 
        /// </summary>
        /// <param name="skill"></param>
        void InitializeSkillParent(ISkill skill);
    }
}