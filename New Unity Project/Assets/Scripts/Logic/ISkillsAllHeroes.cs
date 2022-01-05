using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public interface ISkillsAllHeroes
    {
        /// <summary>
        /// / Returns this as a game object
        /// </summary>
        /// <returns></returns>
        GameObject ThisGameObject { get; }
        
        /// <summary>
        /// Returns a list of all skills of all heroes for a player
        /// Used in initializing skill effects at the start of the game
        /// </summary>
        List<ISkill> AllHeroesSkills { get; }
    }
}