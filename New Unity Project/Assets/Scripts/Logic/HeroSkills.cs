using System.Collections.Generic;
using UnityEngine;


namespace Logic
{
    public class HeroSkills : MonoBehaviour, IHeroSkills
    {
        /// <summary>
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;

        /// <summary>
        /// Returns a list of all the hero's skills
        /// </summary>
        public IList<ISkill> AllSkills => new List<ISkill>();

    }
}
