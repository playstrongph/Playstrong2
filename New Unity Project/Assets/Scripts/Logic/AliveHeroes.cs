using UnityEngine;


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
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;
    }
}
