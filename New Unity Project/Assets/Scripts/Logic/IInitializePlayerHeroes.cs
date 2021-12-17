using System.Collections;
using AssetsScriptableObjects;
using UnityEngine;

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
    void StartAction(ITeamHeroesAsset teamHeroesAsset, GameObject heroPrefab, Transform heroesParentLocation,
        Vector3 heroPreviewLocation);
}