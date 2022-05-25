using Logic;

namespace ScriptableObjectScripts.StandardActionAssets
{
    public interface ISkillActionAsset
    {
        /// <summary>
        /// Initialized during LoadAttributes create unique standard actions
        /// </summary>
        /// <param name="skill"></param>
        void InitializeSkillReference(ISkill skill);

        /// <summary>
        /// Executes the base class method StartActionCoroutine
        /// When skill readiness status is 'SkillReady'
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void SkillStartAction(IHero casterHero,IHero targetHero);
        
        
        /// <summary>
        /// Requires a unique instance of the skill action asset to set the reference
        /// Reference is set in LoadSkillEffectAsset.cs
        /// </summary>
        IHero SkillCasterHero { get; set; }
    }
}