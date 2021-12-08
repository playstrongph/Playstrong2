using System.Collections.Generic;
using Logic;

namespace AssetsScriptableObjects
{
    public interface ITeamHeroesAsset
    {
        /// <summary>
        /// Returns the list of team heroes
        /// </summary>
        /// <returns></returns>
        List<IHero> TeamHeroes();
    }
}