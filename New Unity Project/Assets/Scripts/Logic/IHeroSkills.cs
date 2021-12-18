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
        /// All skills scriptable objects setter
        /// </summary>
        /// <param name="skills"></param>
        /// <returns></returns>
        List<GameObject> AllSkillsObjects();

        /// <summary>
        /// All skills as list of ISkills
        /// </summary>
        List<ISkill> AllSkills { get; }
        
        /// <summary>
        /// Hide hero skills from display
        /// </summary>
        void HideHeroSkills();
        
        /// <summary>
        /// Display hero skills
        /// </summary>
        void ShowHeroSkills();
    }
}