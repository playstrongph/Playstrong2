using UnityEngine;


namespace Logic
{
    public class DisplaySkills : MonoBehaviour, IDisplaySkills
    {
        /// <summary>
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;
    }
}
