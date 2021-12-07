using UnityEngine;


namespace Logic
{
    public class HeroSkills : MonoBehaviour, IHeroSkills
    {
        /// <summary>
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;
    }
}
