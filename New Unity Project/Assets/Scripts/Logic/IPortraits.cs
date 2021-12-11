using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public interface IPortraits
    {
        /// <summary>
        /// Reference to portrait as a game object
        /// </summary>
        GameObject ThisGameObject { get; }
        
        /// <summary>
        ///  Returns a list of hero portraits
        /// </summary>
        /// <returns></returns>
        List<IHeroPortrait> HeroPortraits();
    }
}