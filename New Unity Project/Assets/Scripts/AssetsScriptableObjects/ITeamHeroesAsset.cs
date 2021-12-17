using System.Collections.Generic;

namespace AssetsScriptableObjects
{
    public interface ITeamHeroesAsset
    {
        /// <summary>
        /// Returns the list of team heroes
        /// </summary>
        /// <returns></returns>
        List<IHeroAsset> TeamHeroes();
    }
}