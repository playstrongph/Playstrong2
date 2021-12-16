using System;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Logic
{
    public class GameBoard : MonoBehaviour, IGameBoard
    {
        /// <summary>
        /// Battle scene manager reference.
        /// Set in runtime.
        /// </summary>
        public IBattleSceneManager BattleSceneManager { get; set; }
        
        /// <summary>
        /// Game board canvas reference
        /// </summary>
        [SerializeField] private Canvas boardCanvas;
        public Canvas BoardCanvas
        {
            get => boardCanvas;
            set => boardCanvas = value;
        }
        
        /// <summary>
        /// Game board image reference
        /// </summary>
        [SerializeField] private Image boardImage;
        public Image BoardImage
        {
            get => boardImage;
            set => boardImage = value;
        }
        
        /// <summary>
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;


    }
}
