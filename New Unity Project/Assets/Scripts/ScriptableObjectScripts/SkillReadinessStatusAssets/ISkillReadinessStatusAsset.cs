using Logic;
using ScriptableObjectScripts.StandardActionAssets;

namespace ScriptableObjectScripts.SkillReadinessStatusAssets
{
    public interface ISkillReadinessStatusAsset
    {
        /// <summary>
        /// Executes skill readiness actions based on skill type
        /// </summary>
        /// <param name="skill"></param>
        void StatusAction(ISkill skill);

        /// <summary>
        /// Executes skill action's skill start action when skill readiness is in 'SkillReady' state
        /// </summary>
        /// <param name="skillAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void SkillStartAction(ISkillActionAsset skillAction, IHero casterHero, IHero targetHero);

    }
}