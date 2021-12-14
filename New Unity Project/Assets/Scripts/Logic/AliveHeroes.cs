using System;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Logic
{
    public class AliveHeroes : MonoBehaviour, IAliveHeroes
    {
        /// <summary>
        /// Reference to Player
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IPlayer))]
        private Object player;
        public IPlayer Player
        {
            get => player as IPlayer;
            private set => player = value as Object;
        }
        
        /// <summary>
        /// Gives access to currently displayed portrait and skills based on last hero selected by the player
        /// </summary>
        public IDisplayedPortraitAndSkills DisplayedPortraitAndSkills { get; private set; }

        /// <summary>
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;

        private void Awake()
        {
            DisplayedPortraitAndSkills = GetComponent<IDisplayedPortraitAndSkills>();
        }
    }
}
