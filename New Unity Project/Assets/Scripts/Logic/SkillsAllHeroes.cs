using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class SkillsAllHeroes : MonoBehaviour, ISkillsAllHeroes
    {
        /// <summary>
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;

        /// <summary>
        /// Returns a list of all skills of all heroes for a player
        /// Used in initializing skill effects at the start of the game
        /// </summary>
        public List<ISkill> AllHeroesSkills { get; private set; } = new List<ISkill>();
    }
}