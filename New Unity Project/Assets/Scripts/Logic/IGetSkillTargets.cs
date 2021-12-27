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
    }
}