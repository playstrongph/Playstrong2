using System.Collections;
using AssetsScriptableObjects;
using UnityEngine;

namespace Logic
{
    public interface IInitializePlayerHeroes
    {
        /// <summary>
        /// Instantiates hero in the game and loads all corresponding values
        /// </summary>
        /// <param name="teamHeroesAsset"></param>
        /// <param name="heroPrefab"></param>
        /// <param name="heroesParentLocation"></param>
        /// <param name="heroPreviewLocation"></param>
        /// <returns></returns>
        IEnumerator StartAction(ITeamHeroesAsset teamHeroesAsset, GameObject heroPrefab, Transform heroesParentLocation,
            Vector3 heroPreviewLocation);
    }
}