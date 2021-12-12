using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public interface IHeroSkills
    {
        
        /// <summary>
        /// Interface access to this as a game object
        /// </summary>
        GameObject ThisGameObject { get; }

        /// <summary>
        /// Returns a list of all the hero's skills
        /// </summary>
        IList<ISkill> AllSkills { get; }
    }
}