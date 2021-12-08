using UnityEngine;


namespace Logic
{
    public class AliveHeroes : MonoBehaviour, IAliveHeroes
    {
        /// <summary>
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;
    }
}
