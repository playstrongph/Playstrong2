using System.Collections.Generic;

namespace Logic
{
    public interface IGetSkillTargets
    {
        /// <summary>
        /// Returns a list of valid skill target heroes
        /// </summary>
        /// <returns></returns>
        List<IHero> GetValidTargets();
        
        /// <summary>
        /// Target glows are enabled by skill readiness 'Ready' status action
        /// </summary>
        void EnableGetSkillTargetActions();
        
        /// <summary>
        /// Target glows are disabled by skill readiness 'NotReady' status action
        /// </summary>
        void DisableGetSkillTargetsActions();
    }
}