using UnityEngine;


namespace Logic
{
    public class SkillsAllHeroes : MonoBehaviour, ISkillsAllHeroes
    {
        /// <summary>
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;
    }
}
