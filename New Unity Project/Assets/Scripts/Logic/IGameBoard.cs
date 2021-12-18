using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public interface IGameBoard
    {
        /// <summary>
        /// Battle scene manager reference.
        /// Set in runtime.
        /// </summary>
        IBattleSceneManager BattleSceneManager { get; set; }

        Canvas BoardCanvas { get; set; }
        Image BoardImage { get; set; }

        /// <summary>
        /// Returns this as a game object
        /// </summary>
        GameObject ThisGameObject { get; }
    }
}